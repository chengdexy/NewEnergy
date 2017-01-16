using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class index : System.Web.UI.Page
{
    string str_cnn = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=";
    string str_sourcefile = @"App_Data\Data.mdb";
    OleDbConnection cnn;
    OleDbCommand cmd;
    OleDbDataReader datar;
    string str_sql;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //验证程序
        args.IsValid = CheckAccountPassword(txtUserAccount.Text, clsMD5.getMd5Str(txtUserPassword.Text));

    }

    /// <summary>
    /// 验证用户名和密码是否匹配
    /// </summary>
    /// <param name="user_account">账号</param>
    /// <param name="user_password">密码</param>
    /// <param name="user_class">用户类型</param>
    /// <returns>true验证通过,false验证不通过</returns>
    protected bool CheckAccountPassword(string user_account, string user_password)
    {
        string str_conn = str_cnn + MapPath(str_sourcefile);
        cnn = new OleDbConnection(str_conn);
        cnn.Open();
        str_sql = "select * from tUserAccount where user_account='" + user_account + "' and user_password='" + user_password + "'";
        cmd = new OleDbCommand(str_sql, cnn);
        datar = cmd.ExecuteReader();
        bool _result = datar.HasRows;
        cnn.Close();
        if (_result)
        {
            //通过
            return true;
        }
        else
        {
            //不通过
            return false;
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Page.Validate();

        if (IsValid)//当验证全部通过
        {
            //创建session
            string user_account = txtUserAccount.Text.ToUpper();
            //获取用户类别
            string user_class = clsUser.getUserClass(user_account, this).ToString();
            string str_conn = str_cnn + MapPath(str_sourcefile);
            cnn = new OleDbConnection(str_conn);
            cnn.Open();
            str_sql = "select user_district,user_first_load from tUserAccount where user_account='" + user_account + "'";
            cmd = new OleDbCommand(str_sql, cnn);
            datar = cmd.ExecuteReader();
            datar.Read();
            string user_district = "";
            if (!Convert.ToBoolean(datar["user_first_load"]))
            {
                //不是新用户则获取所属县区
                user_district = datar["user_district"].ToString();
            }
            cnn.Close();
            Session.Add("user_account", user_account);
            Session.Add("user_class", user_class);
            Session.Add("user_district", user_district);
            //跳转用户首页
            Response.Redirect("userindex.aspx");
        }
    }

    protected void btnManager_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Server.Transfer("manager.aspx");
    }
}