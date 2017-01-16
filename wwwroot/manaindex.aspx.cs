using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class manaindex : System.Web.UI.Page
{
    string str_cnn = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=";
    string str_sourcefile = @"App_Data\Data.mdb";
    OleDbConnection cnn;
    OleDbCommand cmd;
    OleDbDataReader datar;
    string str_sql;

    protected void Page_Load(object sender, EventArgs e)
    {
        //首次展示验证用户身份
        if (!IsPostBack)
        {
            string sql = null;
            if (Session["user_account"] == null || Session["user_class"] == null || Session["user_district"] == null)
            {
                //未登录
                Response.Redirect("index.aspx");
                return;
            }
            else
            {
                //已登录
                int user_class = Convert.ToInt32(Session["user_class"]);
                if (user_class < 0 || user_class > 3)
                {
                    //不合法的class
                    Session.Clear();
                    Response.Redirect("index.aspx", true);
                }
                switch (user_class)
                {
                    case 0:
                    case 1:
                        //用户
                        Response.Redirect("userindex.aspx", true);
                        break;
                    case 2:
                        //县级
                        sql = "select count(*) from tReport where report_district='" + Session["user_district"].ToString() + "' and (report_state='已上报' or report_state='网上初审通过')";
                        break;
                    case 3:
                        //市级
                        sql = "select count(*) from tReport where report_state='现场复审通过'";
                        break;
                    default:
                        break;
                }
                string str_conn = str_cnn + MapPath(str_sourcefile);
                cnn = new OleDbConnection(str_conn);
                cnn.Open();
                if (string.IsNullOrEmpty(sql))
                {
                    cnn.Close();
                    Session.Clear();
                    Response.Redirect("index.aspx");
                    return;
                }
                str_sql = sql;
                cmd = new OleDbCommand(str_sql, cnn);
                datar = cmd.ExecuteReader();
                datar.Read();
                lbReportCount.Text = datar[0].ToString();
                cnn.Close();
            }
        }
    }
}