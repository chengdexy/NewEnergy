<%@ Page Title="" Language="C#" MasterPageFile="~/mst0.master" AutoEventWireup="true" CodeFile="newuser.aspx.cs" Inherits="newuser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
 <style>
  .form-group{
    height:40px;
	width:50%;
  }
   .label{
	  width:20%;
	  text-align:right;
	  float:left;
	  line-height:30px;
	}
	.input{
	  width:30%;
	  float:left;
	  margin-right:10px;
	}
 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <p>生成用户账户</p>
        <div>

		    <!-- <div id="rbl_userclass">
			  <span><input type="radio" name="rbl_userclass" Value="0">个人</span>
			  
			  <span><input type="radio" name="rbl_userclass" Value="1" checked>企业</span>
			</div> -->
           <asp:RadioButtonList ID="rbl_userclass" runat="server">
                <asp:ListItem Text="个人" Value="0" />
                <asp:ListItem Text="企业" Value="1" Selected="True" />
            </asp:RadioButtonList>
            <br />
            <p style="color:#FF6600">请输入拟创建账户人的身份证号码(企业填写经办人的身份证号码)</p>
			<div class="form-group" >
                    <div class="label"><label for="sitename" style="float:left">身份证号码:</label></div>
                    <div class="field">
                    	<asp:TextBox ID="txtIdCard" CssClass="input" runat="server" placeHolder="请输入身份证号码" />
						<asp:Button ID="btnCreat" CssClass="button bg-main" runat="server" Text="创建" OnClick="btnCreat_Click" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="colorred" ErrorMessage="请输入身份证号码" ControlToValidate="txtIdCard" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" CssClass="colorred" ErrorMessage="身份证号码格式不正确" ControlToValidate="txtIdCard" Display="Dynamic" ValidationExpression="^[1-9]([0-9]{16}|[0-9]{13})[xX0-9]$"></asp:RegularExpressionValidator>
                    </div>
            </div>

    </div>
</asp:Content>

