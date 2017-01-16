namespace ExcelXmlWriter.Sample
{
    using System;
    using System.Xml;
    using CarlosAg.ExcelXmlWriter;


    public class ReportUserInfo
    {

        public Workbook Generate()
        {
            Workbook book = new Workbook();
            // -----------------------------------------------
            //  Properties
            // -----------------------------------------------
            book.Properties.Author = "Mr.X";
            book.Properties.LastAuthor = "Mr.X";
            book.Properties.Created = new System.DateTime(2016, 6, 20, 10, 9, 20, 0);
            book.Properties.LastSaved = new System.DateTime(2016, 6, 24, 0, 25, 31, 0);
            book.Properties.Version = "16.00";
            book.ExcelWorkbook.WindowHeight = 9144;
            book.ExcelWorkbook.WindowWidth = 23040;
            book.ExcelWorkbook.WindowTopX = 0;
            book.ExcelWorkbook.WindowTopY = 0;
            book.ExcelWorkbook.ProtectWindows = false;
            book.ExcelWorkbook.ProtectStructure = false;
            // -----------------------------------------------
            //  Generate Styles
            // -----------------------------------------------
            this.GenerateStyles(book.Styles);
            // -----------------------------------------------
            //  Generate Sheet1 Worksheet
            // -----------------------------------------------
            this.GenerateWorksheetSheet1(book.Worksheets);
            //book.Save(filename);
            return book;
        }

        private void GenerateStyles(WorksheetStyleCollection styles)
        {
            // -----------------------------------------------
            //  Default
            // -----------------------------------------------
            WorksheetStyle Default = styles.Add("Default");
            Default.Name = "Normal";
            Default.Font.FontName = "等线";
            Default.Font.Size = 11;
            Default.Font.Color = "#000000";
            Default.Alignment.Vertical = StyleVerticalAlignment.Center;
            // -----------------------------------------------
            //  m458739312
            // -----------------------------------------------
            WorksheetStyle m458739312 = styles.Add("m458739312");
            m458739312.Font.FontName = "宋体";
            m458739312.Font.Size = 16;
            m458739312.Font.Color = "#000000";
            m458739312.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            m458739312.Alignment.Vertical = StyleVerticalAlignment.Center;
            m458739312.Alignment.WrapText = true;
            m458739312.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            m458739312.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            m458739312.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            m458739312.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  m458739332
            // -----------------------------------------------
            WorksheetStyle m458739332 = styles.Add("m458739332");
            m458739332.Font.FontName = "宋体";
            m458739332.Font.Size = 14;
            m458739332.Font.Color = "#000000";
            m458739332.Alignment.Horizontal = StyleHorizontalAlignment.Left;
            m458739332.Alignment.Vertical = StyleVerticalAlignment.Center;
            m458739332.Alignment.WrapText = true;
            m458739332.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            m458739332.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            m458739332.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  m458739352
            // -----------------------------------------------
            WorksheetStyle m458739352 = styles.Add("m458739352");
            m458739352.Font.FontName = "宋体";
            m458739352.Font.Size = 14;
            m458739352.Font.Color = "#000000";
            m458739352.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            m458739352.Alignment.Vertical = StyleVerticalAlignment.Center;
            m458739352.Alignment.WrapText = true;
            m458739352.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            m458739352.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            m458739352.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  m458740976
            // -----------------------------------------------
            WorksheetStyle m458740976 = styles.Add("m458740976");
            m458740976.Font.FontName = "宋体";
            m458740976.Font.Size = 14;
            m458740976.Font.Color = "#000000";
            m458740976.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            m458740976.Alignment.Vertical = StyleVerticalAlignment.Center;
            m458740976.Alignment.WrapText = true;
            m458740976.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            m458740976.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            m458740976.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            m458740976.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  m458740996
            // -----------------------------------------------
            WorksheetStyle m458740996 = styles.Add("m458740996");
            m458740996.Font.FontName = "宋体";
            m458740996.Font.Size = 16;
            m458740996.Font.Color = "#000000";
            m458740996.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            m458740996.Alignment.Vertical = StyleVerticalAlignment.Center;
            m458740996.Alignment.WrapText = true;
            m458740996.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            m458740996.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            m458740996.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            m458740996.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  m458741016
            // -----------------------------------------------
            WorksheetStyle m458741016 = styles.Add("m458741016");
            m458741016.Font.FontName = "宋体";
            m458741016.Font.Size = 14;
            m458741016.Font.Color = "#000000";
            m458741016.Alignment.Horizontal = StyleHorizontalAlignment.Left;
            m458741016.Alignment.Vertical = StyleVerticalAlignment.Center;
            m458741016.Alignment.WrapText = true;
            m458741016.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            m458741016.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            m458741016.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  m458741036
            // -----------------------------------------------
            WorksheetStyle m458741036 = styles.Add("m458741036");
            m458741036.Font.FontName = "宋体";
            m458741036.Font.Size = 14;
            m458741036.Font.Color = "#000000";
            m458741036.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            m458741036.Alignment.Vertical = StyleVerticalAlignment.Center;
            m458741036.Alignment.WrapText = true;
            m458741036.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            m458741036.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            m458741036.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  m458741056
            // -----------------------------------------------
            WorksheetStyle m458741056 = styles.Add("m458741056");
            m458741056.Font.FontName = "宋体";
            m458741056.Font.Size = 16;
            m458741056.Font.Color = "#000000";
            m458741056.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            m458741056.Alignment.Vertical = StyleVerticalAlignment.Center;
            m458741056.Alignment.WrapText = true;
            m458741056.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            m458741056.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            m458741056.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            m458741056.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  m458741076
            // -----------------------------------------------
            WorksheetStyle m458741076 = styles.Add("m458741076");
            m458741076.Font.FontName = "宋体";
            m458741076.Font.Size = 14;
            m458741076.Font.Color = "#000000";
            m458741076.Alignment.Horizontal = StyleHorizontalAlignment.Left;
            m458741076.Alignment.Vertical = StyleVerticalAlignment.Center;
            m458741076.Alignment.WrapText = true;
            m458741076.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            m458741076.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            m458741076.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  m458741096
            // -----------------------------------------------
            WorksheetStyle m458741096 = styles.Add("m458741096");
            m458741096.Font.FontName = "宋体";
            m458741096.Font.Size = 14;
            m458741096.Font.Color = "#000000";
            m458741096.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            m458741096.Alignment.Vertical = StyleVerticalAlignment.Center;
            m458741096.Alignment.WrapText = true;
            m458741096.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            m458741096.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            m458741096.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  m458737648
            // -----------------------------------------------
            WorksheetStyle m458737648 = styles.Add("m458737648");
            m458737648.Font.FontName = "宋体";
            m458737648.Font.Size = 16;
            m458737648.Font.Color = "#000000";
            m458737648.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            m458737648.Alignment.Vertical = StyleVerticalAlignment.Center;
            m458737648.Alignment.WrapText = true;
            m458737648.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            m458737648.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            m458737648.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            m458737648.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  m458737668
            // -----------------------------------------------
            WorksheetStyle m458737668 = styles.Add("m458737668");
            m458737668.Font.FontName = "宋体";
            m458737668.Font.Size = 14;
            m458737668.Font.Color = "#000000";
            m458737668.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            m458737668.Alignment.Vertical = StyleVerticalAlignment.Center;
            m458737668.Alignment.WrapText = true;
            m458737668.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            m458737668.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            m458737668.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            m458737668.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  m458737688
            // -----------------------------------------------
            WorksheetStyle m458737688 = styles.Add("m458737688");
            m458737688.Font.FontName = "宋体";
            m458737688.Font.Size = 14;
            m458737688.Font.Color = "#000000";
            m458737688.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            m458737688.Alignment.Vertical = StyleVerticalAlignment.Center;
            m458737688.Alignment.WrapText = true;
            m458737688.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            m458737688.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            m458737688.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            m458737688.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  m458737708
            // -----------------------------------------------
            WorksheetStyle m458737708 = styles.Add("m458737708");
            m458737708.Font.FontName = "宋体";
            m458737708.Font.Size = 14;
            m458737708.Font.Color = "#000000";
            m458737708.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            m458737708.Alignment.Vertical = StyleVerticalAlignment.Center;
            m458737708.Alignment.WrapText = true;
            m458737708.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            m458737708.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            m458737708.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            m458737708.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  m458737728
            // -----------------------------------------------
            WorksheetStyle m458737728 = styles.Add("m458737728");
            m458737728.Font.FontName = "宋体";
            m458737728.Font.Size = 16;
            m458737728.Font.Color = "#000000";
            m458737728.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            m458737728.Alignment.Vertical = StyleVerticalAlignment.Center;
            m458737728.Alignment.WrapText = true;
            m458737728.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            m458737728.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            m458737728.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            m458737728.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  m458737748
            // -----------------------------------------------
            WorksheetStyle m458737748 = styles.Add("m458737748");
            m458737748.Font.FontName = "宋体";
            m458737748.Font.Size = 14;
            m458737748.Font.Color = "#000000";
            m458737748.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            m458737748.Alignment.Vertical = StyleVerticalAlignment.Center;
            m458737748.Alignment.WrapText = true;
            m458737748.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            m458737748.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            m458737748.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            m458737748.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  m458737768
            // -----------------------------------------------
            WorksheetStyle m458737768 = styles.Add("m458737768");
            m458737768.Font.FontName = "宋体";
            m458737768.Font.Size = 14;
            m458737768.Font.Color = "#000000";
            m458737768.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            m458737768.Alignment.Vertical = StyleVerticalAlignment.Center;
            m458737768.Alignment.WrapText = true;
            m458737768.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            m458737768.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            m458737768.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            m458737768.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  m458737788
            // -----------------------------------------------
            WorksheetStyle m458737788 = styles.Add("m458737788");
            m458737788.Font.FontName = "宋体";
            m458737788.Font.Size = 14;
            m458737788.Font.Color = "#000000";
            m458737788.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            m458737788.Alignment.Vertical = StyleVerticalAlignment.Center;
            m458737788.Alignment.WrapText = true;
            m458737788.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            m458737788.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            m458737788.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            m458737788.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  m458737808
            // -----------------------------------------------
            WorksheetStyle m458737808 = styles.Add("m458737808");
            m458737808.Font.FontName = "宋体";
            m458737808.Font.Size = 14;
            m458737808.Font.Color = "#000000";
            m458737808.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            m458737808.Alignment.Vertical = StyleVerticalAlignment.Center;
            m458737808.Alignment.WrapText = true;
            m458737808.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            m458737808.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            m458737808.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            m458737808.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  s62
            // -----------------------------------------------
            WorksheetStyle s62 = styles.Add("s62");
            s62.Font.FontName = "宋体";
            s62.Font.Size = 16;
            s62.Font.Color = "#000000";
            s62.Alignment.Vertical = StyleVerticalAlignment.Center;
            s62.Alignment.WrapText = true;
            // -----------------------------------------------
            //  s63
            // -----------------------------------------------
            WorksheetStyle s63 = styles.Add("s63");
            s63.Font.FontName = "宋体";
            s63.Font.Size = 16;
            s63.Font.Color = "#000000";
            s63.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            s63.Alignment.Vertical = StyleVerticalAlignment.Center;
            s63.Alignment.WrapText = true;
            s63.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            s63.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            s63.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            s63.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  s69
            // -----------------------------------------------
            WorksheetStyle s69 = styles.Add("s69");
            s69.Font.FontName = "宋体";
            s69.Font.Size = 14;
            s69.Font.Color = "#000000";
            s69.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            s69.Alignment.Vertical = StyleVerticalAlignment.Center;
            s69.Alignment.WrapText = true;
            s69.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            s69.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            s69.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            s69.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  s75
            // -----------------------------------------------
            WorksheetStyle s75 = styles.Add("s75");
            s75.Font.FontName = "宋体";
            s75.Font.Size = 14;
            s75.Font.Color = "#000000";
            s75.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            s75.Alignment.Vertical = StyleVerticalAlignment.Center;
            s75.Alignment.WrapText = true;
            s75.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            s75.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            s75.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  s76
            // -----------------------------------------------
            WorksheetStyle s76 = styles.Add("s76");
            s76.Font.FontName = "宋体";
            s76.Font.Size = 14;
            s76.Font.Color = "#000000";
            s76.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            s76.Alignment.Vertical = StyleVerticalAlignment.Center;
            s76.Alignment.WrapText = true;
            s76.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            s76.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            s76.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  s93
            // -----------------------------------------------
            WorksheetStyle s93 = styles.Add("s93");
            s93.Font.FontName = "宋体";
            s93.Font.Size = 14;
            s93.Font.Color = "#000000";
            s93.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            s93.Alignment.ShrinkToFit = true;
            s93.Alignment.Vertical = StyleVerticalAlignment.Center;
            s93.Alignment.WrapText = true;
            s93.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            s93.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            s93.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            s93.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
        }

        private void GenerateWorksheetSheet1(WorksheetCollection sheets)
        {
            Worksheet sheet = sheets.Add("Sheet1");
            sheet.Table.DefaultRowHeight = 13.8F;
            sheet.Table.ExpandedColumnCount = 9;
            sheet.Table.ExpandedRowCount = 11;
            sheet.Table.FullColumns = 1;
            sheet.Table.FullRows = 1;
            sheet.Table.Columns.Add(103);
            sheet.Table.Columns.Add(108);
            sheet.Table.Columns.Add(58);
            sheet.Table.Columns.Add(24);
            sheet.Table.Columns.Add(40);
            sheet.Table.Columns.Add(103);
            sheet.Table.Columns.Add(103);
            sheet.Table.Columns.Add(41);
            sheet.Table.Columns.Add(103);
            // -----------------------------------------------
            WorksheetRow Row0 = sheet.Table.Rows.Add();
            Row0.Height = 39;
            Row0.AutoFitHeight = false;
            WorksheetCell cell;
            cell = Row0.Cells.Add();
            cell.StyleID = "m458737648";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "申请人信息";
            cell.MergeDown = 1;
            cell = Row0.Cells.Add();
            cell.StyleID = "m458737668";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "申请人";
            cell.MergeDown = 1;
            Row0.Cells.Add("单位", DataType.String, "s75");
            cell = Row0.Cells.Add();
            cell.StyleID = "s76";
            Row0.Cells.Add("名称", DataType.String, "s69");
            cell = Row0.Cells.Add();
            cell.StyleID = "s69";
            Row0.Cells.Add("单位组织机构代码证编号", DataType.String, "s69");
            cell = Row0.Cells.Add();
            cell.StyleID = "m458737688";
            cell.MergeAcross = 1;
            // -----------------------------------------------
            WorksheetRow Row1 = sheet.Table.Rows.Add();
            Row1.Height = 36;
            Row1.AutoFitHeight = false;
            cell = Row1.Cells.Add();
            cell.StyleID = "s75";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "个人";
            cell.Index = 3;
            cell = Row1.Cells.Add();
            cell.StyleID = "s76";
            Row1.Cells.Add("姓名", DataType.String, "s69");
            cell = Row1.Cells.Add();
            cell.StyleID = "s69";
            Row1.Cells.Add("身份证号码", DataType.String, "s69");
            cell = Row1.Cells.Add();
            cell.StyleID = "m458737708";
            cell.MergeAcross = 1;
            // -----------------------------------------------
            WorksheetRow Row2 = sheet.Table.Rows.Add();
            Row2.Height = 36;
            Row2.AutoFitHeight = false;
            cell = Row2.Cells.Add();
            cell.StyleID = "m458737728";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "申请人联系方式";
            cell.MergeDown = 1;
            Row2.Cells.Add("单位联系人姓名", DataType.String, "s69");
            cell = Row2.Cells.Add();
            cell.StyleID = "m458737748";
            cell.MergeAcross = 2;
            Row2.Cells.Add("固定电话", DataType.String, "s69");
            cell = Row2.Cells.Add();
            cell.StyleID = "s69";
            Row2.Cells.Add("手机", DataType.String, "s69");
            cell = Row2.Cells.Add();
            cell.StyleID = "s69";
            // -----------------------------------------------
            WorksheetRow Row3 = sheet.Table.Rows.Add();
            Row3.Height = 36;
            Row3.AutoFitHeight = false;
            cell = Row3.Cells.Add();
            cell.StyleID = "s69";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "个人联系电话";
            cell.Index = 2;
            cell = Row3.Cells.Add();
            cell.StyleID = "m458737768";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "固定电话";
            cell.MergeAcross = 1;
            cell = Row3.Cells.Add();
            cell.StyleID = "m458737788";
            cell.MergeAcross = 1;
            Row3.Cells.Add("手机", DataType.String, "s69");
            cell = Row3.Cells.Add();
            cell.StyleID = "m458737808";
            cell.MergeAcross = 1;
            // -----------------------------------------------
            WorksheetRow Row4 = sheet.Table.Rows.Add();
            Row4.Height = 36;
            Row4.AutoFitHeight = false;
            Row4.Cells.Add("银行账户信息", DataType.String, "s63");
            Row4.Cells.Add("户名", DataType.String, "s93");
            cell = Row4.Cells.Add();
            cell.StyleID = "m458740976";
            cell.MergeAcross = 2;
            Row4.Cells.Add("开户银行", DataType.String, "s69");
            cell = Row4.Cells.Add();
            cell.StyleID = "s69";
            Row4.Cells.Add("账号", DataType.String, "s69");
            cell = Row4.Cells.Add();
            cell.StyleID = "s69";
            // -----------------------------------------------
            WorksheetRow Row5 = sheet.Table.Rows.Add();
            Row5.Height = 76;
            Row5.AutoFitHeight = false;
            cell = Row5.Cells.Add();
            cell.StyleID = "m458740996";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "申请人声明";
            cell.MergeDown = 1;
            cell = Row5.Cells.Add();
            cell.StyleID = "m458741016";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "　　此申请报告内容由本单位（个人）______________提供，仅限用于承德市新能源汽车购置补贴事宜。本单位（个人）承诺此申请报告内容真实合法。如有不实，本单" +
                "位（个人）承担包括但不限于返回获得的购置补贴和接受责任追究等法律责任。";
            cell.MergeAcross = 7;
            // -----------------------------------------------
            WorksheetRow Row6 = sheet.Table.Rows.Add();
            Row6.Height = 36;
            Row6.AutoFitHeight = false;
            cell = Row6.Cells.Add();
            cell.StyleID = "m458741036";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "声明人（单位公章、法人代表签字、个人签字）：　　201  年  月  日";
            cell.Index = 2;
            cell.MergeAcross = 7;
            // -----------------------------------------------
            WorksheetRow Row7 = sheet.Table.Rows.Add();
            Row7.Height = 61;
            Row7.AutoFitHeight = false;
            cell = Row7.Cells.Add();
            cell.StyleID = "m458741056";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "县区工信局初审意见";
            cell.MergeDown = 1;
            cell = Row7.Cells.Add();
            cell.StyleID = "m458741076";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "（核查公告目录，核定车辆品牌、型号、车牌号、注册登记日期，核定车辆数量，核定补贴数额等）";
            cell.MergeAcross = 7;
            // -----------------------------------------------
            WorksheetRow Row8 = sheet.Table.Rows.Add();
            Row8.Height = 36;
            Row8.AutoFitHeight = false;
            cell = Row8.Cells.Add();
            cell.StyleID = "m458741096";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "经办人：　　　　审核人：　　　　公章　　　　201   年   月   日";
            cell.Index = 2;
            cell.MergeAcross = 7;
            // -----------------------------------------------
            WorksheetRow Row9 = sheet.Table.Rows.Add();
            Row9.Height = 72;
            Row9.AutoFitHeight = false;
            cell = Row9.Cells.Add();
            cell.StyleID = "m458739312";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "市新能源汽车推广应用领导小组办公室审核意见";
            cell.MergeDown = 1;
            cell = Row9.Cells.Add();
            cell.StyleID = "m458739332";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "（核查公告目录，核定车辆品牌、型号、车牌号、注册登记日期，核定车辆数量，核定补贴数额等）";
            cell.MergeAcross = 7;
            // -----------------------------------------------
            WorksheetRow Row10 = sheet.Table.Rows.Add();
            Row10.Height = 36;
            Row10.AutoFitHeight = false;
            cell = Row10.Cells.Add();
            cell.StyleID = "m458739352";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "经办人：　　　　审核人：　　　　公章　　　　201   年   月   日";
            cell.Index = 2;
            cell.MergeAcross = 7;
            // -----------------------------------------------
            //  Options
            // -----------------------------------------------
            sheet.Options.Selected = true;
            sheet.Options.FitToPage = true;
            sheet.Options.ProtectObjects = false;
            sheet.Options.ProtectScenarios = false;
            sheet.Options.PageSetup.Layout.Orientation = Orientation.Landscape;
            sheet.Options.PageSetup.Header.Data = "&C&\"宋体,加粗\"&20承德市新能源汽车推广应用补贴资金申请审核表";
            sheet.Options.PageSetup.Header.Margin = 0.5905512F;
            sheet.Options.PageSetup.Footer.Margin = 0F;
            sheet.Options.PageSetup.PageMargins.Bottom = 0.1968504F;
            sheet.Options.PageSetup.PageMargins.Left = 0.7086614F;
            sheet.Options.PageSetup.PageMargins.Right = 0.7086614F;
            sheet.Options.PageSetup.PageMargins.Top = 1.181102F;
            sheet.Options.Print.PaperSizeIndex = 9;
            sheet.Options.Print.VerticalResolution = 0;
            sheet.Options.Print.ValidPrinterInfo = true;
        }
    }
}
