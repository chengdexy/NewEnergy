using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class findpwd : System.Web.UI.Page
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

    protected void btnAccount_Click(object sender, EventArgs e)
    {
        string user_account = txtUserAccount.Text;
        //判断是否新用户
        string str_conn = str_cnn + MapPath(str_sourcefile);
        cnn = new OleDbConnection(str_conn);
        cnn.Open();
        str_sql = "select * from tUserAccount where user_account='" + user_account + "'";
        cmd = new OleDbCommand(str_sql, cnn);
        datar = cmd.ExecuteReader();
        if (datar.HasRows)
        {
            datar.Read();
        }
        else
        {
            cnn.Close();
            string _script = "$('#lblQuestion').text('您输入的账号不存在,请检查后重试.');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", _script, true);
            return;
        }
        if (Convert.ToBoolean(datar["user_first_load"]))
        {
            //是新用户
            cnn.Close();
            string _script = "$('#lblQuestion').text('您是新用户,请使用默认密码aaaaaa0登录.')";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", _script, true);
        }
        else
        {
            string user_findpwd_q = datar["user_findpwd_q"].ToString();
            cnn.Close();
            string _script = "$('#lblQuestion').text('" + user_findpwd_q + "');$('#div_clicktoshow').show();$('#lblResult').text('');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", _script, true);
        }

    }

    protected void btnFind_Click(object sender, EventArgs e)
    {
        string user_account = txtUserAccount.Text;
        string answer = txtAnswer.Text;
        string str_conn = str_cnn + MapPath(str_sourcefile);
        cnn = new OleDbConnection(str_conn);
        cnn.Open();
        str_sql = "select * from tUserAccount where user_account='" + user_account + "'";
        cmd = new OleDbCommand(str_sql, cnn);
        datar = cmd.ExecuteReader();
        if (datar.HasRows)
        {
            datar.Read();
            if (datar["user_findpwd_a"].ToString() == answer)
            {
                datar.Close();
                cmd.CommandText = "update tUserAccount set user_password='"+clsMD5.getMd5Str("aaaaaa0")+"' where user_account='" + user_account + "'";
                cmd.ExecuteNonQuery();
                lblResult.Text = "您的密码已重置为默认密码aaaaaa0\n<a href='index.aspx'>点击这里返回首页</a>";
            }
            else
            {
                lblResult.Text = "答案不正确,未能重置密码.";
            }
        }
        else
        {
            cnn.Close();
            return;
        }
    }
}