namespace ExcelXmlWriter.Sample
{
    using System;
    using System.Xml;
    using CarlosAg.ExcelXmlWriter;


    public class ReportCarsList
    {

        public Workbook Generate()
        {
            Workbook book = new Workbook();
            // -----------------------------------------------
            //  Properties
            // -----------------------------------------------
            book.Properties.Author = "Mr.X";
            book.Properties.LastAuthor = "Mr.X";
            book.Properties.Created = new System.DateTime(2016, 6, 25, 19, 14, 7, 0);
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
            //  s62
            // -----------------------------------------------
            WorksheetStyle s62 = styles.Add("s62");
            s62.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            s62.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            s62.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            s62.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            s62.Alignment.ShrinkToFit = true;
            // -----------------------------------------------
            //  s63
            // -----------------------------------------------
            WorksheetStyle s63 = styles.Add("s63");
            s63.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  s64
            // -----------------------------------------------
            WorksheetStyle s64 = styles.Add("s64");
            s64.Font.FontName = "宋体";
            s64.Font.Size = 14;
            s64.Font.Color = "#000000";
            s64.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            s64.Alignment.Vertical = StyleVerticalAlignment.Center;
            s64.Alignment.WrapText = true;
            s64.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            s64.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            s64.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            s64.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  s65
            // -----------------------------------------------
            WorksheetStyle s65 = styles.Add("s65");
            s65.Font.FontName = "宋体";
            s65.Font.Size = 14;
            s65.Font.Color = "#000000";
            s65.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            s65.Alignment.Vertical = StyleVerticalAlignment.Center;
            s65.Alignment.WrapText = true;
            s65.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  s66
            // -----------------------------------------------
            WorksheetStyle s66 = styles.Add("s66");
            s66.Font.FontName = "宋体";
            s66.Font.Size = 14;
            s66.Font.Color = "#000000";
            s66.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            s66.Alignment.Vertical = StyleVerticalAlignment.Center;
            s66.Alignment.WrapText = true;

        }

