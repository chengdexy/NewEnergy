using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Collections;

public partial class addreport : System.Web.UI.Page
{
    string str_cnn = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=";
    string str_sourcefile = @"App_Data\Data.mdb";
    OleDbConnection cnn;
    OleDbCommand cmd;
    OleDbDataReader datar;
    string str_sql;

    protected void Page_Load(object sender, EventArgs e)
    {
        //是否已登录
        if (!IsPostBack)
        {
            if (Session["user_account"] == null || Session["user_class"] == null || Session["user_district"] == null)
            {
                //未登录
                Response.Redirect("index.aspx");
                return;
            }
            else if (string.IsNullOrEmpty(Session["user_district"].ToString()))
            {
                //如果是第一次登录系统
                Response.Redirect("userindex.aspx");
                return;
            }
        }


        //构建申请审核表,构建车辆情况表(自动填充Listview和Gridview)
        //是否有车辆供生成报表?
        string str_conn = str_cnn + MapPath(str_sourcefile);
        cnn = new OleDbConnection(str_conn);
        cnn.Open();
        str_sql = "select * from tCars where car_user='" + Session["user_account"].ToString() + "' and car_reported=false";
        cmd = new OleDbCommand(str_sql, cnn);
        datar = cmd.ExecuteReader();
        if (!datar.HasRows)
        {
            //数据集为空
            btnUpdate.Enabled = false;
            btnUpdate.ToolTip = "您没有未上报的车辆信息,无法生成套表.";
        }
        //是否有报表在审核中?
        datar.Close();
        cmd.CommandText = "select count(*) from tReport where report_account='" + Session["user_account"].ToString() + "' and report_state<>'未上报' and report_state<>'未通过' and report_state<>'市级终审通过'";
        datar = cmd.ExecuteReader();
        datar.Read();
        if (Convert.ToInt32(datar[0]) > 0)
        {
            //有
            btnUpdate.Enabled = false;
            btnUpdate.ToolTip = "因已经有套表在审核中,无法生成新报表.";
            div_hasReported.Visible = true;
        }
        cnn.Close();
    }

    /// <summary>
    /// 保存当前数据到tReport,tReportUser,tReportCars中
    /// </summary>
    /// <param name="user_id">用户id</param>
    /// <param name="car_id[]">车辆id数组</param>
    /// <returns>report_id</returns>
    protected string addNewReport(string user_account, long[] car_id)
    {
        string guid = Guid.NewGuid().ToString();
        string str_conn = str_cnn + MapPath(str_sourcefile);
        cnn = new OleDbConnection(str_conn);
        cnn.Open();
        str_sql = string.Format("insert into tReport(report_id,report_create_time,report_state,report_account,report_class,report_district) values('{0}',#{1}#,'{2}','{3}',{4},'{5}')", guid, DateTime.Now.ToString(), "未上报", Session["user_account"].ToString(), Session["user_class"].ToString(), Session["user_district"].ToString());
        cmd = new OleDbCommand(str_sql, cnn);
        cmd.ExecuteNonQuery();
        cnn.Close();
        //复制tUser内容到tReportUser
        copyUserToReport(user_account, guid);
        //复制tCars内容到tReportCars
        copyCarsToReport(car_id, guid);
        return guid;
    }

    /// <summary>
    /// 取出user_id对应tUser内容保存到tReportUser中
    /// </summary>
    /// <param name="user_id">用户编号</param>
    protected void copyUserToReport(string user_account, string guid)
    {
        string str_conn = str_cnn + MapPath(str_sourcefile);
        cnn = new OleDbConnection(str_conn);
        cnn.Open();
        str_sql = "select * from tUserAccount where user_account='" + user_account + "'";
        cmd = new OleDbCommand(str_sql, cnn);
        datar = cmd.ExecuteReader();
        datar.Read();
        int uclass = Convert.ToInt32(datar["user_class"]);
        string uname = uclass == 1 ? datar["user_companyname"].ToString() : datar["user_username"].ToString();
        string unumber = uclass == 1 ? datar["user_ZZJGDMZ_id"].ToString() : datar["user_useridcard"].ToString();
        string ucontact = uclass == 1 ? datar["user_username"].ToString() : "-";
        string uphone = datar["user_userphone"].ToString();
        string umobile = datar["user_usermobile"].ToString();
        string bankcardname = datar["user_bankcardname"].ToString();
        string bankname = datar["user_bankname"].ToString();
        string bankcardid = datar["user_bankcardid"].ToString();
        datar.Close();
        str_sql = string.Format("insert into tReportUser(report_id,report_name,report_number,report_contact,report_phone,report_mobile,report_bankcardname,report_bankcardid,report_bankname)" +
            " values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", guid, uname, unumber, ucontact, uphone, umobile, bankcardname, bankcardid, bankname);
        cmd.CommandText = str_sql;
        cmd.ExecuteNonQuery();
        cnn.Close();
    }

