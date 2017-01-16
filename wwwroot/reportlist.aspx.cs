using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class reportlist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //首次展示
            //获取session
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
        int user_class = Convert.ToInt32(Session["user_class"]);
        string user_account = Session["user_account"].ToString();
        string user_district = Session["user_district"].ToString();
        //判断身份,构造查询语句
        string ads_sql = null;
        if (user_class == 1 || user_class == 0)
        {
            //个人或企业用户
            ads_sql = "select * from tReport where report_account='" + user_account + "' and report_class=" + user_class;
        }
        else if (user_class == 2)
        {
            //县级监管
            ads_sql = "select * from tReport where report_district='" + user_district + "' and report_state<>'未上报' and report_state<>'未通过'";
        }
        else if (user_class == 3)
        {
            //市级监管
            ads_sql = "select * from tReport where report_state='现场复审通过' or report_state='市级终审通过'";
        }
        else
        {
            //其他:错误的用户级别码
            Response.Redirect("index.aspx");
            return;
        }
        //绑定listview
        adsReport.SelectCommand = ads_sql;
        ListView1.DataBind();
    }
}