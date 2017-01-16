using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.IO;

public partial class edituser : System.Web.UI.Page
{
    string str_cnn = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=";
    string str_sourcefile = @"App_Data\Data.mdb";
    OleDbConnection cnn;
    OleDbCommand cmd;
    OleDbDataReader datar;
    string str_sql;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //首次展示页面,验证是否新用户
            #region 是否新用户
            try
            {
                string user_account = Session["user_account"].ToString();
                int user_class = Convert.ToInt32(Session["user_class"]);
                string str_conn = str_cnn + MapPath(str_sourcefile);
                cnn = new OleDbConnection(str_conn);
                cnn.Open();
                str_sql = "select user_first_load from tUserAccount where user_account='" + user_account + "' and user_class=" + user_class.ToString();
                cmd = new OleDbCommand(str_sql, cnn);
                datar = cmd.ExecuteReader();
                if (datar.HasRows)
                {
                    datar.Read();
                    bool user_isfirst = Convert.ToBoolean(datar["user_first_load"]);
                    if (user_isfirst)
                    {
                        //是新用户
                        cnn.Close();
                        btnCancel.Enabled = false;
                        btnCancel.ToolTip = "新用户必须补完缺失的信息才能使用申报系统.";
                    }
                    else
                    {
                        //老用户
                        cnn.Close();
                        //Todo:展示首页内容
                    }
                }
                else
                {
                    //错误:未找到此用户数据
                    cnn.Close();
                    Response.Redirect("index.aspx");
                }
            }
            catch (Exception)
            {
                //出错:连接数据库失败或session不存在
                Response.Redirect("index.aspx");
            }
            #endregion 
            //根据是否为个人用户决定是否隐藏企业用户项
            if (Convert.ToInt32(Session["user_class"]) == 0)
            {
                //是个人用户
                //禁用企业信息验证控件
                div_company_info.Disabled = true;
                div_company_info.Visible = false;
                RequiredFieldValidator5.Enabled = false;
                RequiredFieldValidator6.Enabled = false;
                RegularExpressionValidator6.Enabled = false;
                RequiredFieldValidator7.Enabled = false;
                RegularExpressionValidator7.Enabled = false;
                cvYYZZ.Enabled = false;
                RegularExpressionValidator8.Enabled = false;
                RegularExpressionValidator9.Enabled = false;
                cvZZJGDMZ.Enabled = false;
                RegularExpressionValidator10.Enabled = false;
                RegularExpressionValidator11.Enabled = false;
                cvSWDJZ.Enabled = false;
                RequiredFieldValidator8.Enabled = false;
                RequiredFieldValidator9.Enabled = false;
                RegularExpressionValidator12.Enabled = false;
                cvFarenIdcard.Enabled = false;
                RequiredFieldValidator10.Enabled = false;
                RegularExpressionValidator13.Enabled = false;
                cvFarenIdcard_img.Enabled = false;
                RegularExpressionValidator14.Enabled = false;
                RequiredFieldValidator11.Enabled = false;
                RegularExpressionValidator15.Enabled = false;
                RegularExpressionValidator16.Enabled = false;

            }
            //判断是否为编辑模式
            int editMode;
            if (clsUser.isNewUser(Session["user_account"].ToString(), this))
            {
                editMode = 0;
            }
            else
            {
                editMode = Convert.ToInt32(Request.QueryString["id"]);
            }
            if (editMode == 1)
            {
                //编辑模式
                cvUserIdcard.Enabled = false;
                cvFarenIdcard.Enabled = false;
                RequiredFieldValidator3.Enabled = false;//经手人身份证
                RequiredFieldValidator7.Enabled = false;//营业执照
                RequiredFieldValidator10.Enabled = false;//法人身份证
                FillUserInfo();
            }
        }

    }

    protected void FillUserInfo()
    {
        //获取用户信息
        string str_conn = str_cnn + MapPath(str_sourcefile);
        cnn = new OleDbConnection(str_conn);
        cnn.Open();
        str_sql = "select * from tUserAccount where user_account='" + Session["user_account"].ToString() + "'";
        cmd = new OleDbCommand(str_sql, cnn);
        datar = cmd.ExecuteReader();
        datar.Read();

        string _account = Session["user_account"].ToString();
        int _class = Convert.ToInt32(Session["user_class"]);

        ddlDistrict.SelectedValue = ddlDistrict.Items.FindByText(datar["user_district"].ToString()).Value;
        //ddlDistrict.Text = datar["user_district"].ToString();
        txtUserName.Text = datar["user_username"].ToString();
        txtUserIdcard.Text = datar["user_useridcard"].ToString();
        /*fuUserIdcard.FileName 显示其图片*/

        /*
         * 2016年7月6日 xy
         * 为了配合前端的插件,修改了图片控件名,及图片展示逻辑
         * 不再动态添加图片控件,改为为固定ID的server控件指定图片地址
         */
        imgShow_WU_FILE_0.ImageUrl = "~/Upload/Img/useridcard/" + datar["user_useridcard_img"].ToString();
        imgShow_WU_FILE_1.ImageUrl = "~/Upload/Img/yyzz/" + datar["user_YYZZ_img"].ToString();
        imgShow_WU_FILE_2.ImageUrl = "~/Upload/Img/zzjgdmz/" + datar["user_ZZJGDMZ_img"].ToString();
        imgShow_WU_FILE_3.ImageUrl = "~/Upload/Img/swdjz/" + datar["user_SWDJZ_img"].ToString();
        imgShow_WU_FILE_4.ImageUrl = "~/Upload/Img/faren/" + datar["user_farenidcard_img"].ToString();
        //Image imgIdcard = new Image();
        //imgIdcard.ImageUrl = "Upload/Img/useridcard/" + datar["user_useridcard_img"].ToString();
        //div_useridcard.Controls.Add(imgIdcard);
        txtUserPhone.Text = datar["user_userphone"].ToString();
        txtUserMobile.Text = datar["user_usermobile"].ToString();
        txtUserMobile_2.Text = datar["user_usermobile_2"].ToString();
        txtCompanyName.Text = datar["user_companyname"].ToString();
        txtZZJGDMZ_id.Text = datar["user_zzjgdmz_id"].ToString();
        /*string _zzjgdmz_img = fuZZJGDMZ.FileName;*/
        //Image imgZZJGDMZ = new Image();
        //imgZZJGDMZ.ImageUrl = "Upload/Img/zzjgdmz/" + datar["user_ZZJGDMZ_img"].ToString();
        //div_zzjgdmz.Controls.Add(imgZZJGDMZ);
        txtYYZZ_id.Text = datar["user_yyzz_id"].ToString();
        /*string _yyzz_img = fuYYZZ.FileName;*/
        //Image imgYYZZ = new Image();
        //imgYYZZ.ImageUrl = "Upload/Img/yyzz/" + datar["user_YYZZ_img"].ToString();
        //div_yyzz.Controls.Add(imgYYZZ);
        txtSWDJZ_id.Text = datar["user_swdjz_id"].ToString();
        /*string _swdjz_img = fuSWDJZ.FileName;*/
        //Image imgSWDJZ = new Image();
        //imgSWDJZ.ImageUrl = "Upload/Img/swdjz/" + datar["user_SWDJZ_img"].ToString();
        //div_swdjz.Controls.Add(imgSWDJZ);
        txtFarenName.Text = datar["user_farenname"].ToString();
        txtFarenIdcard.Text = datar["user_farenidcard"].ToString();
        /*string _farenidcard_img = fuFarenIdcard.FileName;*/
        //Image imgFarenIdcard = new Image();
        //imgFarenIdcard.ImageUrl = "Upload/Img/faren/" + datar["user_farenidcard_img"].ToString();
        //div_farenidcard.Controls.Add(imgFarenIdcard);
        txtFarenPhone.Text = datar["user_farenphone"].ToString();
        txtFarenMobile.Text = datar["user_farenmobile"].ToString();
        txtFarenMobile_2.Text = datar["user_farenmobile_2"].ToString();
        txtBankName.Text = datar["user_bankname"].ToString();
        txtBankCardName.Text = datar["user_bankcardname"].ToString();
        txtBankCardId.Text = datar["user_bankcardid"].ToString();

        cnn.Close();
    }

    protected void cvUserIdcard_ServerValidate(object source, ServerValidateEventArgs args)
    {
        string str_conn = str_cnn + MapPath(str_sourcefile);
        cnn = new OleDbConnection(str_conn);
        cnn.Open();
        string _idcard = txtUserIdcard.Text;
        str_sql = "select * from tUserAccount where user_useridcard='" + _idcard + "' or user_farenidcard='" + _idcard + "'";
        cmd = new OleDbCommand(str_sql, cnn);
        datar = cmd.ExecuteReader();
        bool _result = datar.HasRows;
        cnn.Close();
        if (_result)
        {
            //有数据,不通过
            args.IsValid = false;
        }
        else
        {
            //无数据,通过
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
        //所有验证成功
        //获取所有用户信息
        string _account = Session["user_account"].ToString();
        int _class = Convert.ToInt32(Session["user_class"]);
        bool _first_load = false;
        string _district = ddlDistrict.SelectedItem.Text;
        string _username = txtUserName.Text;
        string _useridcard = txtUserIdcard.Text;
        string _useridcard_img = _useridcard + Path.GetExtension(up_img_WU_FILE_0.FileName).ToLower(); //fuUserIdcard.FileName;
        string _userphone = txtUserPhone.Text;
        string _usermobile = txtUserMobile.Text;
        string _usermobile_2 = txtUserMobile_2.Text;
        string _companyname = txtCompanyName.Text;
        string _zzjgdmz = txtZZJGDMZ_id.Text;
        string _zzjgdmz_img = _zzjgdmz + Path.GetExtension(up_img_WU_FILE_2.FileName).ToLower(); //fuZZJGDMZ.FileName;
        string _yyzz = txtYYZZ_id.Text;
        string _yyzz_img = _yyzz + Path.GetExtension(up_img_WU_FILE_1.FileName).ToLower(); //fuYYZZ.FileName;
        string _swdjz = txtSWDJZ_id.Text;
        string _swdjz_img = _swdjz + Path.GetExtension(up_img_WU_FILE_3.FileName).ToLower(); //fuSWDJZ.FileName;
        string _farenname = txtFarenName.Text;
        string _farenidcard = txtFarenIdcard.Text;
        string _farenidcard_img = _farenidcard + Path.GetExtension(up_img_WU_FILE_4.FileName).ToLower(); //fuFarenIdcard.FileName;
        string _farenphone = txtFarenPhone.Text;
        string _farenmobile = txtFarenMobile.Text;
        string _farenmobile_2 = txtFarenMobile_2.Text;
        string _bankname = txtBankName.Text;
        string _bankcardname = txtBankCardName.Text;
        string _bankcardid = txtBankCardId.Text;
        //用户信息写入数据库
        string sql;
        if (Convert.ToInt32(Request.QueryString["id"]) == 1)
        {
            //编辑模式图片不一定都动
            sql = string.Format("update tUserAccount set user_first_load={0}, user_district='{1}', user_username='{2}'," +
            " user_useridcard='{3}', user_userphone='{4}', user_usermobile='{5}', user_usermobile_2='{6}'," +
            " user_companyname='{7}', user_ZZJGDMZ_id='{8}', user_YYZZ_id='{9}'," +
            " user_SWDJZ_id='{10}', user_farenname='{11}', user_farenidcard='{12}'," +
            " user_farenphone='{13}', user_farenmobile='{14}', user_farenmobile_2='{15}', user_bankname='{16}', user_bankcardname='{17}', user_bankcardid='{18}'",
            _first_load, _district, _username, _useridcard, _userphone, _usermobile, _usermobile_2, _companyname, _zzjgdmz, _yyzz,
            _swdjz, _farenname, _farenidcard, _farenphone, _farenmobile, _farenmobile_2, _bankname, _bankcardname, _bankcardid);
            if (!string.IsNullOrEmpty(up_img_WU_FILE_0.FileName))
            {
                sql += ",user_useridcard_img='" + _useridcard_img + "'";
            }
            if (!string.IsNullOrEmpty(up_img_WU_FILE_2.FileName))
            {
                sql += ",user_ZZJGDMZ_img='" + _zzjgdmz_img + "'";
            }
            if (!string.IsNullOrEmpty(up_img_WU_FILE_1.FileName))
            {
                sql += ",user_YYZZ_img='" + _yyzz_img + "'";
            }
            if (!string.IsNullOrEmpty(up_img_WU_FILE_3.FileName))
            {
                sql += ",user_SWDJZ_img='" + _swdjz_img + "'";
            }
            if (!string.IsNullOrEmpty(up_img_WU_FILE_4.FileName))
            {
                sql += ",user_farenidcard_img='" + _farenidcard_img + "'";
            }
            sql += " where user_account='" + _account + "'";
        }
        else
        {
            sql = string.Format("update tUserAccount set user_first_load={0}, user_district='{1}', user_username='{2}'," +
            " user_useridcard='{3}', user_useridcard_img='{4}', user_userphone='{5}', user_usermobile='{6}', user_usermobile_2='{7}'," +
            " user_companyname='{8}', user_ZZJGDMZ_id='{9}', user_ZZJGDMZ_img='{10}', user_YYZZ_id='{11}', user_YYZZ_img='{12}'," +
            " user_SWDJZ_id='{13}', user_SWDJZ_img='{14}', user_farenname='{15}', user_farenidcard='{16}', user_farenidcard_img='{17}'," +
            " user_farenphone='{18}', user_farenmobile='{19}', user_farenmobile_2='{20}', user_bankname='{21}', user_bankcardname='{22}', user_bankcardid='{23}' " +
            "where user_account='{24}'",
            _first_load, _district, _username, _useridcard, _useridcard_img, _userphone, _usermobile, _usermobile_2, _companyname, _zzjgdmz, _zzjgdmz_img, _yyzz, _yyzz_img,
            _swdjz, _swdjz_img, _farenname, _farenidcard, _farenidcard_img, _farenphone, _farenmobile, _farenmobile_2, _bankname, _bankcardname, _bankcardid, _account);

        }
        string str_conn = str_cnn + MapPath(str_sourcefile);
        cnn = new OleDbConnection(str_conn);
        cnn.Open();
        str_sql = sql;
        cmd = new OleDbCommand(str_sql, cnn);
        cmd.ExecuteNonQuery();
        cnn.Close();
        //上传图片到指定路径
        if (Convert.ToInt32(Request.QueryString["id"]) == 1)
        {
            //编辑模式不一定都上传
            if (!string.IsNullOrEmpty(up_img_WU_FILE_0.FileName))
            {
                UploadImage("useridcard", _useridcard, up_img_WU_FILE_0);
            }
            if (!string.IsNullOrEmpty(up_img_WU_FILE_2.FileName))
            {
                UploadImage("zzjgdmz", _zzjgdmz, up_img_WU_FILE_2);
            }
            if (!string.IsNullOrEmpty(up_img_WU_FILE_1.FileName))
            {
                UploadImage("yyzz", _yyzz, up_img_WU_FILE_1);
            }
            if (!string.IsNullOrEmpty(up_img_WU_FILE_3.FileName))
            {
                UploadImage("swdjz", _swdjz, up_img_WU_FILE_3);
            }
            if (!string.IsNullOrEmpty(up_img_WU_FILE_4.FileName))
            {
                UploadImage("faren", _farenidcard, up_img_WU_FILE_4);
            }
        }
        else
        {
            UploadImage("useridcard", _useridcard, up_img_WU_FILE_0);
            UploadImage("zzjgdmz", _zzjgdmz, up_img_WU_FILE_2);
            UploadImage("yyzz", _yyzz, up_img_WU_FILE_1);
            UploadImage("swdjz", _swdjz, up_img_WU_FILE_3);
            UploadImage("faren", _farenidcard, up_img_WU_FILE_4);
        }
        //提示完成
        Session.Clear();
        Response.Write("<script>alert('更改已生效,请重新登录');window.location.href='index.aspx'</script>");
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

    protected void cvUserIdcard_img_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //验证UserIdcard的大小
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

    protected void cvYYZZ_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //验证营业执照照片的大小
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

    protected void cvZZJGDMZ_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //验证组织机构代码证照片的大小
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

    protected void cvSWDJZ_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //验证税务登记证照片的大小
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

    protected void cvFarenIdcard_ServerValidate(object source, ServerValidateEventArgs args)
    {
        string str_conn = str_cnn + MapPath(str_sourcefile);
        cnn = new OleDbConnection(str_conn);
        cnn.Open();
        string _idcard = txtFarenIdcard.Text;
        str_sql = "select * from tUserAccount where user_useridcard='" + _idcard + "' or user_farenidcard='" + _idcard + "'";
        cmd = new OleDbCommand(str_sql, cnn);
        datar = cmd.ExecuteReader();
        bool _result = datar.HasRows;
        cnn.Close();
        if (_result)
        {
            //有数据,不通过
            args.IsValid = false;
        }
        else
        {
            //无数据,通过
            args.IsValid = true;
        }
    }

    protected void cvFarenIdcard_img_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //验证法人身份证照片的大小
        if (up_img_WU_FILE_4.PostedFile.ContentLength > 204800/*200kB*/)
        {
            //图片文件过大
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }

    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //验证银行账户户名是否合法
        //标注:个人用户填自己姓名,企业用户填企业全称
        int user_class = Convert.ToInt32(Session["user_class"]);
        if (user_class == 0)
        {
            //个人用户
            if (txtUserName.Text == txtBankCardName.Text)
            {
                //合法
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
        else if (user_class == 1)
        {
            //企业用户
            if (txtCompanyName.Text == txtBankCardName.Text)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
        else
        {
            //错误:不存在的用户类型
            Response.Redirect("index.aspx");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("userindex.aspx");
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlDistrict.SelectedIndex = 0;
        txtUserName.Text = "";
        txtUserIdcard.Text = "";
        txtUserPhone.Text = "";
        txtUserMobile.Text = "";
        txtUserMobile_2.Text = "";
        txtCompanyName.Text = "";
        txtYYZZ_id.Text = "";
        txtZZJGDMZ_id.Text = "";
        txtSWDJZ_id.Text = "";
        txtFarenName.Text = "";
        txtFarenIdcard.Text = "";
        txtFarenPhone.Text = "";
        txtFarenMobile.Text = "";
        txtFarenMobile_2.Text = "";
        txtBankName.Text = "";
        txtBankCardName.Text = "";
        txtBankCardId.Text = "";
    }

    protected void btnCancel_Click1(object sender, EventArgs e)
    {
        Response.Redirect("userindex.aspx");
    }
}