    protected void copyCarsToReport(long[] car_id, string guid)
    {
        //insert into tReportCars() select () from tCars where car_id=
        string str_conn = str_cnn + MapPath(str_sourcefile);
        cnn = new OleDbConnection(str_conn);
        cnn.Open();
        cmd = new OleDbCommand(str_sql, cnn);

        for (int i = 0; i < car_id.Length; i++)
        {
            cmd.CommandText = "insert into tReportCars(car_id,report_id,car_number,car_vin,car_product,car_brand,car_class,car_kind,car_use,car_price,car_buydate,car_regdate,car_batclass,car_batkind,car_batsize,car_batproduct,car_motkind,car_motproduct,car_engkind,car_engproduct)" +
                " select car_id,'" + guid + "',car_number,car_vin,car_product,car_brand,car_class,car_kind,car_use,car_price,car_buydate,car_regdate,car_batclass,car_batkind,car_batsize,car_batproduct,car_motkind,car_motproduct,car_engkind,car_engproduct from tCars where car_id=" + car_id[i].ToString();
            cmd.ExecuteNonQuery();
        }

        cnn.Close();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //保存到数据库
        long[] cars = getCarIds();
        string guid = addNewReport(Session["user_account"].ToString(), cars);
        //上报
        string str_conn = str_cnn + MapPath(str_sourcefile);
        cnn = new OleDbConnection(str_conn);
        cnn.Open();
        str_sql = "update tReport set report_state='已上报' where report_id='" + guid + "'";
        cmd = new OleDbCommand(str_sql, cnn);
        cmd.ExecuteNonQuery();
        cnn.Close();
        //上报完成,修改车辆状态
        setCarsReported(cars);
        Response.Write("<script>alert('已保存并上报完成!');window.location.href='userindex.aspx'</script>");
    }

    protected void setCarsReported(long[] cars)
    {
        string str_conn = str_cnn + MapPath(str_sourcefile);
        cnn = new OleDbConnection(str_conn);
        cnn.Open();
        cmd = new OleDbCommand();
        cmd.Connection = cnn;
        for (int i = 0; i < cars.Length; i++)
        {
            str_sql = "update tCars set car_reported=true where car_id=" + cars[i].ToString();
            cmd.CommandText = str_sql;
            cmd.ExecuteNonQuery();
        }
        cnn.Close();
    }

    protected long[] getCarIds()
    {
        string str_conn = str_cnn + MapPath(str_sourcefile);
        cnn = new OleDbConnection(str_conn);
        cnn.Open();
        //str_sql = "SELECT * FROM [tCars] WHERE (([car_user] = '" + Session["user_account"].ToString() + "') AND ([car_reported] = false))";
        str_sql = "select * from tCars where car_user='" + Session["user_account"].ToString() + "' and car_reported=false";
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

    protected void btnExport_info_Click(object sender, EventArgs e)
    {
        /*写入到addreport.aspx中btnExport_info_Click中*/

        string str_conn = str_cnn + MapPath(str_sourcefile);
        cnn = new OleDbConnection(str_conn);
        cnn.Open();
        str_sql = "select * from tUserAccount where user_account='" + Session["user_account"].ToString() + "'";
        cmd = new OleDbCommand(str_sql, cnn);
        datar = cmd.ExecuteReader();
        if (datar.HasRows)
        {
            datar.Read();
            int uclass = Convert.ToInt32(datar["user_class"]);
            string uname = uclass == 1 ? datar["user_companyname"].ToString() : datar["user_username"].ToString();
            string unumber = uclass == 1 ? datar["user_ZZJGDMZ_id"].ToString() : datar["user_useridcard"].ToString();
            string ucontact = uclass == 1 ? datar["user_username"].ToString() : "-";
            string uphone = datar["user_userphone"].ToString();
            string umobile = datar["user_usermobile"].ToString();
            string bankcardname = datar["user_bankcardname"].ToString();
            string bankname = datar["user_bankname"].ToString();
            string bankcardid = datar["user_bankcardid"].ToString();
            clsReport.PushReportUserInfoToClient(this, uclass, uname, unumber, ucontact, uphone, umobile, bankcardname, bankcardid, bankname);
        }
        cnn.Close();
    }

    protected void btnExport_cars_Click(object sender, EventArgs e)
    {
        string sql = "select * from tCars where car_user='" + Session["user_account"].ToString() + "' and car_reported=false";
        string str_conn = str_cnn + MapPath(str_sourcefile);
        cnn = new OleDbConnection(str_conn);
        cnn.Open();
        str_sql = sql;
        cmd = new OleDbCommand(str_sql, cnn);
        datar = cmd.ExecuteReader();
        if (datar.HasRows)
        {
            //有数据则生成Excel并push出去
            clsReport.PushReportCarsListToClient(this, datar);
        }
        cnn.Close();
    }
}