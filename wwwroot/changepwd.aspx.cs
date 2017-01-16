using System;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class changepwd : System.Web.UI.Page
{
    string str_cnn = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=";
    string str_sourcefile = @"App_Data\Data.mdb";
    OleDbConnection cnn;
    OleDbCommand cmd;
    OleDbDataReader datar;
    string str_sql;

    protected void Page_Load(object sender, EventArgs e)
    {
        div_find_pwd.Visible = false;
        RequiredFieldValidator4.Enabled = false;
        RequiredFieldValidator5.Enabled = false;
        if (!IsPostBack)
        {
            //首次展示页面
            if (Session["user_account"] == null || Session["user_class"] == null)
            {
                //未登录
                Response.Redirect("index.aspx");
                return;
            }
            //检验用户类型
            string user_account = Session["user_account"].ToString();
            int user_class = Convert.ToInt32(Session["user_class"]);
            if (user_class == 0 || user_class == 1)
            {
                //用户
                if (clsUser.isNewUser(user_account, this))
                {
                    //是新用户
                    btnCancel.Enabled = false;
                    btnCancel.ToolTip = "新用户必须修改默认密码才能使用申报系统.";
                    div_find_pwd.Visible = true;
                    RequiredFieldValidator4.Enabled = true;
                    RequiredFieldValidator5.Enabled = true;
                }
                else
                {
                    //老用户
                    //cnn.Close(); 2016年6月22日15:03:04 数据库已关闭,固注释此处
                }
            }
            else if (user_class == 2 || user_class == 3)
            {
                //管理
            }
            else
            {
                //错误:不存在的用户类型
                Response.Redirect("index.aspx");
            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        int user_class = Convert.ToInt32(Session["user_class"]);
        if (user_class == 0 || user_class == 1)
        {
            Response.Redirect("userindex.aspx");
        }
        else if (user_class == 2 || user_class == 3)
        {
            Response.Redirect("manaindex.aspx");
        }
        else
        {
            //错误:不存在的用户类型
            Response.Redirect("index.aspx");
        }
    }

    protected void cvSorPassword_ServerValidate(object source, ServerValidateEventArgs args)
    {
        string tblName = null;
        int user_class = Convert.ToInt32(Session["user_class"]);
        if (user_class == 0 || user_class == 1)
        {
            tblName = "tUserAccount";
        }
        else if (user_class == 2 || user_class == 3)
        {
            tblName = "tAdmin";
        }
        else
        {
            //错误:不存在的用户类型
            Response.Redirect("index.aspx");
            return;
        }
        string str_conn = str_cnn + MapPath(str_sourcefile);
        cnn = new OleDbConnection(str_conn);
        cnn.Open();
        str_sql = "select user_password from " + tblName + " where user_account='" + Session["user_account"].ToString() + "'";
        cmd = new OleDbCommand(str_sql, cnn);
        datar = cmd.ExecuteReader();
        if (datar.HasRows)
        {
            //有数据则比对
            datar.Read();
            if (datar["user_password"].ToString() == clsMD5.getMd5Str(txtSorPassword.Text))
            {
                //一致
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
        else
        {
            //没数据说明 错误:账号不存在
            Response.Redirect("index.aspx");
        }
        cnn.Close();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        //Page.Validate();
        if (!IsValid)
        {
            return;
        }
        string newPassword = clsMD5.getMd5Str(txtNewPassword.Text);
        string findpwd_q = txtFindpwd_q.Text;
        string findpwd_a = txtFindpwd_a.Text;
        string str_conn = str_cnn + MapPath(str_sourcefile);
        cnn = new OleDbConnection(str_conn);
        cnn.Open();
        if (clsUser.isNewUser(Session["user_account"].ToString(), this) == true)
        {
            //新用户
            str_sql = "update tUserAccount set user_password='" + newPassword + "', user_findpwd_q='" + findpwd_q + "', user_findpwd_a='" + findpwd_a + "' where user_account='" + Session["user_account"].ToString() + "'";
        }
        else
        {
            //老用户或管理
            string tblName = null;
            int user_class = Convert.ToInt32(Session["user_class"]);
            if (user_class == 0 || user_class == 1)
            {
                tblName = "tUserAccount";
            }
            else if (user_class == 2 || user_class == 3)
            {
                tblName = "tAdmin";
            }
            else
            {
                //错误:不存在的用户类型
                Response.Redirect("index.aspx");
                return;
            }
            str_sql = "update " + tblName + " set user_password='" + newPassword + "' where user_account='" + Session["user_account"].ToString() + "'";
        }
        cmd = new OleDbCommand(str_sql, cnn);
        cmd.ExecuteNonQuery();
        cnn.Close();
        if (clsUser.isNewUser(Session["user_account"].ToString(), this))
        {
            //新用户跳转到补全信息
            Response.Redirect("edituser.aspx");
        }
        else
        {
            //老用户或管理
            int user_class = Convert.ToInt32(Session["user_class"]);
            if (user_class == 0 || user_class == 1)
            {
                //跳转到用户首页
                Response.Redirect("userindex.aspx");
            }
            else if (user_class == 2 || user_class == 3)
            {
                //跳转到管理首页
                Response.Redirect("manaindex.aspx");
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