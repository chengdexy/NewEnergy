using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.OleDb;
using CarlosAg.ExcelXmlWriter;
using System.Text;

/// <summary>
/// clsReport 的摘要说明
/// </summary>
public static class clsReport
{
    public static string getAccountById(Page Pg, string report_id)
    {
        string str_cnn = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=";
        string str_sourcefile = @"App_Data\Data.mdb";
        OleDbConnection cnn;
        OleDbCommand cmd;
        OleDbDataReader datar;
        string str_sql;

        string str_conn = str_cnn + Pg.MapPath(str_sourcefile);
        cnn = new OleDbConnection(str_conn);
        cnn.Open();
        str_sql = "select report_account from tReport where report_id='" + report_id + "'";
        cmd = new OleDbCommand(str_sql, cnn);
        datar = cmd.ExecuteReader();
        string result;
        if (datar.HasRows)
        {
            datar.Read();
            result = datar["report_account"].ToString();
        }
        else
        {
            result = "";
        }
        cnn.Close();
        return result;
    }

    /// <summary>
    /// 将指定用户的信息,填入到审核申请表中,并推送到客户端,供下载
    /// </summary>
    /// <param name="user_class">用户类型</param>
    /// <param name="report_name">名称/姓名</param>
    /// <param name="report_number">组织机构代码证号/身份证号</param>
    /// <param name="report_contact">联系人姓名/不填</param>
    /// <param name="report_phone">联系电话</param>
    /// <param name="report_mobile">联系手机号</param>
    /// <param name="report_bankcardname">户名</param>
    /// <param name="report_bankcardid">卡号</param>
    /// <param name="report_bankname">开户行</param>
    public static void PushReportUserInfoToClient(
        Page pg,
        int user_class,
        string report_name,
        string report_number,
        string report_contact,
        string report_phone,
        string report_mobile,
        string report_bankcardname,
        string report_bankcardid,
        string report_bankname)
    {
        Workbook myBook = new ExcelXmlWriter.Sample.ReportUserInfo().Generate();
        if (user_class == 1)
        {
            //单位
            myBook.Worksheets[0].Table.Rows[0].Cells[3].Data.Text = "√";
            myBook.Worksheets[0].Table.Rows[0].Cells[5].Data.Text = report_name;
            myBook.Worksheets[0].Table.Rows[0].Cells[7].Data.Text = report_number;
            myBook.Worksheets[0].Table.Rows[2].Cells[2].Data.Text = report_contact;
            myBook.Worksheets[0].Table.Rows[2].Cells[4].Data.Text = report_phone;
            myBook.Worksheets[0].Table.Rows[2].Cells[6].Data.Text = report_mobile;
        }
        else if (user_class == 0)
        {
            //个人
            myBook.Worksheets[0].Table.Rows[1].Cells[1].Data.Text = "√";
            myBook.Worksheets[0].Table.Rows[1].Cells[3].Data.Text = report_name;
            myBook.Worksheets[0].Table.Rows[1].Cells[5].Data.Text = report_number;
            myBook.Worksheets[0].Table.Rows[3].Cells[2].Data.Text = report_phone;
            myBook.Worksheets[0].Table.Rows[3].Cells[4].Data.Text = report_mobile;
        }
        else
        {
            //不合法的用户类型(不存在,或没有资格打印)
            throw new Exception("不合法的用户类型参数");
        }
        myBook.Worksheets[0].Table.Rows[4].Cells[2].Data.Text = report_bankcardname;
        myBook.Worksheets[0].Table.Rows[4].Cells[4].Data.Text = report_bankname;
        myBook.Worksheets[0].Table.Rows[4].Cells[6].Data.Text = report_bankcardid;
        //需引用CarlosAg.ExcelXmlWriter;
        //需引用System.Text;
        //-----开始对book内容编辑-----

        //-----编辑book内容结束-----
        string filename = "补贴资金申请审核表(" + report_name + ")";
        myBook.Save(pg.Response.OutputStream);
        pg.Response.AppendHeader("Content-Disposition", "Attachment; FileName=" + HttpUtility.UrlEncode(filename, Encoding.UTF8) + ".xls;");
        pg.Response.ContentEncoding = Encoding.UTF8;
        pg.Response.Charset = "UTF-8";
        pg.Response.Flush();
        pg.Response.End();
    }

