using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class expcars : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string str_cnn = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=";
        string str_sourcefile = @"App_Data\Data.mdb";
        OleDbConnection cnn;
        OleDbCommand cmd;
        OleDbDataReader datar;
        string str_sql;

        if (!IsPostBack)
        {
            //判断登陆人员身份
            string report_id = null;
            if (Request.QueryString["id"] == null)
            {
                //如果没有带报表id
                Response.Redirect("index.aspx", true);
            }
            else
            {
                report_id = Request.QueryString["id"];
            }
            if (Session["user_account"] == null || Session["user_class"] == null || Session["user_district"] == null)
            {
                //如果没登陆
                Response.Redirect("index.aspx", true);
            }
            else
            {
                //已登录

                /*
                    2016年7月5日 增加逻辑,监管人员可以导出
                    先判断用户类别,如果是监管-->验证通过,如果是用户-->判断是否是报表主人
                */
                if (report_id == null)
                {
                    return;
                }
                string user_account = Session["user_account"].ToString();
                string str_conn = str_cnn + MapPath(str_sourcefile);
                cnn = new OleDbConnection(str_conn);
                cnn.Open();
                int report_user_class = Convert.ToInt32(Session["user_class"]);

                int user_class = Convert.ToInt32(Session["user_class"]);
                if (user_class == 0 || user_class == 1)
                {
                    //是用户,判断登陆用户是否是此report_id的主人


                    str_sql = "select * from tReport where report_id='" + report_id + "' and report_account='" + user_account + "'";
                    cmd = new OleDbCommand(str_sql, cnn);
                    datar = cmd.ExecuteReader();
                    if (!datar.HasRows)
                    {
                        //没找到,验证失败
                        datar.Close();
                        cnn.Close();
                        Response.Redirect("index.aspx", true);
                    }
                    datar.Close();
                }
                else if (user_class == 2)
                {
                    //是监管,县级-->是否是本县的
                    string curDistrict = Session["user_district"].ToString();
                    str_sql = "select * from tReport where report_id='" + report_id + "' and report_district='" + curDistrict + "'";
                    cmd = new OleDbCommand(str_sql, cnn);
                    datar = cmd.ExecuteReader();
                    if (!datar.HasRows)
                    {
                        //没找到,不是本县内报表
                        datar.Close();
                        cnn.Close();
                        Response.Redirect("index.aspx", true);
                    }
                    else
                    {
                        datar.Read();
                        report_user_class = Convert.ToInt32(datar["report_class"]);
                    }
                    datar.Close();
                }
                else if (user_class == 3)
                {
                    //市级,仅需获取报表主人用户类别
                    str_sql = "select * from tReport where report_id='" + report_id + "'";
                    cmd = new OleDbCommand(str_sql, cnn);
                    datar = cmd.ExecuteReader();
                    if (!datar.HasRows)
                    {
                        //没找到
                        datar.Close();
                        cnn.Close();
                        Response.Redirect("index.aspx", true);
                    }
                    else
                    {
                        report_user_class = Convert.ToInt32(datar["report_class"]);
                    }
                    datar.Close();
                }
                else
                {
                    //非法class
                    Response.Redirect("index.aspx", true);
                }

                //至此验证通过
                cmd = new OleDbCommand("select * from tReportCars where report_id='" + report_id + "'", cnn);
                datar = cmd.ExecuteReader();
                clsReport.PushReportCarsListToClient(this, datar);
                cnn.Close();
                Response.Redirect("reportlist.aspx");
            }
        }
    }
}