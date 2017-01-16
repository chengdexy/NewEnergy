<%@ Page Title="" Language="C#" MasterPageFile="~/mst0.master" AutoEventWireup="true" CodeFile="edituser.aspx.cs" Inherits="edituser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .panel {
            margin-bottom: 8px;
        }

        .form-group {
            width: 50%;
            height: 60px;
            margin-top: 5px;
            float: left;
            border-bottom: 1px dashed #ccc;
        }

        .label {
            width: 30%;
            text-align: right;
            float: left;
            line-height: 30px;
        }

        .input {
            width: 50%;
        }

        .uploadimgbox img {
            border: 1px solid #ccc;
            padding: 5px;
            width: 150px;
            height: 90px;
        }

        .uploadbutton {
            float: left;
            margin-right: 8px;
        }

        .form-button {
            margin-top: 8px;
        }
		#warp li{
		 list-style-type:none;
		}
        /*
            2016年6月28日20:45:43
            id=Xue
            大图弹出层CSS部分
        */
        #div_bigimg {
            width: 80%;
            height: 80%;
            border: 1px solid black;
            background-color: #fff;
            overflow: auto;
            position: absolute;
            margin: auto;
            top: 0;
            left: 0;
            bottom: 0;
            right: 0;
        }

        #img_bigimg {
            margin: auto;
            position: absolute;
            top: 0;
            left: 0;
            bottom: 0;
            right: 0;
        }

        #div_btn_close {
            padding: 10px;
            background-color: #e8e8e8;
            position: absolute;
            z-index: 10;
            top: 50px;
            left: 50px;
        }
        /*
            大图弹出层CSS部分结束
        */
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <p>编辑用户信息</p>
        <p>
            <b>行政区划-所属县(区):</b>
            <asp:DropDownList ID="ddlDistrict" runat="server">
                <asp:ListItem Text="双桥区" Value="1" Selected="True"></asp:ListItem>
                <asp:ListItem Text="双滦区" Value="2"></asp:ListItem>
                <asp:ListItem Text="高新区" Value="3"></asp:ListItem>
                <asp:ListItem Text="营子区" Value="4"></asp:ListItem>
                <asp:ListItem Text="承德县" Value="5"></asp:ListItem>
                <asp:ListItem Text="隆化县" Value="6"></asp:ListItem>
                <asp:ListItem Text="滦平县" Value="7"></asp:ListItem>
                <asp:ListItem Text="平泉县" Value="8"></asp:ListItem>
                <asp:ListItem Text="丰宁县" Value="9"></asp:ListItem>
                <asp:ListItem Text="宽城县" Value="10"></asp:ListItem>
                <asp:ListItem Text="围场县" Value="11"></asp:ListItem>
                <asp:ListItem Text="兴隆县" Value="12"></asp:ListItem>
            </asp:DropDownList>
        </p>
   <ul id="warp">    
    <li>
        <div class="panel" style="height: 300px;">
            <div class="panel-head"><strong>个人信息:</strong></div>
            <div class="form-group">
                <div class="label">
                    <label>姓名:</label>
                </div>
                <div class="field">
                    <asp:TextBox ID="txtUserName" class="input" runat="server" placeHolder="企业用户填写经办人姓名" AutoComplete="false"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="colorred" ErrorMessage="请填写姓名(经办人姓名)" ControlToValidate="txtUserName" Display="Dynamic"></asp:RequiredFieldValidator>

                </div>
            </div>

            <div class="form-group">
                <div class="label">
                    <label>固定电话:</label>
                </div>
                <div class="field">
                    <asp:TextBox ID="txtUserPhone" class="input" runat="server" AutoComplete="false"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationExpression="(\(\d{3,4}\)|\d{3,4}-|\s)?\d{7,8}" CssClass="colorred" ErrorMessage="请输入正确格式的固定电话号码" ControlToValidate="txtUserPhone" Display="Dynamic"></asp:RegularExpressionValidator>

                </div>
            </div>

            <div class="form-group">
                <div class="label">
                    <label>手机号码:</label>
                </div>
                <div class="field">
                    <asp:TextBox ID="txtUserMobile" class="input" runat="server" AutoComplete="false"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="colorred" ErrorMessage="请填入手机号码以供我们和您取得联系" ControlToValidate="txtUserMobile" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ValidationExpression="^[1][0-9]{10}$" CssClass="colorred" ErrorMessage="请输入正确格式的手机号码" ControlToValidate="txtUserMobile" Display="Dynamic"></asp:RegularExpressionValidator>

                </div>
            </div>

            <div class="form-group">
                <div class="label">
                    <label>手机号码2:</label>
                </div>
                <div class="field">
                    <asp:TextBox ID="txtUserMobile_2" class="input" runat="server" AutoComplete="false"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ValidationExpression="^[1][0-9]{10}$" CssClass="colorred" ErrorMessage="请输入正确格式的手机号码" ControlToValidate="txtUserMobile_2" Display="Dynamic"></asp:RegularExpressionValidator>

                </div>
            </div>

            <div class="form-group" style="height: 100px;">
                <div class="label">
                    <label>身份证号:</label>
                </div>
                <div class="field">
                    <asp:TextBox ID="txtUserIdcard" class="input" runat="server" placeHolder="请输入18位2代身份证号码" AutoComplete="false"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="colorred" ErrorMessage="请填写身份证号码" ControlToValidate="txtUserIdcard" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="^[1-9]([0-9]{16}|[0-9]{13})[xX0-9]$" CssClass="colorred" ErrorMessage="请输入正确的18位2代身份证号码" ControlToValidate="txtUserIdcard" Display="Dynamic"></asp:RegularExpressionValidator>
                    <asp:CustomValidator ID="cvUserIdcard" runat="server" ControlToValidate="txtUserIdcard" CssClass="colorred" ErrorMessage="这个身份证号已经有人使用了" Display="Dynamic" OnServerValidate="cvUserIdcard_ServerValidate"></asp:CustomValidator>

                </div>
            </div>

            <div class="form-group" style="height: 100px">
                <div class="label">
                    <label>上传身份证照片:</label>
                </div>
                <div class="field">
				  <p>
                    <a class="button input-file uploadbutton" href="javascript:void(0);">+ 浏览文件<asp:FileUpload ID="up_img_WU_FILE_0" ClientIDMode="Static" runat="server" /></a>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="colorred" ErrorMessage="请上传身份证照片" ControlToValidate="up_img_WU_FILE_0" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationExpression=".*(.jpg|.png)$" CssClass="colorred" ErrorMessage="只能上传jpg或png格式的图片,且大小不能超过200kB" ControlToValidate="up_img_WU_FILE_0" Display="Dynamic"></asp:RegularExpressionValidator>
                    <asp:CustomValidator ID="cvUserIdcard_img" runat="server" ControlToValidate="up_img_WU_FILE_0" CssClass="colorred" ErrorMessage="图片大于200kB,请处理后重新上传" Display="Dynamic" OnServerValidate="cvUserIdcard_img_ServerValidate"></asp:CustomValidator>
                    <asp:Image ID="imgShow_WU_FILE_0" ClientIDMode="Static" runat="server" Width="150" Height="100" />
				  </p>
                    <!-- <div id="div_useridcard" class="uploadimgbox" runat="server"></div> -->

                </div>
            </div>
        </div>
  </li>
  <li>
        <div id="div_company_info" runat="server">

            <div class="panel" style="height: 670px;">
                <div class="panel-head"><strong>企业信息:</strong></div>
                <div class="form-group">
                    <div class="label">
                        <label>企业名称:</label>
                    </div>
                    <div class="field">
                        <asp:TextBox ID="txtCompanyName" class="input" runat="server" AutoComplete="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" CssClass="colorred" ErrorMessage="企业名称不能为空" ControlToValidate="txtCompanyName" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <div class="label">
                        <label>法人姓名:</label>
                    </div>
                    <div class="field">
                        <asp:TextBox ID="txtFarenName" class="input" runat="server" AutoComplete="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" CssClass="colorred" ErrorMessage="请填入法人姓名" ControlToValidate="txtFarenname" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <div class="label">
                        <label>固定电话:</label>
                    </div>
                    <div class="field">
                        <asp:TextBox ID="txtFarenPhone" class="input" runat="server" AutoComplete="false"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" ValidationExpression="(\(\d{3,4}\)|\d{3,4}-|\s)?\d{7,8}" CssClass="colorred" ErrorMessage="请输入正确格式的固定电话号码" ControlToValidate="txtFarenPhone" Display="Dynamic"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-group">
                    <div class="label">
                        <label>手机号码:</label>
                    </div>
                    <div class="field">
                        <asp:TextBox ID="txtFarenMobile" class="input" runat="server" AutoComplete="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" CssClass="colorred" ErrorMessage="请填入法人的手机号码" ControlToValidate="txtFarenMobile" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" ValidationExpression="^[1][0-9]{10}$" CssClass="colorred" ErrorMessage="请输入正确格式的手机号码" ControlToValidate="txtFarenMobile" Display="Dynamic"></asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="form-group">
                    <div class="label">
                        <label>手机号码2:</label>
                    </div>
                    <div class="field">
                        <asp:TextBox ID="txtFarenMobile_2" class="input" runat="server" AutoComplete="false"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server" ValidationExpression="^[1][0-9]{10}$" CssClass="colorred" ErrorMessage="请输入正确格式的手机号码" ControlToValidate="txtFarenMobile_2" Display="Dynamic"></asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="form-group">
                </div>

                <div class="form-group" style="height: 100px;">
                    <div class="label">
                        <label>营业执照号码:</label>
                    </div>
                    <div class="field">
                        <asp:TextBox ID="txtYYZZ_id" class="input" runat="server"  placeHolder="三证合一的企业只需填写此项" AutoComplete="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" CssClass="colorred" ErrorMessage="请填写营业执照号码" ControlToValidate="txtYYZZ_id" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" CssClass="colorred" ErrorMessage="请填写正确格式的营业执照号码" ControlToValidate="txtYYZZ_id" Display="Dynamic" ValidationExpression="^([1-9A-Z]{2}[0-9]{6}[0-9A-Z]{9}[0-9A-Z])|\d{15}$"></asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="form-group" style="height: 100px">
                    <div class="label">
                        <label>上传营业执照照片:</label>
                    </div>
                    <div class="field">
                        <a class="button input-file uploadbutton" href="javascript:void(0);">+ 浏览文件<asp:FileUpload ID="up_img_WU_FILE_1" ClientIDMode="Static" runat="server" /></a>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" CssClass="colorred" ErrorMessage="请上传营业执照照片" ControlToValidate="up_img_WU_FILE_1" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ValidationExpression=".*(.jpg|.png)$" CssClass="colorred" ErrorMessage="只能上传jpg或png格式的图片,且大小不能超过200kB" ControlToValidate="up_img_WU_FILE_1" Display="Dynamic"></asp:RegularExpressionValidator>
                        <asp:CustomValidator ID="cvYYZZ" runat="server" ControlToValidate="up_img_WU_FILE_1" CssClass="colorred" ErrorMessage="图片大于200kB,请处理后重新上传" Display="Dynamic" OnServerValidate="cvYYZZ_ServerValidate"></asp:CustomValidator>
                        <asp:Image ID="imgShow_WU_FILE_1" ClientIDMode="Static" runat="server" Width="150" Height="100" />
                      <!--   <div id="div_yyzz" class="uploadimgbox" runat="server"></div> -->
                    </div>
                </div>

                <div class="form-group" style="height: 100px;">
                    <div class="label">
                        <label>组织机构代码证号:</label>
                    </div>
                    <div class="field">
                        <asp:TextBox ID="txtZZJGDMZ_id" class="input" runat="server" AutoComplete="false"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" CssClass="colorred" ErrorMessage="请填入正确格式的组织机构代码证号码" ControlToValidate="txtZZJGDMZ_id" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9]{8}-[a-zA-Z0-9]$"></asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="form-group" style="height: 100px">
                    <div class="label">
                        <label>上传组织机构代码证照片:</label>
                    </div>
                    <div class="field">
					  <ul>
					   <li>
                        <a class="button input-file uploadbutton" href="javascript:void(0);">+ 浏览文件<asp:FileUpload ID="up_img_WU_FILE_2" ClientIDMode="Static" runat="server" /></a>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ValidationExpression=".*(.jpg|.png)$" CssClass="colorred" ErrorMessage="只能上传jpg或png格式的图片,且大小不能超过200kB" ControlToValidate="up_img_WU_FILE_2" Display="Dynamic"></asp:RegularExpressionValidator>
                        <asp:CustomValidator ID="cvZZJGDMZ" runat="server" ControlToValidate="up_img_WU_FILE_2" CssClass="colorred" ErrorMessage="图片大于200kB,请处理后重新上传" Display="Dynamic" OnServerValidate="cvZZJGDMZ_ServerValidate"></asp:CustomValidator>
                        <asp:Image ID="imgShow_WU_FILE_2" ClientIDMode="Static" runat="server" Width="150" Height="100" />
						</li>
					 </ul>
                       <!--  <div id="div_zzjgdmz" class="uploadimgbox" runat="server"></div> -->
                    </div>
                </div>

                <div class="form-group" style="height: 100px;">
                    <div class="label">
                        <label>税务登记证号码:</label>
                    </div>
                    <div class="field">
                        <asp:TextBox ID="txtSWDJZ_id" class="input" runat="server" AutoComplete="false"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" CssClass="colorred" ErrorMessage="请填入正确格式的税务登记证号码" ControlToValidate="txtSWDJZ_id" Display="Dynamic" ValidationExpression="^(\d{15}[0]{4}[0-9])|(\d{17}[0-9xX][0][0-9])|[0-9a-zA-Z]{15}$"></asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="form-group" style="height: 100px">
                    <div class="label">
                        <label>上传税务登记证照片:</label>
                    </div>
                    <div class="field">
					<ul>
					 <li>
                        <a class="button input-file uploadbutton" href="javascript:void(0);">+ 浏览文件<asp:FileUpload ID="up_img_WU_FILE_3" ClientIDMode="Static" runat="server" /></a>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ValidationExpression=".*(.jpg|.png)$" CssClass="colorred" ErrorMessage="只能上传jpg或png格式的图片,且大小不能超过200kB" ControlToValidate="up_img_WU_FILE_3" Display="Dynamic"></asp:RegularExpressionValidator>
                        <asp:CustomValidator ID="cvSWDJZ" runat="server" ControlToValidate="up_img_WU_FILE_3" CssClass="colorred" ErrorMessage="图片大于200kB,请处理后重新上传" Display="Dynamic" OnServerValidate="cvSWDJZ_ServerValidate"></asp:CustomValidator>
                        <asp:Image ID="imgShow_WU_FILE_3" ClientIDMode="Static" runat="server" Width="150" Height="100" />
                       <!--  <div id="div_swdjz" class="uploadimgbox" runat="server"></div> -->
					  </li>
					 </ul>
                    </div>
                </div>

                <div class="form-group" style="height: 100px;">
                    <div class="label">
                        <label>法人身份证号码:</label>
                    </div>
                    <div class="field">
                        <asp:TextBox ID="txtFarenIdcard" class="input" runat="server" AutoComplete="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" CssClass="colorred" ErrorMessage="请填写法人身份证号码" ControlToValidate="txtFarenIdcard" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ValidationExpression="^[1-9]([0-9]{16}|[0-9]{13})[xX0-9]$" CssClass="colorred" ErrorMessage="请输入正确的18位2代身份证号码" ControlToValidate="txtFarenIdcard" Display="Dynamic"></asp:RegularExpressionValidator>
                        <asp:CustomValidator ID="cvFarenIdcard" runat="server" ControlToValidate="txtFarenIdcard" CssClass="colorred" ErrorMessage="这个身份证号已经有人使用了" Display="Dynamic" OnServerValidate="cvFarenIdcard_ServerValidate"></asp:CustomValidator>
                    </div>
                </div>

                <div class="form-group" style="height: 100px">
                    <div class="label">
                        <label>上传法人身份证照片:</label>
                    </div>
                    <div class="field">
					<ul>
					  <li>
                        <a class="button input-file uploadbutton" href="javascript:void(0);">+ 浏览文件<asp:FileUpload ID="up_img_WU_FILE_4"  ClientIDMode="Static" runat="server" /></a>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" CssClass="colorred" ErrorMessage="请上传法人身份证照片" ControlToValidate="up_img_WU_FILE_4" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ValidationExpression=".*(.jpg|.png)$" CssClass="colorred" ErrorMessage="只能上传jpg或png格式的图片,且大小不能超过200kB" ControlToValidate="up_img_WU_FILE_4" Display="Dynamic"></asp:RegularExpressionValidator>
                        <asp:CustomValidator ID="cvFarenIdcard_img" runat="server" ControlToValidate="up_img_WU_FILE_4" CssClass="colorred" ErrorMessage="图片大于200kB,请处理后重新上传" Display="Dynamic" OnServerValidate="cvFarenIdcard_img_ServerValidate"></asp:CustomValidator>
                        <asp:Image ID="imgShow_WU_FILE_4" ClientIDMode="Static" runat="server" Width="150" Height="100" />
                      <!--   <div id="div_farenidcard" class="uploadimgbox" runat="server"></div> -->
                     </li>
					 </ul>

                    </div>
                </div>


            </div>

        </div>
  </li>
