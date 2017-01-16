using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.OleDb;

/// <summary>
/// clsNotice 的摘要说明
/// </summary>
public static class clsNotice
{
    public static void SendNotice(Page Pg, string _to, string _content)
    {
        string Nfrom = clsUser.getUserName(Pg.Session["user_account"].ToString(), Pg);
        string Nto = _to;
        string Ndate = DateTime.Now.ToString();
        string Ncontent = _content;
        bool Nchecked = false;

        string str_cnn = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=";
        string str_sourcefile = @"App_Data\Data.mdb";
        OleDbConnection cnn;
        OleDbCommand cmd;
        string str_sql;

        string str_conn = str_cnn + Pg.MapPath(str_sourcefile);
        cnn = new OleDbConnection(str_conn);
        cnn.Open();
        str_sql = string.Format("insert into tNotice(notice_from,notice_to,notice_date,notice_content,notice_checked)" +
            " values('{0}','{1}',#{2}#,'{3}',{4})", Nfrom, Nto, Ndate, Ncontent, Nchecked.ToString());
        cmd = new OleDbCommand(str_sql, cnn);
        cmd.ExecuteNonQuery();
        cnn.Close();

    }
}