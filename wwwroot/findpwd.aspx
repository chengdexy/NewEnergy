<%@ Page Language="C#" AutoEventWireup="true" CodeFile="findpwd.aspx.cs" Inherits="findpwd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>承德市新能源汽车推广应用补贴资金在线填报系统</title>
	<link rel="stylesheet" href="css/pintuer.css">
    <link rel="stylesheet" href="css/admin.css">
    <script src="script/jquery.min.js"></script>
    <script src="script/pintuer.js"></script>
    <script src="script/respond.js"></script>
    <script src="script/admin.js"></script>
    <script>
        $(document).ready(function () {
            $("#div_clicktoshow").hide();
        });
    </script>
	<style>
	  .usernamebox span{
	    display:inline-block;
		float:left;
		line-height:30px;
	  }
	  .usernamebox input[type="text"]{
	    width:20%;
		margin-right:10px;
		float:left;
	  }
	  .admin{
	  	 margin-left:380px;
	  	 margin-top:100px;
	  	 border-left:0px;
	  	}
	</style>
</head>
<body>
    <form id="form1" runat="server">
     <!-- logo -->
	<div class="lefter">
	    <div class="logo">
		 <img src="images/logo1.png" width="100" height="60"/>
	    </div>
	</div>
     <!--./logo -->
        <div  class="righter nav-navicon" id="admin-nav">
				   <div class="mainer">
				       <h1 style="font-size:36px;">承德市新能源汽车推广应用补贴资金在线填报系统</h1>
			
			
				   </div>
        </div>
        
      <div class="admin-bread">
		    <ul class="bread">
			    <li style="font-size:16px">找回密码</li>
		    </ul>
		  </div>
		  
<!-- 页面主体开始 -->
        <div class="admin" style="left:0px;">
		<div class="line-big">
		<div class="xm12 homelist">
			<div>
				<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
				<asp:UpdatePanel ID="UpdatePanel1" runat="server">
					<ContentTemplate>
						<div class="usernamebox"><span >请输入要找回密码的账号:</span><asp:TextBox ID="txtUserAccount" runat="server" CssClass="input"></asp:TextBox><asp:Button CssClass="button bg-main" ID="btnAccount" runat="server" Text="确认" OnClick="btnAccount_Click" /></div>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="colorred" ErrorMessage="请填入账号" ControlToValidate="txtUserAccount" Display="Dynamic"></asp:RequiredFieldValidator>
					</ContentTemplate>
				</asp:UpdatePanel>
			</div>
			<div>
				<p class="colorred"><asp:Label ID="lblQuestion" runat="server" Text=""></asp:Label><p>
			</div>
			<div id="div_clicktoshow" runat="server">
				<div class="usernamebox">
					<span>您的答案是:</span><asp:TextBox ID="txtAnswer" runat="server" CssClass="input"></asp:TextBox>
					<asp:Button CssClass="button bg-main" ID="btnFind" runat="server" Text="找回密码" OnClick="btnFind_Click" />
				</div>

			</div>
			<div style="margin-top:20px;">
				<p class="colorred"><asp:Label ID="lblResult" runat="server" Text=""></asp:Label></p>
			</div>
		</div>
	    </div>
	  
	     
     </div>
 <!-- 页面主体结束-->
   <!-- 页面footer开始 -->
<div id="div_mst_foot" class="footer">
		   <p>承德市工业和信息化局版权所有 ©2016</p> 
       <p>联系电话：2050039 &nbsp;&nbsp;通讯地址：双桥区南园路9号</p>	
       <p style="font-size:10px;">建议使用IE9以上版本浏览器；屏幕分辨率1366以上</p>
</div>
             <!-- 页面footer结束 -->
    </form>
    <script>
       $(".admin").width($(document).width()-480);
       $(".admin").height($(document).height()-390);
    </script>
</body>
</html>