    public static void PushReportCarsListToClient(Page pg, OleDbDataReader dr)
    {
        Workbook myBook = new ExcelXmlWriter.Sample.ReportCarsList().Generate();
        int row = 1;
        while (dr.Read())
        {
            //读一条
            WorksheetRow newRow = myBook.Worksheets[0].Table.Rows.Add();
            newRow.AutoFitHeight = false;
            //newRow.Index = row;
            //newRow.Cells.Add(row.ToString());
            WorksheetCell cell;
            cell = newRow.Cells.Add();
            cell.Data.Type = DataType.String;
            cell.Data.Text = row.ToString();
            cell.NamedCell.Add("Print_Area");
            //newRow.Cells.Add(dr["car_number"].ToString());
            cell = newRow.Cells.Add();
            cell.Data.Type = DataType.String;
            cell.Data.Text = dr["car_number"].ToString();
            cell.NamedCell.Add("Print_Area");
            //newRow.Cells.Add(dr["car_vin"].ToString());
            cell = newRow.Cells.Add();
            cell.Data.Type = DataType.String;
            cell.Data.Text = dr["car_vin"].ToString();
            cell.NamedCell.Add("Print_Area");
            //newRow.Cells.Add(dr["car_product"].ToString());
            cell = newRow.Cells.Add();
            cell.Data.Type = DataType.String;
            cell.Data.Text = dr["car_product"].ToString();
            cell.NamedCell.Add("Print_Area");
            //newRow.Cells.Add(dr["car_brand"].ToString());
            cell = newRow.Cells.Add();
            cell.Data.Type = DataType.String;
            cell.Data.Text = dr["car_brand"].ToString();
            cell.NamedCell.Add("Print_Area");
            //newRow.Cells.Add(dr["car_kind"].ToString());
            cell = newRow.Cells.Add();
            cell.Data.Type = DataType.String;
            cell.Data.Text = dr["car_kind"].ToString();
            cell.NamedCell.Add("Print_Area");
            //newRow.Cells.Add(dr["car_use"].ToString());
            cell = newRow.Cells.Add();
            cell.Data.Type = DataType.String;
            cell.Data.Text = dr["car_use"].ToString();
            cell.NamedCell.Add("Print_Area");
            //newRow.Cells.Add(dr["car_buydate"].ToString());
            cell = newRow.Cells.Add();
            cell.Data.Type = DataType.String;
            cell.Data.Text = Convert.ToDateTime(dr["car_buydate"]).ToShortDateString();
            cell.NamedCell.Add("Print_Area");
            //newRow.Cells.Add(dr["car_regdate"].ToString());
            cell = newRow.Cells.Add();
            cell.Data.Type = DataType.String;
            cell.Data.Text = Convert.ToDateTime(dr["car_regdate"]).ToShortDateString();
            cell.NamedCell.Add("Print_Area");
            //newRow.Cells.Add(dr["car_batkind"].ToString());
            cell = newRow.Cells.Add();
            cell.Data.Type = DataType.String;
            cell.Data.Text = dr["car_batkind"].ToString();
            cell.NamedCell.Add("Print_Area");
            //newRow.Cells.Add(dr["car_batsize"].ToString());
            cell = newRow.Cells.Add();
            cell.Data.Type = DataType.String;
            cell.Data.Text = dr["car_batsize"].ToString();
            cell.NamedCell.Add("Print_Area");

            row++;
        }
        myBook.Worksheets[0].Names[0].RefersTo = "=Sheet1!R1C1:R" + row.ToString() + "C11";
        string filename = "车辆信息情况表";
        myBook.Save(pg.Response.OutputStream);
        pg.Response.AppendHeader("Content-Disposition", "Attachment; FileName=" + HttpUtility.UrlEncode(filename, Encoding.UTF8) + ".xls;");
        pg.Response.ContentEncoding = Encoding.UTF8;
        pg.Response.Charset = "UTF-8";
        pg.Response.Flush();
        pg.Response.End();
    }
}