using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Collections;

public partial class showreport : System.Web.UI.Page
{
    string str_cnn = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=";
    string str_sourcefile = @"App_Data\Data.mdb";
    OleDbConnection cnn;
    OleDbCommand cmd;
    OleDbDataReader datar;
    string str_sql;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //首次展示
            if (string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                //如果获取不到id
                Response.Redirect("index.aspx");
                return;
            }
            if (Session["user_account"] == null || Session["user_class"] == null || Session["user_district"] == null)
            {
                //如果获取session失败
                Response.Redirect("index.aspx");
                return;
            }
            //根据id和当前登录用户类型,判断是否出现问题



            string report_id = Request.QueryString["id"];
            string user_account = Session["user_account"].ToString();
            int user_class = Convert.ToInt32(Session["user_class"]);
            string user_district = Session["user_district"].ToString();

            string str_conn = str_cnn + MapPath(str_sourcefile);
            cnn = new OleDbConnection(str_conn);
            cnn.Open();
            str_sql = "select * from tReport where report_id='" + report_id + "'";
            cmd = new OleDbCommand(str_sql, cnn);
            datar = cmd.ExecuteReader();
            datar.Read();
            string report_account = datar["report_account"].ToString();
            string report_district = datar["report_district"].ToString();
            string report_state = datar["report_state"].ToString();
            cnn.Close();
            //权限范围验证
            div_unpass_reason.Visible = false;
            btnDelete.Attributes.Add("onclick", "return confirm(\"删除后将无法再次看到这份套表的内容,确定删除吗？\\n(报表未通过即作废,您可以修改车辆信息后重新生成并上报.)\")");
            switch (user_class)
            {
                case 0://个人用户
                case 1://企业用户
                    div_pop.Visible = false;
                    if (user_account != report_account)
                    {
                        //如果请求的不是自己的报表
                        Response.Redirect("index.aspx");
                    }
                    else
                    {
                        //是自己的报表
                        if (report_state == "未上报")
                        {
                            //显示上报按钮
                            btnUpdate.Visible = true;
                            btnDelete.Visible = true;
                        }
                        else if (report_state == "未通过")
                        {
                            //显示未通过原因
                            btnDelete.Visible = true;
                            btnError.Visible = true;
                            div_unpass_reason.Visible = true;
                        }
                        else
                        {
                            //其他,仅查看
                        }
                    }
                    break;
                case 2://县级
                    if (user_district != report_district)
                    {
                        //如果看的不是自己县的报表
                        Response.Redirect("index.aspx");
                    }
                    else
                    {
                        //是自己辖区的报表
                        if (report_state == "未上报" || report_state == "未通过")
                        {
                            //没报的和已经退回的不显示
                            Response.Redirect("index.aspx");
                        }
                        else if (report_state == "已上报" || report_state == "网上初审通过")
                        {
                            //显示审核通过/审核不通过按钮
                            btnCheck.Visible = true;
                        }
                        else
                        {
                            //其他,仅查看
                            div_pop.Visible = false;
                        }
                    }
                    break;
                case 3://市级
                    if (report_state == "现场复审通过")
                    {
                        //通过了县级,显示审核通过/不通过按钮
                        btnCheck.Visible = true;
                    }
                    else if (report_state == "市级终审通过")
                    {
                        //终审通过,仅查看
                        div_pop.Visible = false;
                    }
                    else
                    {
                        //其他,无权查看
                        Response.Redirect("index.aspx");
                    }
                    break;
                default:
                    break;
            }
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //上报报表按钮
        string report_id = Request.QueryString["id"];
        string str_conn = str_cnn + MapPath(str_sourcefile);
        cnn = new OleDbConnection(str_conn);
        cnn.Open();
        str_sql = "update tReport set report_state='已上报' where report_id='" + report_id + "'";
        cmd = new OleDbCommand(str_sql, cnn);
        cmd.ExecuteNonQuery();
        cnn.Close();
        Response.Write("<script>alert('套表已成功上报!');window.location.href='userindex.aspx'</script>");
    }


    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (rdol_check_result.SelectedValue == "true")
        {
            //审核通过
            CheckPass();
        }
        else
        {
            //审核不通过
            CheckUnPass();
        }
    }

    protected void CheckPass()
    {
        //审核通过
        string report_id = Request.QueryString["id"];
        string str_conn = str_cnn + MapPath(str_sourcefile);
        cnn = new OleDbConnection(str_conn);
        cnn.Open();
        str_sql = "select report_state from tReport where report_id='" + report_id + "'";
        cmd = new OleDbCommand(str_sql, cnn);
        datar = cmd.ExecuteReader();
        datar.Read();
        string report_state = datar["report_state"].ToString();
        datar.Close();
        cnn.Close();
        string report_newstate = null;
        switch (report_state)
        {
            case "已上报":
                report_newstate = "网上初审通过";
                break;
            case "网上初审通过":
                report_newstate = "现场复审通过";
                break;
            case "现场复审通过":
                report_newstate = "市级终审通过";
                break;
            default:
                break;
        }
        if (!string.IsNullOrEmpty(report_newstate))
        {
            //更改报表状态,记录操作人员,时间等
            cnn.Open();
            string check_account = Session["user_account"].ToString();
            string check_result = "true";
            str_sql = "update tReport set report_state='" + report_newstate + "',report_check_time=#" + DateTime.Now.ToShortTimeString() + "#,report_check_user='" + check_account + "',report_check_result=" + check_result + " where report_id='" + report_id + "'";
            cmd.CommandText = str_sql;
            cmd.ExecuteNonQuery();
            cnn.Close();
            clsNotice.SendNotice(this, clsReport.getAccountById(this, Request.QueryString["id"]), "您的套表(编号:" + Request.QueryString["id"] + "),当前状态变更为[" + report_newstate + "]. <a class=\"button button-small border-blue\" href=\"showreport.aspx?id=" + Request.QueryString["id"] + "\">查看这份套表</a>");
            Response.Write("<script>alert('更改报表状态为:" + report_newstate + ",已完成!');window.location.href='manaindex.aspx'</script>");
        }
    }

    protected void CheckUnPass()
    {
        //审核不通过
        string str_conn = str_cnn + MapPath(str_sourcefile);
        cnn = new OleDbConnection(str_conn);
        cnn.Open();
        str_sql = "update tReport set report_state='未通过',report_check_time=#" + DateTime.Now.ToShortTimeString() + "#,report_check_user='" + Session["user_account"] + "',report_check_result=false,report_check_back_reason='" + txtCheckResult.Text + "' where report_id='" + Request.QueryString["id"] + "'";
        cmd = new OleDbCommand(str_sql, cnn);
        cmd.ExecuteNonQuery();
        cnn.Close();
        //修改车辆上报状态
        setCarsUnreported(getCarIds());
        clsNotice.SendNotice(this, clsReport.getAccountById(this, Request.QueryString["id"]), "您的套表(编号:" + Request.QueryString["id"] + ")未通过审核,已被退回. <a class=\"button button-small border-blue\" href=\"showreport.aspx?id=" + Request.QueryString["id"] + "\">查看这份套表</a>");
        Response.Write("<script>alert('报表已退回!');window.location.href='manaindex.aspx'</script>");
    }

    protected long[] getCarIds()
    {
        string str_conn = str_cnn + MapPath(str_sourcefile);
        cnn = new OleDbConnection(str_conn);
        cnn.Open();
        //str_sql = "SELECT * FROM [tCars] WHERE (([car_user] = '" + Session["user_account"].ToString() + "') AND ([car_reported] = false))";
        str_sql = "select * from tReportCars where report_id='" + Request.QueryString["id"] + "'";
        cmd = new OleDbCommand(str_sql, cnn);
        datar = cmd.ExecuteReader();
        ArrayList al = new ArrayList();
        while (datar.Read())
        {
            al.Add(Convert.ToInt64(datar["car_id"]));
        }
        cnn.Close();
        return (long[])al.ToArray(typeof(long));
    }

    protected void setCarsUnreported(long[] cars)
    {
        string str_conn = str_cnn + MapPath(str_sourcefile);
        cnn = new OleDbConnection(str_conn);
        cnn.Open();
        cmd = new OleDbCommand();
        cmd.Connection = cnn;
        for (int i = 0; i < cars.Length; i++)
        {
            str_sql = "update tCars set car_reported=false where car_id=" + cars[i].ToString();
            cmd.CommandText = str_sql;
            cmd.ExecuteNonQuery();
        }
        cnn.Close();
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string report_id = Request.QueryString["id"];
        string str_conn = str_cnn + MapPath(str_sourcefile);
        cnn = new OleDbConnection(str_conn);
        cnn.Open();
        str_sql = "delete from tReportUser where report_id='" + report_id + "'";
        cmd = new OleDbCommand(str_sql, cnn);
        cmd.ExecuteNonQuery();
        cmd.CommandText = "delete from tReportCars where report_id='" + report_id + "'";
        cmd.ExecuteNonQuery();
        cmd.CommandText = "delete from tReport where report_id='" + report_id + "'";
        cmd.ExecuteNonQuery();
        cnn.Close();
        Response.Redirect("userindex.aspx", true);
    }
}