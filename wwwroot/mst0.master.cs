using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class mst0 : System.Web.UI.MasterPage
{
    string str_cnn = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=";
    string str_sourcefile = @"App_Data\Data.mdb";
    OleDbConnection cnn;
    OleDbCommand cmd;
    OleDbDataReader datar;
    string str_sql;

    protected void Page_Load(object sender, EventArgs e)
    {
        string user_account;
        int user_class;
        if (!IsPostBack)
        {
            //首次展示
            if (Session["user_account"] == null || Session["user_class"] == null || Session["user_district"] == null)
            {
                //未登录
                Response.Redirect("index.aspx");
                return;
            }
            user_class = Convert.ToInt32(Session["user_class"]);
            string sql = null;
            switch (user_class)
            {
                case 0://个人
                    sql = "select * from tMenu where m0_c0_visible=true order by m0_order desc";
                    adsMenu.SelectCommand = sql;
                    blMenu.DataTextField = "m0_c0_text";
                    blMenu.DataBind();
                    break;
                case 1://企业
                    sql = "select * from tMenu where m0_c1_visible=true order by m0_order desc";
                    adsMenu.SelectCommand = sql;
                    blMenu.DataTextField = "m0_c1_text";
                    blMenu.DataBind();
                    break;
                case 2://县级
                    sql = "select * from tMenu where m0_c2_visible=true order by m0_order desc";
                    adsMenu.SelectCommand = sql;
                    blMenu.DataTextField = "m0_c2_text";
                    blMenu.DataBind();
                    break;
                case 3://市级
                    sql = "select * from tMenu where m0_c3_visible=true order by m0_order desc";
                    adsMenu.SelectCommand = sql;
                    blMenu.DataTextField = "m0_c3_text";
                    blMenu.DataBind();
                    break;
                default:
                    break;
            }
        }
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("index.aspx");
    }
}
