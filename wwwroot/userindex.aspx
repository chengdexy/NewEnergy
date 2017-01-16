<%@ Page Title="" Language="C#" MasterPageFile="~/mst0.master" AutoEventWireup="true" CodeFile="userindex.aspx.cs" Inherits="userindex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--
        这是用户首页
        用户包括:个人/企业用户
        这里显示通知
                from to 时间 内容 已读
    --%>
    <div>
        <%-- 个人信息 --%>
        <asp:ListView ID="ListView2" runat="server" ItemPlaceholderID="itemHolder2" DataSourceID="adsUser">
            <LayoutTemplate>
                <div id="itemHolder2" runat="server"></div>
            </LayoutTemplate>
            <ItemTemplate>
                <h1>欢迎您,<%#Eval("user_username") %></h1>
                <p>感谢使用《承德市新能源汽车推广应用补贴资金在线填报系统》</p>
            </ItemTemplate>
        </asp:ListView>
        <asp:AccessDataSource ID="adsUser" runat="server" DataFile="~/App_Data/Data.mdb" SelectCommand="SELECT * FROM [tUserAccount] WHERE ([user_account] = ?)">
            <SelectParameters>
                <asp:SessionParameter Name="user_account" SessionField="user_account" Type="String" />
            </SelectParameters>
        </asp:AccessDataSource>
    </div>
    <div>
        <%-- 显示通知 --%>
        <h3>最新消息:</h3>
        <div>
            <asp:ListView ID="ListView1" runat="server" ItemPlaceholderID="itemHolder" DataSourceID="adsNotice">
                <LayoutTemplate>
                    <div id="itemHolder" runat="server"></div>
                </LayoutTemplate>
                <ItemTemplate>
                    <div><%# Container.DataItemIndex+1 %>.来自<%#Eval("notice_from") %>: <%#Eval("notice_content") %> <a class="button button-small border-yellow" onclick="return confirm('确认删除？')" href='delnotice.aspx?id=<%#Eval("notice_id") %>'>删除这条通知</a></div>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <div>您没有任何新消息.</div>
                </EmptyDataTemplate>
            </asp:ListView>
            <asp:AccessDataSource ID="adsNotice" runat="server" DataFile="~/App_Data/Data.mdb" SelectCommand="SELECT * FROM [tNotice] WHERE ([notice_to] = ?) AND ([notice_checked] = FALSE) ORDER BY [notice_date] DESC, [notice_from]">
                <SelectParameters>
                    <asp:SessionParameter Name="notice_to" SessionField="user_account" Type="String" />
                </SelectParameters>
            </asp:AccessDataSource>
        </div>
    </div>
</asp:Content>

