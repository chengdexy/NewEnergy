<%@ Page Title="" Language="C#" MasterPageFile="~/mst0.master" AutoEventWireup="true" CodeFile="manaindex.aspx.cs" Inherits="manaindex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- 
        这里是管理人员首页
        包括2-县级监管 3-市级监管

        此页面显示: 
        1) 权限等级(某县/市级)
        2) 等待审核的报表数量
    --%>
    <div>目前有<asp:Label ID="lbReportCount" runat="server" Text="" />份报表等待您的审核,<a href='reportlist.aspx'>点击查看</a></div>

</asp:Content>

