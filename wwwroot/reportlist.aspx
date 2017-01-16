<%@ Page Title="" Language="C#" MasterPageFile="~/mst0.master" AutoEventWireup="true" CodeFile="reportlist.aspx.cs" Inherits="reportlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- 
        
        >>这是上报报表列表页面<<

        2016年6月16日1:18:11
        
        可以使用此页面功能的客户类型有:用户(个人/企业),县级监管,市级监管

        根据客户类型不同,展示的报表不同
        用户:tReport中 report_account==user_account && report_class=user_class
                        其中report_state==0 || report_state==5 (未上报或未通过) 可删除后重新生成上报
                        否则只可查看内容
        县级监管:tReport中 report_district==dis_district && report_state!=0 && report_state!=5
                        可以依次在网络初审通过/现场复审通过/不通过中选择,以更改报表状态
        市级监管:tReport中 report_state==3 || report_state==4
                        即:通过县级审核未通过市级审核,及通过市级审核的报表
                        可以依次在通过市级审核/不通过中选择,以更改报表状态
        县级或是市级只有两个权限:
                查看报表,给出审核结果
        查看报表:
                除去查看报表内容,相关图片文件应在合适的位置以便捷的方式呈现,供与现实文件进行比对
        
        
    --%>
    <div>
        <asp:ListView ID="ListView1" runat="server" ItemPlaceholderID="itemHolder" DataSourceID="adsReport">
            <LayoutTemplate>
                <div id="itemHolder" runat="server"></div>
            </LayoutTemplate>
            <ItemTemplate>
                <div>
                    <a href='showreport.aspx?id=<%#Eval("report_id") %>'><%# Container.DataItemIndex+1 %>. [<%#Eval("report_district") %>]<%#Eval("report_account") %>的报表(生成于:<%#Eval("report_create_time") %>)[<%#Eval("report_state") %>]</a>
                    <a class="button button-small border-blue" href='expuser.aspx?id=<%#Eval("report_id") %>'>导出审核申请表</a>
                    <a class="button button-small border-yellow" href='expcars.aspx?id=<%#Eval("report_id") %>'>导出车辆信息表</a>
                </div>
            </ItemTemplate>
        </asp:ListView>
        <asp:AccessDataSource ID="adsReport" runat="server" DataFile="~/App_Data/Data.mdb" SelectCommand="SELECT * FROM [tReport]"></asp:AccessDataSource>
    </div>
</asp:Content>

