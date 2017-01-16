<%@ Page Title="" Language="C#" MasterPageFile="~/mst0.master" AutoEventWireup="true" CodeFile="resetpwd.aspx.cs" Inherits="resetpwd" %>

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
        <p>重置用户密码</p>

		<div class="form-group" >
                    <div class="label"><label for="sitename" style="float:left">用户账号:</label></div>
                    <div class="field">
                    	<asp:TextBox ID="txtUserAccount" CssClass="input" runat="server" placeHolder="请输入用户账号" />
                        <asp:Button ID="btnResetpwd" CssClass="button bg-main" runat="server" Text="重置密码" OnClick="btnResetpwd_Click" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="colorred" ErrorMessage="请输入用户账号" ControlToValidate="txtUserAccount" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="cvUserAccount" runat="server" CssClass="colorred" ErrorMessage="输入的账号不存在" ControlToValidate="txtUserAccount" Display="Dynamic" OnServerValidate="cvUserAccount_ServerValidate"></asp:CustomValidator>
                    </div>
            </div>
        <div>
            <asp:Label ID="lbResult" runat="server" Text="" />
        </div>
    </div>
</asp:Content>

