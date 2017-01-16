using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class userindex : System.Web.UI.Page
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
            //首次展示页面,验证是否新用户
            if (Session["user_account"] == null || Session["user_class"] == null)
            {
                Response.Redirect("index.aspx");
            }
            string user_account = Session["user_account"].ToString();
            int user_class = Convert.ToInt32(Session["user_class"]);
            string str_conn = str_cnn + MapPath(str_sourcefile);
            cnn = new OleDbConnection(str_conn);
            cnn.Open();
            str_sql = "select user_first_load from tUserAccount where user_account='" + user_account + "' and user_class=" + user_class.ToString();
            cmd = new OleDbCommand(str_sql, cnn);
            datar = cmd.ExecuteReader();
            if (datar.HasRows)
            {
                datar.Read();
                bool user_isfirst = Convert.ToBoolean(datar["user_first_load"]);
                if (user_isfirst)
                {
                    //是新用户
                    cnn.Close();
                    Response.Redirect("changepwd.aspx");
                }
                else
                {
                    //老用户
                    cnn.Close();
                    //展示首页内容
                    showNotices();
                }
            }
            else
            {
                //错误:未找到此用户数据
                cnn.Close();
                Response.Redirect("index.aspx");
            }
        }

    }

    protected void showNotices()
    {

    }
}