        private void GenerateWorksheetSheet1(WorksheetCollection sheets)
        {
            Worksheet sheet = sheets.Add("Sheet1");
            sheet.Names.Add(new WorksheetNamedRange("Print_Area", "=Sheet1!R1C1:R1C11", false));
            sheet.Names.Add(new WorksheetNamedRange("Print_Titles", "=Sheet1!R1", false));
            sheet.Table.DefaultRowHeight = 45F;
            sheet.Table.ExpandedColumnCount = 12;
            //sheet.Table.ExpandedRowCount = 1;
            //sheet.Table.FullColumns = 1;
            //sheet.Table.FullRows = 1;
            WorksheetColumn column0 = sheet.Table.Columns.Add();
            column0.Width = 36;
            column0.StyleID = "s62";
            WorksheetColumn column1 = sheet.Table.Columns.Add();
            column1.Width = 64;
            column1.StyleID = "s62";
            WorksheetColumn column2 = sheet.Table.Columns.Add();
            column2.Width = 79;
            column2.StyleID = "s62";
            WorksheetColumn column3 = sheet.Table.Columns.Add();
            column3.Width = 78;
            column3.StyleID = "s62";
            WorksheetColumn column4 = sheet.Table.Columns.Add();
            column4.Width = 48;
            column4.StyleID = "s62";
            WorksheetColumn column5 = sheet.Table.Columns.Add();
            column5.Width = 54;
            column5.StyleID = "s62";
            WorksheetColumn column6 = sheet.Table.Columns.Add();
            column6.Width = 57;
            column6.StyleID = "s62";
            WorksheetColumn column7 = sheet.Table.Columns.Add();
            column7.Width = 79;
            column7.StyleID = "s62";
            WorksheetColumn column8 = sheet.Table.Columns.Add();
            column8.Width = 69;
            column8.StyleID = "s62";
            WorksheetColumn column9 = sheet.Table.Columns.Add();
            column9.Width = 58;
            column9.StyleID = "s62";
            WorksheetColumn column10 = sheet.Table.Columns.Add();
            column10.Width = 66;
            column10.StyleID = "s62";
            WorksheetColumn column11 = sheet.Table.Columns.Add();
            column11.StyleID = "s63";
            // -----------------------------------------------
            WorksheetRow Row0 = sheet.Table.Rows.Add();
            Row0.AutoFitHeight = false;
            WorksheetCell cell;
            cell = Row0.Cells.Add();
            cell.StyleID = "s64";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "序号";
            cell.NamedCell.Add("Print_Area");
            cell.NamedCell.Add("Print_Titles");
            cell = Row0.Cells.Add();
            cell.StyleID = "s64";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "车牌号";
            cell.NamedCell.Add("Print_Area");
            cell.NamedCell.Add("Print_Titles");
            cell = Row0.Cells.Add();
            cell.StyleID = "s64";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "车辆识别代码(VIN)";
            cell.NamedCell.Add("Print_Area");
            cell.NamedCell.Add("Print_Titles");
            cell = Row0.Cells.Add();
            cell.StyleID = "s64";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "生产厂家";
            cell.NamedCell.Add("Print_Area");
            cell.NamedCell.Add("Print_Titles");
            cell = Row0.Cells.Add();
            cell.StyleID = "s64";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "品牌";
            cell.NamedCell.Add("Print_Area");
            cell.NamedCell.Add("Print_Titles");
            cell = Row0.Cells.Add();
            cell.StyleID = "s64";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "型号";
            cell.NamedCell.Add("Print_Area");
            cell.NamedCell.Add("Print_Titles");
            cell = Row0.Cells.Add();
            cell.StyleID = "s64";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "用途";
            cell.NamedCell.Add("Print_Area");
            cell.NamedCell.Add("Print_Titles");
            cell = Row0.Cells.Add();
            cell.StyleID = "s64";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "采购日期";
            cell.NamedCell.Add("Print_Area");
            cell.NamedCell.Add("Print_Titles");
            cell = Row0.Cells.Add();
            cell.StyleID = "s64";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "注册登记日期";
            cell.NamedCell.Add("Print_Area");
            cell.NamedCell.Add("Print_Titles");
            cell = Row0.Cells.Add();
            cell.StyleID = "s64";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "电池单体型号";
            cell.NamedCell.Add("Print_Area");
            cell.NamedCell.Add("Print_Titles");
            cell = Row0.Cells.Add();
            cell.StyleID = "s64";
            cell.Data.Type = DataType.String;
            cell.Data.Text = "电池总容量(KWh)";
            cell.NamedCell.Add("Print_Area");
            cell.NamedCell.Add("Print_Titles");
            cell = Row0.Cells.Add();
            cell.StyleID = "s65";
            cell.NamedCell.Add("Print_Titles");
            // -----------------------------------------------
            //  Options
            // -----------------------------------------------
            sheet.Options.Selected = true;
            sheet.Options.ProtectObjects = false;
            sheet.Options.ProtectScenarios = false;
            sheet.Options.PageSetup.Layout.Orientation = Orientation.Landscape;
            sheet.Options.PageSetup.Header.Data = "&C&\"宋体,加粗\"&20车辆信息情况表";
            sheet.Options.PageSetup.Header.Margin = 0.3149606F;
            sheet.Options.PageSetup.Footer.Data = "&L&\"仿宋,常规\"&14注:\n1.本表填报一式四份，市新能源汽车推广应用工作领导小组办公室、市财政局、县、区工信局、申请人各存一份；\n2.车辆用途填公交、出租、" +
                "公务、企业通勤、邮政、物流、环卫、工程、旅游、校车、租赁、死人、其他（须注明）；";
            sheet.Options.PageSetup.Footer.Margin = 0.3149606F;
            sheet.Options.PageSetup.PageMargins.Bottom = 0.7480315F;
            sheet.Options.PageSetup.PageMargins.Left = 0.5905512F;
            sheet.Options.PageSetup.PageMargins.Right = 0.5905512F;
            sheet.Options.PageSetup.PageMargins.Top = 0.7874016F;
            sheet.Options.Print.PaperSizeIndex = 9;
            sheet.Options.Print.VerticalResolution = 0;
            sheet.Options.Print.ValidPrinterInfo = true;
        }
    }
}
