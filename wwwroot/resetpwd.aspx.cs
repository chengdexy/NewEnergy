using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class resetpwd : System.Web.UI.Page
{
    string str_cnn = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=";
    string str_sourcefile = @"App_Data\Data.mdb";
    OleDbConnection cnn;
    OleDbCommand cmd;
    OleDbDataReader datar;
    string str_sql;

    protected void Page_Load(object sender, EventArgs e)
    {
        //若不是市级管理员访问此页面,则此功能不可用
        if (!IsPostBack)
        {
            //首次加载进行此项验证
            //是否已登录
            if (Session["user_account"] == null || Session["user_class"] == null || Session["user_district"] == null)
            {
                //未登录
                Response.Redirect("index.aspx");
                return;
            }
            else
            {
                int user_class = Convert.ToInt32(Session["user_class"]);
                if (user_class != 3)
                {
                    //不是市级
                    if (user_class == 2)
                    {
                        //县级
                        Response.Redirect("manaindex.aspx");
                        return;
                    }
                    else if (user_class == 0 || user_class == 1)
                    {
                        //用户
                        Response.Redirect("userindex.aspx");
                        return;
                    }
                    else
                    {
                        //错误:不存在的用户类型
                        Response.Redirect("index.aspx");
                        return;
                    }
                }
            }
            btnResetpwd.Attributes.Add("onclick", "return confirm(\"确认重置？\")");
        }
    }

    /// <summary>
    /// 检查某个账号是否已存在
    /// </summary>
    /// <param name="user_account">要检查的账号</param>
    /// <returns>true为已存在,false为不存在</returns>
    protected bool CheckAccountExist(string user_account)
    {
        string str_conn = str_cnn + MapPath(str_sourcefile);
        cnn = new OleDbConnection(str_conn);
        cnn.Open();
        str_sql = "select * from tUserAccount where user_account='" + user_account + "'";
        cmd = new OleDbCommand(str_sql, cnn);
        datar = cmd.ExecuteReader();
        bool _result = datar.HasRows;
        cnn.Close();
        if (_result)
        {
            //已存在
            return true;
        }
        else
        {
            //不存在
            return false;
        }
    }

    protected void btnResetpwd_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (IsValid)
        {
            string str_conn = str_cnn + MapPath(str_sourcefile);
            cnn = new OleDbConnection(str_conn);
            cnn.Open();
            str_sql = "update tUserAccount set user_password='"+clsMD5.getMd5Str("aaaaaa0")+"' where user_account='" + txtUserAccount.Text + "'";
            cmd = new OleDbCommand(str_sql, cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
            lbResult.Text = "账号[" + txtUserAccount.Text + "]的密码已重置为[aaaaaa0]";
        }
    }

    protected void cvUserAccount_ServerValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = CheckAccountExist(txtUserAccount.Text);
    }
}