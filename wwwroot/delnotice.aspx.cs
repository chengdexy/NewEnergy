using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class delnotice : System.Web.UI.Page
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
            //首次展示验证是否登陆
            if (Session["user_account"] == null || Session["user_class"] == null || Session["user_district"] == null)
            {
                //未登录
                Response.Redirect("index.aspx");
                return;
            }
            else
            {
                //已登录
                if (string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    //未指定notice_id
                    Session.Clear();
                    Response.Redirect("index.aspx");
                    return;
                }
                else
                {
                    string id = Request.QueryString["id"];
                    string account = Session["user_account"].ToString();
                    string str_conn = str_cnn + MapPath(str_sourcefile);
                    cnn = new OleDbConnection(str_conn);
                    cnn.Open();
                    str_sql = "update tNotice set notice_checked=true where notice_id=" + id + " and notice_to='" + account + "'";
                    cmd = new OleDbCommand(str_sql, cnn);
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    Response.Redirect("userindex.aspx", true);
                }
            }
        }
    }
}