</ul>
        <div class="panel" style="height: 200px;">
            <div class="panel-head"><strong>银行账户信息</strong></div>
            <div class="form-group">
                <div class="label">
                    <label>开户银行:</label>
                </div>
                <div class="field">
                    <asp:TextBox ID="txtBankName" runat="server" class="input" AutoComplete="false"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" CssClass="colorred" ErrorMessage="请填入完整的开户行名称以免资金无法拨付到位!" ControlToValidate="txtBankName" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <div class="label">
                    <label>账户户名:</label>
                </div>
                <div class="field">
                    <asp:TextBox ID="txtBankCardName" runat="server" class="input" AutoComplete="false"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" CssClass="colorred" ErrorMessage="请填入户名.个人用户应为用户姓名,企业用户应为公司对公账户名" ControlToValidate="txtBankCardName" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" CssClass="colorred" ErrorMessage="此处,个人用户应填自己姓名,企业用户应填公司对公账户名." ControlToValidate="txtBankCardName" Display="Dynamic" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                </div>
            </div>
            <div class="form-group">
                <div class="label">
                    <label>账户账号:</label>
                </div>
                <div class="field">
                    <asp:TextBox ID="txtBankCardId" runat="server" class="input" AutoComplete="false"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" CssClass="colorred" ErrorMessage="请填入账户账号,并仔细核对,以免资金无法拨付到位!" ControlToValidate="txtBankCardId" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server" CssClass="colorred" ErrorMessage="请填入正确格式的银行账户账号" ControlToValidate="txtBankCardId" Display="Dynamic" ValidationExpression="^\d{13,19}$"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-group">
            </div>
        </div>

        <div class="form-button floatright">
            <asp:Button ID="btnSave" class="button bg-main" runat="server" Text="确认保存" OnClick="btnSave_Click" />
            <asp:Button ID="btnClear" class="button bg-yellow" runat="server" Text="清空重填" CausesValidation="False" OnClick="btnClear_Click" UseSubmitBehavior="False" />
            <asp:Button ID="btnCancel" class="button bg-green" runat="server" Text="返回上一页" CausesValidation="false" UseSubmitBehavior="false" OnClick="btnCancel_Click1" />
            &nbsp;
        </div>
    </div>
    <%-- 大图弹出层 html 部分 --%>
    <div id="div_bigimg">
        <a id="div_btn_close">点击这里关闭大图显示</a>
        <img id="img_bigimg" />
    </div>
    <%-- 大图弹出层 html 部分结束 --%>
    <%-- 大图弹出层 js 部分 --%>
    <script type="text/javascript">
        var mouseDown = false;
        var imgurl;
        $(document).ready(function () {
            //点击弹出大图层
            $("#div_bigimg").hide();
            //-----有几个会被点击的图片框,就加几个-----
            $("#imgShow_WU_FILE_0").click(function () {
                imgurl = $("#imgShow_WU_FILE_0").attr("src");
                $("#img_bigimg").attr("src", imgurl);
                $("#div_bigimg").fadeIn(100);
            });
            //----------------------------------------
            $("#imgShow_WU_FILE_1").click(function () {
                imgurl = $("#imgShow_WU_FILE_1").attr("src");
                $("#img_bigimg").attr("src", imgurl);
                $("#div_bigimg").fadeIn(100);
            });
            $("#imgShow_WU_FILE_2").click(function () {
                imgurl = $("#imgShow_WU_FILE_2").attr("src");
                $("#img_bigimg").attr("src", imgurl);
                $("#div_bigimg").fadeIn(100);
            });
            $("#imgShow_WU_FILE_3").click(function () {
                imgurl = $("#imgShow_WU_FILE_3").attr("src");
                $("#img_bigimg").attr("src", imgurl);
                $("#div_bigimg").fadeIn(100);
            });
            $("#imgShow_WU_FILE_4").click(function () {
                imgurl = $("#imgShow_WU_FILE_4").attr("src");
                $("#img_bigimg").attr("src", imgurl);
                $("#div_bigimg").fadeIn(100);
            });
            //点击关闭,关闭弹出层
            $("#div_btn_close").click(function () {
                $("#div_bigimg").fadeOut(0);
            });
        });
    </script>
    <%-- 大图弹出层 js 部分结束 --%>
</asp:Content>

