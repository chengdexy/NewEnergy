using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.IO;

public partial class addcars : System.Web.UI.Page
{

    string str_cnn = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=";
    string str_sourcefile = @"App_Data\Data.mdb";
    OleDbConnection cnn;
    OleDbCommand cmd;
    OleDbDataReader datar;
    string str_sql;
    bool isEditMode = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        //首次加载时,如果未登录,则返回登录界面
        if (!IsPostBack)
        {
            //首次
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
            else
            {
                //已登录判断编辑模式id=1为编辑模式,无id或id!=1则为新增模式
                if (Request.QueryString["id"] == null)
                {
                    //新增模式
                }
                else
                {
                    //编辑模式:填充数据
                    int car_id = Convert.ToInt32(Request.QueryString["id"]);
                    isEditMode = true;
                    FillBlank(car_id);
                }

            }
        }
    }

    /// <summary>
    /// 编辑模式时调用,填充所有空格
    /// </summary>
    protected void FillBlank(int _id)
    {
        //取出车辆数据
        string str_conn = str_cnn + MapPath(str_sourcefile);
        cnn = new OleDbConnection(str_conn);
        cnn.Open();
        str_sql = "select * from tCars where car_id=" + _id;
        cmd = new OleDbCommand(str_sql, cnn);
        datar = cmd.ExecuteReader();
        if (!datar.HasRows)
        {
            //没找到
            Response.Redirect("index.aspx");
        }
        else
        {
            //找到则取出
            datar.Read();
            txtCarNumber.Text = datar["car_number"].ToString();
            txtCarVin.Text = datar["car_vin"].ToString();
            txtCarProduct.Text = datar["car_product"].ToString();
            txtCarBrand.Text = datar["car_brand"].ToString();
            txtCarClass.Text = datar["car_class"].ToString();
            txtCarKind.Text = datar["car_kind"].ToString();
            ddlCarUse.SelectedValue = ddlCarUse.Items.FindByText(datar["car_use"].ToString()).Value;
            //ddlCarUse.Text = datar["car_use"].ToString();
            txtCarPrice.Text = datar["car_price"].ToString();
            txtBuyDate.Text = ((DateTime)datar["car_buydate"]).ToShortDateString();
            txtRegDate.Text = ((DateTime)datar["car_regdate"]).ToShortDateString();
            txtBatClass.Text = datar["car_batclass"].ToString();
            txtBatKind.Text = datar["car_batkind"].ToString();
            txtBatSize.Text = datar["car_batsize"].ToString();
            txtBatProduct.Text = datar["car_batproduct"].ToString();
            txtMotKind.Text = datar["car_motkind"].ToString();
            txtMotProduct.Text = datar["car_motproduct"].ToString();
            txtEngKind.Text = datar["car_engkind"].ToString();
            txtEngProduct.Text = datar["car_engproduct"].ToString();
            imgShow_WU_FILE_0.ImageUrl= "~/Upload/Img/bill/" + datar["car_bill_img"].ToString();
            imgShow_WU_FILE_1.ImageUrl = "~/Upload/Img/cldjz/" + datar["car_cldjz_img"].ToString();
            imgShow_WU_FILE_2.ImageUrl = "~/Upload/Img/clyzxzs/" + datar["car_clyzxzs_img"].ToString();
            imgShow_WU_FILE_3.ImageUrl = "~/Upload/Img/xsz/" + datar["car_xsz_img"].ToString();
            //Image imgBill = new Image();
            //imgBill.ImageUrl = "~/Upload/Img/bill/" + datar["car_bill_img"].ToString();
            //div_carbill_img.Controls.Add(imgBill);
            //Image imgCLDJZ = new Image();
            //imgCLDJZ.ImageUrl = "~/Upload/Img/cldjz/" + datar["car_cldjz_img"].ToString();
            //div_carcldjz_img.Controls.Add(imgCLDJZ);
            //Image imgCLYZXZS = new Image();
            //imgCLYZXZS.ImageUrl = "~/Upload/Img/clyzxzs/" + datar["car_clyzxzs_img"].ToString();
            //div_carclyzxzs_img.Controls.Add(imgCLYZXZS);
            //Image imgXSZ = new Image();
            //imgXSZ.ImageUrl = "~/Upload/Img/xsz/" + datar["car_xsz_img"].ToString();
            //div_carxsz_img.Controls.Add(imgXSZ);
            RequiredFieldValidator18.Enabled = false;
            RequiredFieldValidator19.Enabled = false;
            RequiredFieldValidator20.Enabled = false;
            RequiredFieldValidator21.Enabled = false;
        }
        cnn.Close();
    }

    protected void cvCarBill_img_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //验证CarBill的大小
        if (up_img_WU_FILE_0.PostedFile.ContentLength > 204800/*200kB*/)
        {
            //图片文件过大
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }

    protected void cvCarCLDJZ_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //验证CarCLDJZ(车辆登记证)的大小
        if (up_img_WU_FILE_1.PostedFile.ContentLength > 204800/*200kB*/)
        {
            //图片文件过大
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }

    protected void cvCarXSZ_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //验证CarXSZ(行驶证)的大小
        if (up_img_WU_FILE_3.PostedFile.ContentLength > 204800/*200kB*/)
        {
            //图片文件过大
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }

    protected void cvCarCLYZXZS_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //验证CarCLYZXZS(车辆一致性证书)的大小
        if (up_img_WU_FILE_2.PostedFile.ContentLength > 204800/*200kB*/)
        {
            //图片文件过大
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (!IsValid)
        {
            return;
        }

        //至此验证全部通过
        //1.获取用户信息
        string user_account = Session["user_account"].ToString();
        bool car_reported = false;
        //2.获取表单内容
        /*2016年7月19日 车牌号，架子号自动ToUpper后存储，即忽略大小写*/
        string car_number = txtCarNumber.Text.ToUpper();
        string car_vin = txtCarVin.Text.ToUpper();
        //
        string car_product = txtCarProduct.Text;
        string car_brand = txtCarBrand.Text;
        string car_class = txtCarClass.Text;
        string car_kind = txtCarKind.Text;
        string car_use = ddlCarUse.SelectedItem.Text;//可能会变取值方式
        decimal car_price = Convert.ToDecimal(txtCarPrice.Text);
        string car_buydate = txtBuyDate.Text;//库里为日期型
        string car_regdate = txtRegDate.Text;//库里为日期型
        string car_batclass = txtBatClass.Text;
        string car_batkind = txtBatKind.Text;
        string car_batsize = txtBatSize.Text;
        string car_batproduct = txtBatProduct.Text;
        string car_motkind = txtMotKind.Text;
        string car_motproduct = txtMotProduct.Text;
        string car_engkind = txtEngKind.Text;
        string car_engproduct = txtEngProduct.Text;
        string car_bill_img = up_img_WU_FILE_0.FileName;
        string car_cldjz_img = up_img_WU_FILE_1.FileName;
        string car_clyzxzs_img = up_img_WU_FILE_2.FileName;
        string car_xsz_img = up_img_WU_FILE_3.FileName;
        //2.5. 记录图片扩展名,生成上传所需文件名
        string imgName_bill = car_vin + Path.GetExtension(up_img_WU_FILE_0.FileName).ToLower();
        string imgName_cldjz = car_vin + Path.GetExtension(up_img_WU_FILE_1.FileName).ToLower();
        string imgName_clyzxzs = car_vin + Path.GetExtension(up_img_WU_FILE_2.FileName).ToLower();
        string imgName_xsz = car_vin + Path.GetExtension(up_img_WU_FILE_3.FileName).ToLower();
        //3.存储表单内容
        string sql = null;
        if (Request.QueryString["id"] != null)
        {
            //如果是编辑模式,只更新数据库中不包括图片的部分
            sql = string.Format("update tCars set car_user='{0}',car_number='{1}',car_vin='{2}',car_product='{3}',car_brand='{4}',car_class='{5}',car_kind='{6}'," +
            "car_use='{7}',car_price={8},car_buydate=#{9}#,car_regdate=#{10}#,car_batclass='{11}',car_batkind='{12}',car_batsize={13},car_batproduct='{14}',car_motkind='{15}',car_motproduct='{16}'," +
            "car_engkind='{17}',car_engproduct='{18}'",
            user_account, car_number, car_vin, car_product, car_brand, car_class, car_kind, car_use,
            car_price.ToString(), car_buydate, car_regdate, car_batclass, car_batkind, car_batsize, car_batproduct, car_motkind,
            car_motproduct, car_engkind, car_engproduct);
            if (!string.IsNullOrEmpty(up_img_WU_FILE_0.FileName))
            {
                sql += ",car_bill_img='" + imgName_bill + "'";
            }
            if (!string.IsNullOrEmpty(up_img_WU_FILE_1.FileName))
            {
                sql += ",car_cldjz_img='" + imgName_cldjz + "'";
            }
            if (!string.IsNullOrEmpty(up_img_WU_FILE_2.FileName))
            {
                sql += ",car_clyzxzs_img='" + imgName_clyzxzs + "'";
            }
            if (!string.IsNullOrEmpty(up_img_WU_FILE_3.FileName))
            {
                sql += ",car_xsz_img='" + imgName_xsz + "'";
            }
            sql += " where car_id=" + Request.QueryString["id"];
        }
        else
        {
            sql = string.Format("insert into tCars(car_user,car_reported,car_number,car_vin,car_product,car_brand,car_class,car_kind," +
            "car_use,car_price,car_buydate,car_regdate,car_batclass,car_batkind,car_batsize,car_batproduct,car_motkind,car_motproduct," +
            "car_engkind,car_engproduct,car_bill_img,car_cldjz_img,car_clyzxzs_img,car_xsz_img) " +
            "values('{0}',{1},'{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},#{10}#,#{11}#,'{12}','{13}','{14}','{15}','{16}','{17}','{18}'," +
            "'{19}','{20}','{21}','{22}','{23}')",
            user_account, car_reported.ToString(), car_number, car_vin, car_product, car_brand, car_class, car_kind, car_use,
            car_price.ToString(), car_buydate, car_regdate, car_batclass, car_batkind, car_batsize, car_batproduct, car_motkind,
            car_motproduct, car_engkind, car_engproduct, imgName_bill, imgName_cldjz, imgName_clyzxzs, imgName_xsz);
        }

        string str_conn = str_cnn + MapPath(str_sourcefile);
        cnn = new OleDbConnection(str_conn);
        cnn.Open();
        cmd = new OleDbCommand(sql, cnn);
        cmd.ExecuteNonQuery();
        cnn.Close();
        //4.上传图片文件
        if (Request.QueryString["id"] != null)
        {
            //编辑模式下不一定都上传
            if (!string.IsNullOrEmpty(up_img_WU_FILE_0.FileName))
            {
                UploadImage("bill", car_vin, up_img_WU_FILE_0);
            }
            if (!string.IsNullOrEmpty(up_img_WU_FILE_1.FileName))
            {
                UploadImage("cldjz", car_vin, up_img_WU_FILE_1);
            }
            if (!string.IsNullOrEmpty(up_img_WU_FILE_2.FileName))
            {
                UploadImage("clyzxzs", car_vin, up_img_WU_FILE_2);
            }
            if (!string.IsNullOrEmpty(up_img_WU_FILE_3.FileName))
            {
                UploadImage("xsz", car_vin, up_img_WU_FILE_3);
            }
        }
        else
        {
            UploadImage("bill", car_vin, up_img_WU_FILE_0);
            UploadImage("cldjz", car_vin, up_img_WU_FILE_1);
            UploadImage("clyzxzs", car_vin, up_img_WU_FILE_2);
            UploadImage("xsz", car_vin, up_img_WU_FILE_3);
        }
        //5.提示保存成功
        if (Request.QueryString["id"] != null)
        {
            Response.Write("<script>alert('修改车辆信息成功![车牌号:" + car_number + "]');window.location.href='userindex.aspx';</script>");
        }
        else
        {
            Response.Write("<script>alert('新增车辆信息成功![车牌号:" + car_number + "]');window.location.href='userindex.aspx';</script>");
        }
    }

    /// <summary>
    /// 上传图片
    /// </summary>
    /// <param name="_folder">指定~/upload/img/中的子文件夹名</param>
    /// <param name="_fileName">指定上传后保存为的文件名</param>
    /// <param name="_obj">指定文件上传使用的FileUpload控件</param>
    protected void UploadImage(string _folder, string _fileName, FileUpload _obj)
    {
        //源文件名
        string sorFileName = _obj.FileName;
        if (string.IsNullOrEmpty(sorFileName))
        {
            return;
        }
        string savePath = MapPath("~/Upload/Img/" + _folder + "/");
        //目标文件名
        string imgFileName = _fileName + Path.GetExtension(_obj.FileName).ToLower();
        //上传文件
        _obj.PostedFile.SaveAs(savePath + imgFileName);
    }
}