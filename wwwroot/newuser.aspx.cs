using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class newuser : System.Web.UI.Page
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
        }
    }

    protected void btnCreat_Click(object sender, EventArgs e)
    {
        int user_class = Convert.ToInt32(rbl_userclass.SelectedItem.Value);
        string user_account = null;
        if (user_class == 0)
        {
            //个人
            user_account = "P" + txtIdCard.Text;
        }
        else if (user_class == 1)
        {
            //企业
            user_account = "C" + txtIdCard.Text;
        }
        else
        {
            //错误的用户类型参数
            Response.Write("错误的用户类型参数");
        }
        string user_password = clsMD5.getMd5Str("aaaaaa0");//默认密码6个a,1个数字0
        //验证账号是否已存在
        if (CheckAccountExist(user_account))
        {
            //已存在
            string _result = "拟创建的账号已存在,请确认输入。";
            Response.Write(_result);
        }
        else
        {
            //不存在
            if (CreatNewUser(user_account, user_password, user_class))
            {
                //创建成功
                txtIdCard.Text = "";
                string _result = "创建成功,请记录:\\n用户类型:" + rbl_userclass.SelectedItem.Text + "\\n账号:" + user_account + "\\n密码:aaaaaa0";
                Response.Write("<script>alert('" + _result + "');</script>");
            }
            else
            {
                //创建失败
                string _result = "创建账号失败,请稍后重试.";
                Response.Write(_result);
            }
        }
    }
    /// <summary>
    /// 创建用户账号
    /// </summary>
    /// <param name="user_account">账号</param>
    /// <param name="user_password">密码</param>
    /// <param name="user_class">用户类型(0为个人,1为企业)</param>
    /// <returns>true为创建成功,false为创建失败</returns>
    protected bool CreatNewUser(string user_account, string user_password, int user_class)
    {
        try
        {
            string str_conn = str_cnn + MapPath(str_sourcefile);
            cnn = new OleDbConnection(str_conn);
            cnn.Open();
            str_sql = "insert into tUserAccount(user_account,user_password,user_class) values('" + user_account + "','" + user_password + "'," + user_class + ")";
            cmd = new OleDbCommand(str_sql, cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
            return true;
        }
        catch (Exception)
        {
            return false;
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
}