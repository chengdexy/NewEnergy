<%@ Page Title="" Language="C#" MasterPageFile="~/mst0.master" AutoEventWireup="true" CodeFile="addreport.aspx.cs" Inherits="addreport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .panel {
            float: left;
            margin-bottom: 30px;
            width: 33%;
        }

        .table td {
            border: 0px !important;
            border-bottom: 1px dashed #ccc !important;
        }
		.carinfobox div table{
		 width:100%;
		 border:0px;
		}
		.carinfotable th{
		  border:1px solid #ccc;
		  background-color:#f5f5f5;
		}
		.carinfotable td{
		  border:1px solid #ccc !important;
		}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- <div id="div_table_report_info" runat="server" class="table_div">
        <%-- 信息表:后台代码生成 --%>
        
    </div> -->
        <p>
	       <span>
                   <asp:Button ID="btnUpdate" CssClass="button button-small border-green" runat="server" Text="保存并上报" OnClick="btnUpdate_Click" />
              </span>
        </p>
	 <div id="div_hasReported" runat="server" visible="false">
        <p class="alert alert-yellow">
			    <span>您有一份报表正在审核中，暂不能生成新报表。当该报表通过审核或被退回时，您可以再次申请。</span>
			    
		</p>
			 
    </div>
     <p>
       <span>新能源汽车推广应用补贴资金申请审核表</span>
		<span>
           <asp:Button ID="btnExport_info" CssClass="button button-small border-blue" runat="server" Text="导出申请审核表" OnClick="btnExport_info_Click" />
       </span>
     </p>

    <asp:ListView ID="ListView1" runat="server" ItemPlaceholderID="itemHolder" DataSourceID="adsUserInfo">
        <LayoutTemplate>
            <div id="itemHolder" runat="server"></div>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="panel" style="border-right: 0px;">
                <div class="panel-head"><strong>申请人信息</strong></div>
                <table class="table">
                    <tr>
                        <td width="150" align="right">申请人类型：</td>
                        <td><%# Convert.ToInt32( Eval("user_class"))==1?"单位":"个人" %></td>
                    </tr>
                    <tr>
                        <td align="right"><%# Convert.ToInt32( Eval("user_class"))==1?"名称":"姓名" %>：</td>
                        <td><%# Convert.ToInt32( Eval("user_class"))==1?Eval("user_companyname"):Eval("user_username") %></td>
                    </tr>
                    <tr>
                        <td align="right"><%# Convert.ToInt32( Eval("user_class"))==1?"组织机构代码证号":"身份证号码" %>：</td>
                        <td><%# Convert.ToInt32( Eval("user_class"))==1?Eval("user_ZZJGDMZ_id"):Eval("user_useridcard") %></td>
                    </tr>
                </table>
            </div>
            <div class="panel" style="border-left: 0px; border-right: 0px;">
                <div class="panel-head"><strong>联系方式</strong></div>
                <table class="table">
                    <tr>
                        <td width="110" align="right">联系人姓名：</td>
                        <td><%# Convert.ToInt32( Eval("user_class"))==1?Eval("user_username"):" - " %></td>
                    </tr>
                    <tr>
                        <td align="right">固定电话：</td>
                        <td><%#Eval("user_userphone") %></td>
                    </tr>
                    <tr>
                        <td align="right">手机号码：</td>
                        <td><%#Eval("user_usermobile") %></td>
                    </tr>
                </table>
            </div>
            <div class="panel" style="border-left: 0px;">
                <div class="panel-head"><strong>银行账户信息</strong></div>
                <table class="table">
                    <tr>
                        <td width="110" align="right">户名：</td>
                        <td><%#Eval("user_bankcardname") %></td>
                    </tr>
                    <tr>
                        <td align="right">开户银行：</td>
                        <td><%#Eval("user_bankname") %></td>
                    </tr>
                    <tr>
                        <td align="right">账号：</td>
                        <td><%#Eval("user_bankcardid") %></td>
                    </tr>
                </table>
            </div>
        </ItemTemplate>
    </asp:ListView>


    <asp:AccessDataSource ID="adsUserInfo" runat="server" DataFile="~/App_Data/Data.mdb" SelectCommand="SELECT * FROM [tUserAccount] WHERE ([user_account] = ?)">
        <SelectParameters>
            <asp:SessionParameter Name="user_account" SessionField="user_account" Type="String" />
        </SelectParameters>
    </asp:AccessDataSource>


    <div class="carinfobox clearboth">
        <%-- 车辆表:gridview --%>
        <p>
		  <span>车辆信息情况表</span>
		  <span>
			   <asp:Button ID="btnExport_cars" CssClass="button button-small border-yellow" runat="server" Text="导出车辆情况表" OnClick="btnExport_cars_Click" />
		   </span>
		 </p>
        <%--<p class="alert alert-yellow">您没有未上报的车辆信息,无法生成套表.<a href="addcars.aspx" style="color: blue;">点击这里添加</a></p>--%>

        <asp:GridView ID="GridView1" runat="server" CssClass="table carinfotable" AutoGenerateColumns="False" DataKeyNames="car_id" DataSourceID="AccessDataSource1">
            <Columns>
                <asp:TemplateField HeaderText="序号" InsertVisible="false">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="car_number" HeaderText="车牌号" SortExpression="car_number" />
                <asp:BoundField DataField="car_vin" HeaderText="车辆识别码(VIN)" SortExpression="car_vin" />
                <asp:BoundField DataField="car_brand" HeaderText="品牌" SortExpression="car_brand" />
                <asp:BoundField DataField="car_kind" HeaderText="型号" SortExpression="car_kind" />
                <asp:BoundField DataField="car_use" HeaderText="用途" SortExpression="car_use" />
                <asp:BoundField DataField="car_buydate" HeaderText="采购日期" SortExpression="car_buydate" DataFormatString="{0:d}" />
                <asp:BoundField DataField="car_regdate" HeaderText="注册登记日期" SortExpression="car_regdate" DataFormatString="{0:d}" />
                <asp:BoundField DataField="car_batkind" HeaderText="电池单体型号" SortExpression="car_batkind" />
                <asp:BoundField DataField="car_batsize" HeaderText="电池总容量(KWh)" SortExpression="car_batsize" />
            </Columns>

            <EmptyDataTemplate>
                <p class="alert alert-yellow">您没有未上报的车辆信息,无法生成套表.<a href="addcars.aspx" style="color: blue;">点击这里添加</a></p>

            </EmptyDataTemplate>
        </asp:GridView>
        <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/Data.mdb" SelectCommand="SELECT * FROM [tCars] WHERE (([car_user] = ?) AND ([car_reported] = ?))">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="" Name="car_user" SessionField="user_account" Type="String" />
                <asp:Parameter DefaultValue="false" Name="car_reported" Type="Boolean" />
            </SelectParameters>
        </asp:AccessDataSource>
        
    </div>
   

</asp:Content>

