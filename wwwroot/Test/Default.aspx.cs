using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class Test_Default : System.Web.UI.Page
{

    string str_cnn = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=";
    string str_sourcefile = @"~\App_Data\Data.mdb";
    OleDbConnection cnn;
    OleDbCommand cmd;
    OleDbDataReader datar;
    string str_sql;
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        string str_conn = str_cnn + MapPath(str_sourcefile);
        cnn = new OleDbConnection(str_conn);
        cnn.Open();
        str_sql = "update tUserAccount set user_password='" + clsMD5.getMd5Str("aaaaaa0") + "'";
        cmd = new OleDbCommand(str_sql, cnn);
        cmd.ExecuteNonQuery();
        cnn.Close();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string str_conn = str_cnn + MapPath(str_sourcefile);
        cnn = new OleDbConnection(str_conn);
        cnn.Open();
        str_sql = "update tAdmin set user_password='" + clsMD5.getMd5Str("aaaaaa0") + "'";
        cmd = new OleDbCommand(str_sql, cnn);
        cmd.ExecuteNonQuery();
        cnn.Close();
    }
}