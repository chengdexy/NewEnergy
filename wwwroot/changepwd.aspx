<%@ Page Title="" Language="C#" MasterPageFile="~/mst0.master" AutoEventWireup="true" CodeFile="changepwd.aspx.cs" Inherits="changepwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
	<style>
		.changepwdbox{
			height:550px;
			}
    .form-group{
	  width:60%;
	  height:60px;
	  margin-top:5px;
	  border-bottom:1px dashed #ccc;
	}
	.label{
	  width:20%;
	  text-align:right;
	  float:left;
	  line-height:30px;
	}
	.input{
	  width:50%;
	}
	.buttonbox{
		width:60%;
		margin:10px;
		text-align:right;
		}
 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="changepwdbox">
        <p>修改密码</p>
        
        <div class="form-group">
				    <div class="label"><label>原密码:</label></div>
					  <div class="field">
					     <asp:TextBox ID="txtSorPassword" TextMode="Password" placeHolder="默认密码为aaaaaa0" runat="server" class="input"></asp:TextBox>
					     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="colorred" ErrorMessage="请输入原密码(默认为aaaaaa0)" ControlToValidate="txtSorPassword" Display="Dynamic"></asp:RequiredFieldValidator>
               <asp:CustomValidator ID="cvSorPassword" runat="server" CssClass="colorred" ErrorMessage="原密码错误" OnServerValidate="cvSorPassword_ServerValidate" Display="Dynamic"></asp:CustomValidator>
					  </div>
		    </div>
		    
		    <div class="form-group">
				    <div class="label"><label>新密码:</label></div>
					  <div class="field">
					     <asp:TextBox ID="txtNewPassword" TextMode="Password" placeHolder="请输入新密码" runat="server" class="input"></asp:TextBox>
					     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="colorred" ErrorMessage="请输入新密码" ControlToValidate="txtNewPassword" Display="Dynamic"></asp:RequiredFieldValidator>
               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" CssClass="colorred" ErrorMessage="密码必须包含字母和数字,且位数为6~10位" ControlToValidate="txtNewPassword" Display="Dynamic" ValidationExpression="((?=.*[0-9].*)(?=.*[A-Za-z].*))[_0-9A-Za-z]{6,10}"></asp:RegularExpressionValidator>
					  </div>
		    </div>

        <div class="form-group">
				    <div class="label"><label>重复新密码:</label></div>
					  <div class="field">
					     <asp:TextBox ID="txtRenewPassword" TextMode="Password" placeHolder="请再输入一次新密码" runat="server" class="input" Display="Dynamic"></asp:TextBox>
					     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="colorred" ErrorMessage="请再输入一次新密码" ControlToValidate="txtRenewPassword" Display="Dynamic"></asp:RequiredFieldValidator>
               <asp:CompareValidator ID="CompareValidator1" runat="server" CssClass="colorred" ErrorMessage="两次输入的新密码不一致" ControlToValidate="txtRenewPassword" ControlToCompare="txtNewPassword" Display="Dynamic"></asp:CompareValidator>
					  </div>
		    </div>


        <div id="div_find_pwd" runat="server">
        	
        	  <div class="form-group">
						    <div class="label"><label>找回密码问题:</label></div>
							  <div class="field">
							     <asp:TextBox ID="txtFindpwd_q"  placeHolder="输入一个问题,用于密码丢失时找回" runat="server" class="input" Display="Dynamic"></asp:TextBox>
							     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="colorred" ErrorMessage="输入一个问题,用于密码丢失时找回" ControlToValidate="txtFindpwd_q" Display="Dynamic"></asp:RequiredFieldValidator>
							  </div>
		        </div>
		        
		        <div class="form-group">
						    <div class="label"><label>找回密码答案:</label></div>
							  <div class="field">
							     <asp:TextBox ID="txtFindpwd_a"  placeHolder="输入答案,用于密码丢失时找回" runat="server" class="input" Display="Dynamic"></asp:TextBox>
							     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" CssClass="colorred" ErrorMessage="输入答案,用于密码丢失时找回" ControlToValidate="txtFindpwd_a" Display="Dynamic"></asp:RequiredFieldValidator>
							  </div>
		        </div>


        </div>
        <div class="form-button buttonbox">
            <asp:Button ID="btnSave" class="button bg-main" runat="server" Text="确认修改" OnClick="btnSave_Click" />
            <asp:Button ID="btnCancel" class="button bg-yellow" runat="server" Text="返回上一页" OnClick="btnCancel_Click" CausesValidation="False" />
        </div>
    </div>
</asp:Content>

