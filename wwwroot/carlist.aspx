<%@ Page Title="" Language="C#" MasterPageFile="~/mst0.master" AutoEventWireup="true" CodeFile="carlist.aspx.cs" Inherits="carlist" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .item_head {
            padding: 10px;
            border-top: 1px dashed #ccc;
            font-weight: bold;
        }
        .item_head:hover {
            background-color:#ccc;
            cursor:pointer;
        }

        .table tr:nth-child(even) {
            background-color: #f5f5f5;
        }

        .piclistbox {
            margin-top: 10px;
        }

            .piclistbox div {
                height: 230px;
                margin-top: 10px;
                padding-top: 10px;
                border-top: 1px dashed #ccc;
                border-bottom: 1px dashed #ccc;
                width: 25%;
                float: left;
                text-align: center;
            }

                .piclistbox div img {
                    padding: 8px;
                    border: 1px solid #ccc;
                    width: 200px;
                    height: 200px;
                }
        /*
            2016年6月28日20:45:43
            id=Xue
            大图弹出层CSS部分
        */
        #div_bigimg {
            width: 80%;
            height: 80%;
            border: 1px solid black;
            background-color: #fff;
            overflow: auto;
            position: absolute;
            margin: auto;
            top: 0;
            left: 0;
            bottom: 0;
            right: 0;
        }

        #img_bigimg {
            margin: auto;
            position: absolute;
            top: 0;
            left: 0;
            bottom: 0;
            right: 0;
        }

        #div_btn_close {
            padding: 10px;
            background-color: #e8e8e8;
            position: absolute;
            z-index: 10;
            top: 50px;
            left: 50px;
        }
        /*
            大图弹出层CSS部分结束
        */
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- Carlist.aspx 拟上报车辆信息汇总表页面 --%>
    <div>
        <asp:ListView ID="ListView1" runat="server" ItemPlaceholderID="itemHolder" DataSourceID="AccessDataSource1">
            <LayoutTemplate>
                <div id="itemHolder" runat="server"></div>
            </LayoutTemplate>
            <ItemTemplate>
                <div>
                    <div class="item_head">
                        <%-- item头部 --%>
                        <%# Container.DataItemIndex +1 %>. <%#Eval("car_number") %>(<%#Eval("car_vin") %>)
                        <a class="button bg-main" href="addcars.aspx?id=<%#Eval("car_id") %>">编辑</a>
                        <a class="button bg-yellow" onclick="return confirm('确认删除？')" href='delcars.aspx?id=<%#Eval("car_id") %>'>删除</a>
                    </div>
                    <div class="item_body">
                        <div>
                            <%-- item主体 --%>
                            <table class="table">
                                <tr>
                                    <td><b>生产厂家:</b></td>
                                    <td><%#Eval("car_product") %></td>
                                    <td><b>车辆类型:</b></td>
                                    <td><%#Eval("car_class") %></td>
                                </tr>
                                <tr>
                                    <td><b>品牌:</b></td>
                                    <td><%#Eval("car_brand") %></td>
                                    <td><b>型号:</b></td>
                                    <td><%#Eval("car_kind") %></td>
                                </tr>
                                <tr>
                                    <td><b>用途:</b></td>
                                    <td><%#Eval("car_use") %></td>
                                    <td><b>销售价格:</b></td>
                                    <td>$<%#Eval("car_price") %></td>
                                </tr>
                                <tr>
                                    <td><b>采购日期:</b></td>
                                    <td><%#Eval("car_brand") %></td>
                                    <td><b>注册登记日期:</b></td>
                                    <td><%#Eval("car_brand") %></td>
                                </tr>
                                <tr>
                                    <td><b>电池类型:</b></td>
                                    <td><%#Eval("car_batclass") %></td>
                                    <td><b>电池单体型号:</b></td>
                                    <td><%#Eval("car_batkind") %></td>
                                </tr>
                                <tr>
                                    <td><b>电池总容量:</b></td>
                                    <td><%#Eval("car_batsize") %>KWh</td>
                                    <td><b>电池生产厂家:</b></td>
                                    <td><%#Eval("car_batproduct") %></td>
                                </tr>
                                <tr>
                                    <td><b>电机型号:</b></td>
                                    <td><%#Eval("car_motkind") %></td>
                                    <td><b>电机生产厂家:</b></td>
                                    <td><%#Eval("car_motproduct") %></td>
                                </tr>
                                <tr>
                                    <td><b>发动机型号:</b></td>
                                    <td><%#Eval("car_engkind") %></td>
                                    <td><b>发动机生产厂家:</b></td>
                                    <td><%#Eval("car_engproduct") %></td>
                                </tr>

                            </table>

                        </div>
                        <div class="piclistbox">
                            <%-- item图片展示 --%>
                            <div>
                                <img class="img_clicked" src="Upload/Img/bill/<%#Eval("car_bill_img") %>" />
                            </div>
                            <div>
                                <img class="img_clicked" src="Upload/Img/cldjz/<%#Eval("car_cldjz_img") %>" />
                            </div>
                            <div>
                                <img class="img_clicked" src="Upload/Img/clyzxzs/<%#Eval("car_clyzxzs_img") %>" />
                            </div>
                            <div>
                                <img class="img_clicked" src="Upload/Img/xsz/<%#Eval("car_xsz_img") %>" />
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
            <EmptyDataTemplate>
                <div>您尚未添加任何车辆信息,<a href="addcars.aspx">点击这里开始添加!</a></div>
            </EmptyDataTemplate>
        </asp:ListView>
        <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/Data.mdb" SelectCommand="SELECT * FROM [tCars] WHERE (([car_user] = ?) AND ([car_reported] = ?))">
            <SelectParameters>
                <asp:SessionParameter Name="car_user" SessionField="user_account" Type="String" />
                <asp:Parameter DefaultValue="false" Name="car_reported" Type="Boolean" />
            </SelectParameters>
        </asp:AccessDataSource>
    </div>
    <%-- 大图弹出层 html 部分 --%>
    <div id="div_bigimg">
        <a id="div_btn_close">点击这里关闭大图显示</a>
        <img id="img_bigimg" />
    </div>
    <%-- 大图弹出层 html 部分结束 --%>
    <script type="text/javascript">
        var showing = false;
        $(document).ready(function () {
            //抽屉效果---
            $(".item_body").hide();
            $(".item_head").click(function () {
                if (showing) {
                    $("+.item_body", this).hide();
                }
                else {
                    $("+.item_body", this).show(100);
                }
                showing = !showing;
            });
            //弹出大图-------
            $("#div_bigimg").hide();
            $(".img_clicked").click(function () {
                imgurl = this.src;
                $("#img_bigimg").attr("src", imgurl);
                $("#div_bigimg").fadeIn(100);
            });
            $("#div_btn_close").click(function () {
                $("#div_bigimg").fadeOut(0);
            });
        });
    </script>
</asp:Content>

