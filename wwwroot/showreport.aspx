<%@ Page Title="" Language="C#" MasterPageFile="~/mst0.master" AutoEventWireup="true" CodeFile="showreport.aspx.cs" Inherits="showreport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        td {
            border: 1px solid red;
            padding: 10px;
        }

        .div_pop {
		    width:500px;
			height:350px;
        }
		.carinfobox{
		  margin-top:10px;
		}
		.checktable th{
		  border-right:1px solid #ccc;
		}
		.checktable td{
		  border:0px;
		  border-bottom:1px dashed #ccc;
		}
		.checktable tr td:nth-child(2),.checktable tr td:nth-child(4){
		 border-right:1px solid #ccc;
		}
		.panel-body {
		  height:240px;
		}
		.panel-body li{
		  list-style-type:none;
		  border:0px !important;
		}
		.panel-foot{
		  text-align:right;
		}
		.textaerebox{
		  width:300px;
		  vertical-align:top;
		}
		.modalbox table td {
			  border:0px !important;
			  padding:5px !important;
			}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- 报表详情页
        1. 根据用户身份不同,显示不同的提交按钮组
        2. 根据报表的当前状态不同,显示不同的提交按钮组
        3. 提供图片信息展示的功能,暂定HyperLink样式的Button,点击时弹出层显示
        
    --%>
    <div>
        <asp:Button ID="btnUpdate" CssClass="button bg-main" runat="server" Text="上报报表" Visible="False" OnClick="btnUpdate_Click" />
        <asp:Button ID="btnCheck" CssClass="button bg-main" runat="server" Text="审核报表" Visible="False" />
        <asp:Button ID="btnError" CssClass="button bg-main" runat="server" Text="查看不通过原因" Visible="False" />
        <asp:Button ID="btnDelete" CssClass="button bg-main" runat="server" Text="删除此报表" Visible="False" OnClick="btnDelete_Click" />
        <ajaxToolkit:ModalPopupExtender ID="btnError_ModalPopupExtender" runat="server" BehaviorID="btnError_ModalPopupExtender" DynamicServicePath="" TargetControlID="btnError" PopupControlID="div_unpass_reason" CancelControlID="btnCloseReason">
        </ajaxToolkit:ModalPopupExtender>
        <ajaxToolkit:ModalPopupExtender ID="btnCheck_ModalPopupExtender" runat="server" BehaviorID="btnBack_ModalPopupExtender" DynamicServicePath="" TargetControlID="btnCheck" PopupControlID="div_pop" CancelControlID="btnCancel">
        </ajaxToolkit:ModalPopupExtender>
    </div>
    <div>
        <asp:ListView ID="lvReportInfo" runat="server" ItemPlaceholderID="itemReportInfo" DataSourceID="adsInfo">
            <LayoutTemplate>
                <div id="itemReportInfo" runat="server"></div>
            </LayoutTemplate>
            <ItemTemplate>
                <p style="color:#F60"><b>报表id:<%#Eval("report_id") %>当前状态:<%#Eval("report_state") %></b></p>
				 <div class="panel">
					<div class="panel-head"><strong>新能源汽车推广应用补贴资金申请审核表</strong></div>
					<table class="table checktable">
					    <tr>
						  <th colspan="2" style="border-left:1px solid #ccc;">申请人信息</th>
						  <th colspan="2">申请人联系方式</th>
						  <th colspan="2">银行账户信息</th>
						</tr>
						<tr>
						  <td>申请人类型:</td>
						  <td><%# Convert.ToInt32( Eval("report_class"))==1?"单位":"个人" %></td>
						  <td>联系人姓名:</td>
						  <td><%#Eval("report_contact") %></td>
						  <td>户名:</td>
						  <td><%#Eval("report_bankcardname") %></td>
						</tr>
						<tr>
						  <td><%# Convert.ToInt32( Eval("report_class"))==1?"名称":"姓名" %>:</td>
						  <td><%#Eval("report_name") %></td>
						  <td>固定电话:</td>
						  <td><%#Eval("report_phone") %></td>
						  <td>开户行:</td>
						  <td><%#Eval("report_bankname") %></td>
						</tr>
						<tr>
						  <td><%# Convert.ToInt32( Eval("report_class"))==1?"组织机构代码证号":"身份证号码" %>:</td>
						  <td><%#Eval("report_number") %></td>
						  <td>手机号码:</td>
						  <td><%#Eval("report_mobile") %></td>
						  <td>账号:</td>
						  <td><%#Eval("report_bankcardid") %></td>
						</tr>
						<!-- <tr>
						                        <td>申请人信息</td>
						                        <td>申请人类型</td>
						                        <td><%# Convert.ToInt32( Eval("report_class"))==1?"单位":"个人" %></td>
						                        <td><%# Convert.ToInt32( Eval("report_class"))==1?"名称":"姓名" %></td>
						                        <td><%#Eval("report_name") %></td>
						                        <td><%# Convert.ToInt32( Eval("report_class"))==1?"组织机构代码证号":"身份证号码" %></td>
						                        <td><%#Eval("report_number") %></td>
						                    </tr>
						                    <tr>
						                        <td>申请人联系方式</td>
						                        <td>联系人姓名</td>
						                        <td><%#Eval("report_contact") %></td>
						                        <td>固定电话</td>
						                        <td><%#Eval("report_phone") %></td>
						                        <td>手机号码</td>
						                        <td><%#Eval("report_mobile") %></td>
						                    </tr>
						                    <tr>
						                        <td>银行账户信息</td>
						                        <td>户名</td>
						                        <td><%#Eval("report_bankcardname") %></td>
						                        <td>开户行</td>
						                        <td><%#Eval("report_bankname") %></td>
						                        <td>账号</td>
						                        <td><%#Eval("report_bankcardid") %></td>
						                    </tr> -->
					</table>
                </div>
                
            </ItemTemplate>
        </asp:ListView>
        <asp:AccessDataSource ID="adsInfo" runat="server" DataFile="~/App_Data/Data.mdb" SelectCommand="SELECT tReport.report_check_back_reason,tReport.report_id, tReport.report_state, tReport.report_account, tReport.report_class, tReport.report_district, tReportUser.report_name, tReportUser.report_number, tReportUser.report_contact, tReportUser.report_phone, tReportUser.report_mobile, tReportUser.report_bankcardname, tReportUser.report_bankcardid, tReportUser.report_bankname FROM (tReport INNER JOIN tReportUser ON tReport.report_id = tReportUser.report_id) WHERE ([tReport.report_id] = ?) ">
            <SelectParameters>
                <asp:QueryStringParameter Name="report_id" QueryStringField="id" Type="String" />
            </SelectParameters>
        </asp:AccessDataSource>
    </div>
	<div class="panel carinfobox">
		<div class="panel-head"><strong>车辆信息情况表</strong></div>
		<asp:GridView ID="gvReportCars" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="adsCars">
            <Columns>
                <asp:TemplateField HeaderText="序号">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="car_number" HeaderText="车牌号" SortExpression="car_number" />
                <asp:BoundField DataField="car_vin" HeaderText="车辆识别代码(VIN)" SortExpression="car_vin" />
                <asp:BoundField DataField="car_product" HeaderText="生产厂家" SortExpression="car_product" />
                <asp:BoundField DataField="car_brand" HeaderText="品牌" SortExpression="car_brand" />
                <asp:BoundField DataField="car_class" HeaderText="类型" SortExpression="car_class" />
                <asp:BoundField DataField="car_kind" HeaderText="型号" SortExpression="car_kind" />
                <asp:BoundField DataField="car_use" HeaderText="用途" SortExpression="car_use" />
                <asp:BoundField DataField="car_price" HeaderText="销售价格" SortExpression="car_price" />
                <asp:BoundField DataField="car_buydate" HeaderText="采购日期" SortExpression="car_buydate" DataFormatString="{0:d}" />
                <asp:BoundField DataField="car_regdate" HeaderText="注册登记日期" SortExpression="car_regdate" DataFormatString="{0:d}" />
                <asp:BoundField DataField="car_batkind" HeaderText="电池单体型号" SortExpression="car_batkind" />
                <asp:BoundField DataField="car_batsize" HeaderText="电池总容量(KWh)" SortExpression="car_batsize" />
            </Columns>
        </asp:GridView>
        <asp:AccessDataSource ID="adsCars" runat="server" DataFile="~/App_Data/Data.mdb" SelectCommand="SELECT * FROM [tReportCars] WHERE ([report_id] = ?)">
            <SelectParameters>
                <asp:QueryStringParameter Name="report_id" QueryStringField="id" Type="String" />
            </SelectParameters>
        </asp:AccessDataSource>
   </div>
   
   <div  id="div_pop" class="panel div_pop modalbox" runat="server">
    	<div class="panel-head"><strong>系统提示</strong></div>
        <div class="panel-body">
            <h3>审核结果:</h3>
            <asp:RadioButtonList ID="rdol_check_result" runat="server">
            				<asp:ListItem Text="审核通过" Value="true" Selected="true" Class="checkok"></asp:ListItem>
            				<asp:ListItem Text="审核不通过" Value="false" Selected="False"></asp:ListItem>
            </asp:RadioButtonList> 
			<!-- <p id="rdol_check_result">
			  <span><input type="radio" value="true" name="rdol_check_result" checked> 审核通过</span>
			  <span><input type="radio" value="false" name="rdol_check_result"> 审核不通过</span>
			</p> -->
			<div>
				请填写不通过原因:
				<asp:TextBox ID="txtCheckResult" runat="server" TextMode="MultiLine" CssClass="textaerebox" PlaceHolder="请填写不通过的原因" MaxLength="255"></asp:TextBox>
          <p style="color:red;display:none;" id="txtCheckResultinfo" CssClass="checkno">请填写不通过的原因</p>  
      </div>
			
        </div>
		<div class="panel-foot">
		  <asp:Button ID="btnOK" runat="server" CssClass="button bg-main" Text="确认"  OnClientClick="return checkblank();" OnClick="btnOK_Click" />
          <asp:Button ID="btnCancel" runat="server" CssClass="button bg-main" Text="取消" />
		</div>
	</div>

	<div  id="div_unpass_reason" class="panel div_pop" runat="server">
    	<div class="panel-head"><strong>系统提示</strong></div>
        <div class="panel-body">
            <h3>未通过原因:</h3>
            <asp:BulletedList ID="BulletedList1" runat="server" DataSourceID="adsReason" DataTextField="report_check_back_reason" DataValueField="report_check_back_reason"></asp:BulletedList>
            <asp:AccessDataSource ID="adsReason" runat="server" DataFile="~/App_Data/Data.mdb" SelectCommand="SELECT [report_check_back_reason] FROM [tReport] WHERE ([report_id] = ?)">
            <SelectParameters>
                <asp:QueryStringParameter Name="report_id" QueryStringField="id" Type="String" />
            </SelectParameters>
            </asp:AccessDataSource>
			
        </div>
		<div class="panel-foot">
		  <asp:Button ID="btnCloseReason" CssClass="button bg-main" runat="server" Text="关闭" />
		</div>
	</div>
	<script>
	  $(".carinfobox table").addClass("table");
	  $(".carinfobox table th").css("border","1px solid #ccc");
	  function checkblank() {
            var radio = document.getElementById("ContentPlaceHolder1_rdol_check_result_1").checked.toString();
            var txt = document.getElementById("ContentPlaceHolder1_txtCheckResult").value.toString();
            
            if (radio == "true" && txt == "") {
                $("#txtCheckResultinfo").show();
                return false;
            }
            else {
                return true;
            }
        }
     $(".checkok input").click(function(){
     	   $("#txtCheckResultinfo").hide();
     	})
	</script>
</asp:Content>

