using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Web.UI;

/// <summary>
/// clsUser 的摘要说明
/// </summary>
public static class clsUser
{
    public static bool isNewUser(string user_account, Page pg)
    {
        //如果不是管理账号,才进行以下操作
        if (isAdmin(user_account, pg))
        {
            //是管理
            return false;
        }
        else
        {
            //不是管理
            string str_cnn = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=";
            string str_sourcefile = @"App_Data\Data.mdb";
            OleDbConnection cnn;
            OleDbCommand cmd;
            OleDbDataReader datar;
            string str_sql;
            string str_conn = str_cnn + pg.MapPath(str_sourcefile);
            cnn = new OleDbConnection(str_conn);
            cnn.Open();
            str_sql = "select user_first_load from tUserAccount where user_account='" + user_account + "'";
            cmd = new OleDbCommand(str_sql, cnn);
            datar = cmd.ExecuteReader();
            bool result;
            if (datar.HasRows)
            {
                datar.Read();
                result = Convert.ToBoolean(datar["user_first_load"]);
            }
            else
            {
                throw new Exception("未找到账号为" + user_account + "的用户.");
            }
            cnn.Close();
            return result;
        }

    }

    private static bool isAdmin(string user_account, Page pg)
    {
        string str_cnn = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=";
        string str_sourcefile = @"App_Data\Data.mdb";
        OleDbConnection cnn;
        OleDbCommand cmd;
        OleDbDataReader datar;
        string str_sql; string str_conn = str_cnn + pg.MapPath(str_sourcefile);
        cnn = new OleDbConnection(str_conn);
        cnn.Open();
        str_sql = "select * from tAdmin where user_account='" + user_account + "'";
        cmd = new OleDbCommand(str_sql, cnn);
        datar = cmd.ExecuteReader();
        bool _result = datar.HasRows;
        cnn.Close();
        return _result;
    }

    public static int getUserClass(string user_account, Page pg)
    {
        string str_cnn = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=";
        string str_sourcefile = @"App_Data\Data.mdb";
        OleDbConnection cnn;
        OleDbCommand cmd;
        OleDbDataReader datar;
        string str_sql;

        string str_conn = str_cnn + pg.MapPath(str_sourcefile);
        cnn = new OleDbConnection(str_conn);
        cnn.Open();
        str_sql = "select user_class from tUserAccount where user_account='" + user_account + "'";
        cmd = new OleDbCommand(str_sql, cnn);
        datar = cmd.ExecuteReader();
        int user_class;
        if (datar.HasRows)
        {
            datar.Read();
            user_class = Convert.ToInt32(datar["user_class"]);
        }
        else
        {
            throw new Exception("用户不存在");
        }
        cnn.Close();
        return user_class;
    }

    /*
        2016年6月22日11:36:02
    */
    public static string getUserName(string user_account, Page pg)
    {
        int user_class = Convert.ToInt32(pg.Session["user_class"]);
        string tbl = null, fld = null;
        string sql;
        switch (user_class)
        {
            case 0://个人
                tbl = "tUserAccount";
                fld = "user_username";
                break;
            case 1://企业
                tbl = "tUserAccount";
                fld = "user_companyname";
                break;
            case 2://县级
            case 3://市级
                tbl = "tAdmin";
                fld = "user_username";
                break;
            default:
                //其他:不存在的用户类型
                throw new Exception("不存在的用户类型");
        }
        sql = "select " + fld + " from " + tbl + " where user_account='" + user_account + "'";
        string str_cnn = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=";
        string str_sourcefile = @"App_Data\Data.mdb";
        OleDbConnection cnn;
        OleDbCommand cmd;
        OleDbDataReader datar;
        string str_conn = str_cnn + pg.MapPath(str_sourcefile);
        cnn = new OleDbConnection(str_conn);
        cnn.Open();
        cmd = new OleDbCommand(sql, cnn);
        datar = cmd.ExecuteReader();
        if (datar.HasRows)
        {
            //有数据
            datar.Read();
            string result = datar[fld].ToString();
            cnn.Close();
            return result;
        }
        else
        {
            //无数据
            cnn.Close();
            throw new Exception("不存在的用户名");
        }
    }
}