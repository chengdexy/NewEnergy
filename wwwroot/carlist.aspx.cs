using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class carlist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["user_account"] == null || Session["user_class"] == null || Session["user_district"] == null)
            {
                //未登录
                Response.Redirect("index.aspx");
                return;
            }
            else if (string.IsNullOrEmpty(Session["user_district"].ToString()))
            {
                //如果是第一次登录系统
                Response.Redirect("userindex.aspx");
                return;
            }
        }
    }
}