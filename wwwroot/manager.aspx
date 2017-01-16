<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manager.aspx.cs" Inherits="manager" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%-- 
        这是管理人员(非程序员)登录页面
        可以使用此页面的用户类型包括:
            1) 县级监管(class=2)
            2) 市级监管(class=3)
    --%>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>管理人员入口</title>
    <link rel="stylesheet" href="css/pintuer.css" />
    <link rel="stylesheet" href="css/admin.css" />
    <script src="script/jquery.min.js"></script>
    <script src="script/pintuer.js"></script>
    <script src="script/respond.js"></script>
    <script src="script/admin.js"></script>
    <style>

      .shuoming li{
      	  line-height:35px;
      	  border-bottom:1px dashed #fff;
      	} 
      	.subbtn{
      		width:100px;
      		float:left;
      		}	
   </style>
</head>
<body style="background-color:#edf4fa">
    <div class="container"style="width:100%;padding:0px;">
        <div class="line">
            <div>
                <br />
                <br />
                <br />
                <br />
                <form id="form1" runat="server">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <div style="width:950px;margin:0 auto;">
                    <p><img src="images/index_header.jpg"/>
                    	<a href="Download/购车申请表.xls" style="border-bottom:1px solid;margin-left:200px;color: #0099CC;line-height:4rem">表格下载</a>
                    	<a href="Download/购车申请表.xls" style="border-bottom:1px solid;margin-left:20px;color: #0099CC;line-height:4rem">政策文件下载</a>
                    </p>	
                  </div>
                   <div style="width:100%;height:360px;background-color:#4b74b6;">
                  	<div style="width:950px;margin:0 auto;padding-top:40px;padding-bottom:40px;" >
                    <div style="width:500px;height:250px;padding-right:50px;float:left;color:#fff;margin-top:30px;background-image:url('images/line.jpg');background-position:right;background-repeat:no-repeat;">
                    	<p>说明：</p>
                      <ul class="shuoming">
                         <li>步骤1：请下载2016年新能源购车申请表，自行打印，填写后，报所在县区工信局。</li>
                         <li>步骤2：使用市局发放的账号密码登录本系统。</li>	
                      <ul>	
                    </div>
                    <div class="panel"style="float:left;width:376px;height:272px;margin-left:50px;background-color:#b8c8e1;">
                        <div class="panel-head"  style="background-color:transparent;"><strong>管理人员登陆 &nbsp;</strong><asp:LinkButton ID="btnUser" runat="server" Style="color: #0099CC;" CausesValidation="False" OnClick="btnUser_Click">申请人入口</asp:LinkButton></div>
                        <div class="panel-body" style="padding: 30px;">
                            <div class="form-group">
                                <div class="field field-icon-right" style="width:200px;">
                                    <asp:TextBox ID="txtAccount" runat="server" placeHolder="请输入账号" CssClass="input"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="txtAccount_FilteredTextBoxExtender" runat="server" BehaviorID="txtAccount_FilteredTextBoxExtender" TargetControlID="txtAccount" FilterMode="InvalidChars" InvalidChars="' <>"></ajaxToolkit:FilteredTextBoxExtender>
                                    <span class="icon icon-user"></span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="colorred" ErrorMessage="请输入账号" ControlToValidate="txtAccount" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="field field-icon-right" style="width:200px;">
                                    <asp:TextBox ID="txtPassword" runat="server" placeHolder="请输入密码" TextMode="Password" CssClass="input"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="txtPassword_FilteredTextBoxExtender" runat="server" BehaviorID="txtPassword_FilteredTextBoxExtender" TargetControlID="txtPassword" FilterMode="InvalidChars" InvalidChars="' <>"></ajaxToolkit:FilteredTextBoxExtender>
                                    <span class="icon icon-key"></span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="colorred" ErrorMessage="请输入密码" ControlToValidate="txtPassword" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="form-group" style="text-align: right;padding-top:30px;">
                                <asp:CustomValidator ID="cvCheckLogin" runat="server" CssClass="colorred" ErrorMessage="用户名或密码错误" Display="Dynamic" OnServerValidate="cvCheckLogin_ServerValidate"></asp:CustomValidator>
                                 <asp:Button ID="btnLogin" runat="server" Text="登录" OnClick="btnLogin_Click" CssClass="button button-block bg-main text-big" />
                            </div>
                        </div>
                       </div>
                     </div>
                    </div>
                    <div style="text-align:center;margin-top:90px;">
                       <p>承德市工业和信息化局版权所有 ©2016</p> 
                       <p>联系电话：2050039 &nbsp;&nbsp;通讯地址：双桥区南园路9号</p>	
                       <p style="font-size:10px;">建议使用IE9以上版本浏览器；屏幕分辨率1366以上</p>
                    </div>
                </form>
            </div>
        </div>
    </div>
</body>
</html>
