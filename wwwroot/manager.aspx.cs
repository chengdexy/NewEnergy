using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class manager : System.Web.UI.Page
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
            if (Session["user_account"] != null && Session["user_class"] != null && Session["user_district"] != null)
            {
                //已登录
                int user_class = Convert.ToInt32(Session["user_class"]);
                if (user_class < 2 || user_class > 3)
                {
                    //既不是县级也不是市级
                    Response.Redirect("index.aspx");
                    return;
                }
                else
                {
                    //是监管级别
                    Response.Redirect("manaindex.aspx");
                    return;
                }
            }
        }
    }

    protected void cvCheckLogin_ServerValidate(object source, ServerValidateEventArgs args)
    {
        string user_account = txtAccount.Text;
        string user_password = clsMD5.getMd5Str(txtPassword.Text);
        string str_conn = str_cnn + MapPath(str_sourcefile);
        cnn = new OleDbConnection(str_conn);
        cnn.Open();
        str_sql = "select * from tAdmin where user_account='" + user_account + "' and user_password='" + user_password + "'";
        cmd = new OleDbCommand(str_sql, cnn);
        datar = cmd.ExecuteReader();
        if (datar.HasRows)
        {
            //通过
            args.IsValid = true;
        }
        else
        {
            //不通过
            args.IsValid = false;
        }
        cnn.Close();
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (!IsValid)
        {
            return;
        }

        //验证通过
        //获取用户级别和所属区划
        string user_account = txtAccount.Text;
        string str_conn = str_cnn + MapPath(str_sourcefile);
        cnn = new OleDbConnection(str_conn);
        cnn.Open();
        str_sql = "select user_class,user_district from tAdmin where user_account='" + user_account + "'";
        cmd = new OleDbCommand(str_sql, cnn);
        datar = cmd.ExecuteReader();
        datar.Read();
        string user_class = datar["user_class"].ToString();
        string user_district = datar["user_district"].ToString();
        cnn.Close();
        //写Session
        Session.Add("user_account", user_account);
        Session.Add("user_class", user_class);
        Session.Add("user_district", user_district);
        //跳转到用户首页
        Response.Redirect("manaindex.aspx");

    }

    protected void btnUser_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Server.Transfer("index.aspx");
    }
}