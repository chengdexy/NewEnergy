<%@ Page Title="" Language="C#" MasterPageFile="~/mst0.master" AutoEventWireup="true" CodeFile="addcars.aspx.cs" Inherits="addcars" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
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

        #warp li {
            list-style-type: none;
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
    <p>车辆信息管理</p>
    <div>
        <div class="form-group">
            <div class="label">
                <label>车牌号:</label>
            </div>
            <div class="field">
                <asp:TextBox ID="txtCarNumber" runat="server" CssClass="input" AutoComplete="false"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="colorred" ErrorMessage="请输入车牌号" ControlToValidate="txtCarNumber" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" CssClass="colorred" ErrorMessage="车牌号格式不正确" ControlToValidate="txtCarNumber" Display="Dynamic" ValidationExpression="^[\u4e00-\u9fa5]{1}[a-zA-Z](\-)?[a-zA-Z0-9]{5}$"></asp:RegularExpressionValidator>

            </div>
        </div>

        <div class="form-group">
            <div class="label">
                <label>车辆识别代码(VIN):</label>
            </div>
            <div class="field">
                <asp:TextBox ID="txtCarVin" runat="server" class="input" AutoComplete="false"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="colorred" ErrorMessage="请输入车架号" ControlToValidate="txtCarVin" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" CssClass="colorred" ErrorMessage="车架号格式不正确" ControlToValidate="txtCarVin" Display="Dynamic" ValidationExpression="^[0-9a-zA-Z]{17}$"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="form-group">
            <div class="label">
                <label>生产厂家:</label>
            </div>
            <div class="field">
                <asp:TextBox ID="txtCarProduct" runat="server" class="input" AutoComplete="false"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="colorred" ErrorMessage="请填写车辆生产厂家(全名)" ControlToValidate="txtCarProduct" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group">
            <div class="label">
                <label>品牌:</label>
            </div>
            <div class="field">
                <asp:TextBox ID="txtCarBrand" runat="server" class="input" AutoComplete="false"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="colorred" ErrorMessage="请填写车辆品牌" ControlToValidate="txtCarBrand" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group">
            <div class="label">
                <label>车辆类型:</label>
            </div>
            <div class="field">
                <asp:TextBox ID="txtCarClass" runat="server" class="input" AutoComplete="false"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" CssClass="colorred" ErrorMessage="请填写车辆类型" ControlToValidate="txtCarClass" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <div class="label">
                <label>型号:</label>
            </div>
            <div class="field">
                <asp:TextBox ID="txtCarKind" runat="server" class="input" AutoComplete="false"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" CssClass="colorred" ErrorMessage="请填写车辆型号" ControlToValidate="txtCarKind" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>

        <%-- Todo:待解决问题-点击其他后出现文本框,供输入 --%>
        <div class="form-group">
            <div class="label">
                <label>用途:</label>
            </div>
            <div class="field">
                <asp:DropDownList ID="ddlCarUse" runat="server" class="selected">
                    <asp:ListItem Text="公交" Value="0"></asp:ListItem>
                    <asp:ListItem Text="出租" Value="1"></asp:ListItem>
                    <asp:ListItem Text="公务" Value="2"></asp:ListItem>
                    <asp:ListItem Text="企业通勤" Value="3"></asp:ListItem>
                    <asp:ListItem Text="邮政" Value="4"></asp:ListItem>
                    <asp:ListItem Text="物流" Value="5"></asp:ListItem>
                    <asp:ListItem Text="环卫" Value="6"></asp:ListItem>
                    <asp:ListItem Text="工程" Value="7"></asp:ListItem>
                    <asp:ListItem Text="旅游" Value="8"></asp:ListItem>
                    <asp:ListItem Text="校车" Value="9"></asp:ListItem>
                    <asp:ListItem Text="租赁" Value="10"></asp:ListItem>
                    <asp:ListItem Text="私人" Value="11"></asp:ListItem>
                    <asp:ListItem Text="其他" Value="12"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <div class="label">
                <label>销售价格（万元）:</label>
            </div>
            <div class="field">
                <asp:TextBox ID="txtCarPrice" runat="server" class="input" AutoComplete="false"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" CssClass="colorred" ErrorMessage="请填入销售价格" ControlToValidate="txtCarPrice" Display="Dynamic"></asp:RequiredFieldValidator>
                <%-- 2016年7月19日 按客户需求，改为万元单位，正则表达式限制为1-6位小数 --%>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" CssClass="colorred" ErrorMessage="销售价格的格式不正确" ControlToValidate="txtCarPrice" Display="Dynamic" ValidationExpression="^(0|[1-9][0-9]{0,9})(\.[0-9]{1,6})?$"></asp:RegularExpressionValidator>
            </div>
        </div>

        <div class="form-group">
            <div class="label">
                <label>采购日期:</label>
            </div>
            <div class="field">
                <asp:TextBox ID="txtBuyDate" runat="server" class="input readonly" AutoComplete="false"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="txtBuyDate_CalendarExtender" runat="server" BehaviorID="txtBuyDate_CalendarExtender" TargetControlID="txtBuyDate"></ajaxToolkit:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" CssClass="colorred" ErrorMessage="请填入采购日期" ControlToValidate="txtBuyDate" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group">
            <div class="label">
                <label>注册登记日期:</label>
            </div>
            <div class="field">
                <asp:TextBox ID="txtRegDate" runat="server" class="input readonly" AutoComplete="false"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="txtRegDate_CalendarExtender" runat="server" BehaviorID="txtRegDate_CalendarExtender" TargetControlID="txtRegDate"></ajaxToolkit:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" CssClass="colorred" ErrorMessage="请填入注册登记日期" ControlToValidate="txtRegDate" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group">
            <div class="label">
                <label>电池类型:</label>
            </div>
            <div class="field">
                <asp:TextBox ID="txtBatClass" runat="server" class="input" AutoComplete="false"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" CssClass="colorred" ErrorMessage="请填入电池类型" ControlToValidate="txtBatClass" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group">
            <div class="label">
                <label>电池单体型号:</label>
            </div>
            <div class="field">
                <asp:TextBox ID="txtBatKind" runat="server" class="input" AutoComplete="false"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" CssClass="colorred" ErrorMessage="请填入电池单体型号" ControlToValidate="txtBatKind" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group">
            <div class="label">
                <label>电池总容量(KWh):</label>
            </div>
            <div class="field">
                <asp:TextBox ID="txtBatSize" runat="server" class="input" AutoComplete="false"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" CssClass="colorred" ErrorMessage="请填入电池总容量" ControlToValidate="txtBatSize" Display="Dynamic"></asp:RequiredFieldValidator>
                <%-- 2016年7月19日 电池容量正则表达式改为支持1-2位小数（原来为必须2位小数，是bug） --%>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" CssClass="colorred" ErrorMessage="容量格式不正确" ControlToValidate="txtBatSize" Display="Dynamic" ValidationExpression="^(0|\d+)(\.\d{1,2})?$"></asp:RegularExpressionValidator>
            </div>
        </div>

        <div class="form-group">
            <div class="label">
                <label>电池生产厂家:</label>
            </div>
            <div class="field">
                <asp:TextBox ID="txtBatProduct" runat="server" class="input" AutoComplete="false"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" CssClass="colorred" ErrorMessage="请填入电池生产厂家" ControlToValidate="txtBatProduct" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group">
            <div class="label">
                <label>电机型号:</label>
            </div>
            <div class="field">
                <asp:TextBox ID="txtMotKind" runat="server" class="input" AutoComplete="false"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" CssClass="colorred" ErrorMessage="请填入电机型号" ControlToValidate="txtMotKind" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group">
            <div class="label">
                <label>电机生产厂家:</label>
            </div>
            <div class="field">
                <asp:TextBox ID="txtMotProduct" runat="server" class="input" AutoComplete="false"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" CssClass="colorred" ErrorMessage="请填入电机生产厂家" ControlToValidate="txtMotProduct" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group">
            <div class="label">
                <label>发动机型号:</label>
            </div>
            <div class="field">
                <asp:TextBox ID="txtEngKind" runat="server" class="input" AutoComplete="false"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" CssClass="colorred" ErrorMessage="请填入发动机型号" ControlToValidate="txtEngKind" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <div class="label">
                <label>发动机生产厂家:</label>
            </div>
            <div class="field">
                <asp:TextBox ID="txtEngProduct" runat="server" class="input" AutoComplete="false"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" CssClass="colorred" ErrorMessage="请填入发动机生产厂家" ControlToValidate="txtEngProduct" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>

        <!--图片上传预览 -->
        <div style="clear: both; width: 100%; height: 230px;">

            <ul id="warp">
                <li style="width: 50%; float: left">
                    <p>
                        车辆购置发票复印件：<a class="button input-file" href="javascript:void(0);">+ 浏览文件<asp:FileUpload ID="up_img_WU_FILE_0" ClientIDMode="Static" runat="server" /></a>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" CssClass="colorred" ErrorMessage="请上传车辆购置发票复印件" ControlToValidate="up_img_WU_FILE_0" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ValidationExpression=".*(.jpg|.png)$" CssClass="colorred" ErrorMessage="只能上传jpg或png格式的图片,且大小不能超过200kB" ControlToValidate="up_img_WU_FILE_0" Display="Dynamic"></asp:RegularExpressionValidator>
                        <asp:CustomValidator ID="cvCarBill_img" runat="server" ControlToValidate="up_img_WU_FILE_0" CssClass="colorred" ErrorMessage="图片大于200kB,请处理后重新上传" Display="Dynamic" OnServerValidate="cvCarBill_img_ServerValidate"></asp:CustomValidator>
                        <asp:Image ID="imgShow_WU_FILE_0" ClientIDMode="Static" runat="server" Width="150" Height="100" />
                    </p>

                    <div id="div_carbill_img" runat="server"></div>
                </li>
                <li style="width: 50%; float: left">
                    <p>
                        车辆登记证书：<a class="button input-file" href="javascript:void(0);">+ 浏览文件<asp:FileUpload ID="up_img_WU_FILE_1" ClientIDMode="Static" runat="server" /></a>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" CssClass="colorred" ErrorMessage="请上传车辆登记证书照片" ControlToValidate="up_img_WU_FILE_1" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ValidationExpression=".*(.jpg|.png)$" CssClass="colorred" ErrorMessage="只能上传jpg或png格式的图片,且大小不能超过200kB" ControlToValidate="up_img_WU_FILE_1" Display="Dynamic"></asp:RegularExpressionValidator>
                        <asp:CustomValidator ID="cvCarCLDJZ" runat="server" ControlToValidate="up_img_WU_FILE_1" CssClass="colorred" ErrorMessage="图片大于200kB,请处理后重新上传" Display="Dynamic" OnServerValidate="cvCarCLDJZ_ServerValidate"></asp:CustomValidator>
                        <asp:Image ID="imgShow_WU_FILE_1" ClientIDMode="Static" runat="server" Width="150" Height="100" />
                    </p>
                    <div id="div_carcldjz_img" runat="server"></div>
                </li>
                <li style="width: 50%; float: left">
                    <p>
                        车辆一致性证书：<a class="button input-file" href="javascript:void(0);">+ 浏览文件<asp:FileUpload ID="up_img_WU_FILE_2" ClientIDMode="Static" runat="server" /></a>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" CssClass="colorred" ErrorMessage="请上传车辆一致性证书照片" ControlToValidate="up_img_WU_FILE_2" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ValidationExpression=".*(.jpg|.png)$" CssClass="colorred" ErrorMessage="只能上传jpg或png格式的图片,且大小不能超过200kB" ControlToValidate="up_img_WU_FILE_2" Display="Dynamic"></asp:RegularExpressionValidator>
                        <asp:CustomValidator ID="cvCarCLYZXZS" runat="server" ControlToValidate="up_img_WU_FILE_2" CssClass="colorred" ErrorMessage="图片大于200kB,请处理后重新上传" Display="Dynamic" OnServerValidate="cvCarCLYZXZS_ServerValidate"></asp:CustomValidator>
                        <asp:Image ID="imgShow_WU_FILE_2" ClientIDMode="Static" Width="150" Height="100" runat="server" />
                    </p>
                    <div id="div_carclyzxzs_img" runat="server"></div>
                </li>
                <li style="width: 50%; float: left">
                    <p>
                        行驶证复印件：<a class="button input-file" href="javascript:void(0);">+ 浏览文件<asp:FileUpload ID="up_img_WU_FILE_3" ClientIDMode="Static" runat="server" /></a>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" CssClass="colorred" ErrorMessage="请上传行驶证图片" ControlToValidate="up_img_WU_FILE_3" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ValidationExpression=".*(.jpg|.png)$" CssClass="colorred" ErrorMessage="只能上传jpg或png格式的图片,且大小不能超过200kB" ControlToValidate="up_img_WU_FILE_3" Display="Dynamic"></asp:RegularExpressionValidator>
                        <asp:CustomValidator ID="cvCarXSZ" runat="server" ControlToValidate="up_img_WU_FILE_3" CssClass="colorred" ErrorMessage="图片大于200kB,请处理后重新上传" Display="Dynamic" OnServerValidate="cvCarXSZ_ServerValidate"></asp:CustomValidator>
                        <asp:Image ID="imgShow_WU_FILE_3" ClientIDMode="Static" Width="150" Height="100" runat="server" />
                    </p>
                    <div id="div_carxsz_img" runat="server"></div>
                </li>
            </ul>


        </div>
        <!-- 图片上传预览 -->
    </div>
    <div>

        <div class="form-button floatright">
            <asp:Button ID="btnSave" class="button bg-main" runat="server" Text="保存" OnClick="btnSave_Click" />
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
            //点击关闭,关闭弹出层
            $("#div_btn_close").click(function () {
                $("#div_bigimg").fadeOut(0);
            });
        });
    </script>
    <%-- 大图弹出层 js 部分结束 --%>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".readonly").attr("readonly", "readonly");
            $(".readonly").css("cursor", "pointer");
            $(".readonly").attr("placeholder", "点击以选择日期");
        });
    </script>
</asp:Content>

