<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Saga.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .Love {
            color: black;
            font-family: Centaur;
            font-size: 20px;
        }

        .container {
            width: 100%;
               margin-top:50px;
        }

        .header {
            width: 100%;
            /*padding: 8px 14px;*/
            background: #d3c9c9;
            color: pink;
        }
    </style>
    <div style="text-align: center;">
        <asp:Label Class="label Love " runat="server">You Will Love It</asp:Label>
    </div>
    <br />
    <div style="text-align: center;">
        <asp:HyperLink Style="font-size: 17px; font-weight: bold; font-family: 'Centaur';" ID="hplView" runat="server" NavigateUrl="./Category.aspx">View All</asp:HyperLink>
    </div>
    <br />
    <div>
        <table>
            <asp:Repeater ID="rptrImages" runat="server">
                <ItemTemplate>


                    <%--<td><%# Eval("ID") %></td>--%>
                    <td>
                        <%--<div ID="dlImages" runat="server" RepeatDirecton="Horizontal" RepeatColumns="3" CellPadding="5">--%>
                        <itemtemplate style="float: left">
                            <a id="imageLink" href="Product?ID=<%# Eval("ID") %>">
                                <asp:Image ID="imgtraditional" ImageUrl='<%# "~/ProductImages/" + Eval("ID") +Eval("FileType")%>' runat="server" Width="218" Height="330" />
                            </a>
                        </itemtemplate>
                        <br />
                        <div style="text-align: center;">
                            <asp:Label Style="font-size: 14px;" runat="server"><%# Eval("ProductName") %></asp:Label>
                            <br />

                            <asp:Label Style="font-size: 14px;" runat="server"><%#"Rs."+ Eval("SizeMPrice") %></asp:Label>

                        </div>
                        <%--</div>--%>
                    </td>

                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <br />
    <br />
    <div style="text-align: center;">
        <asp:Label Style="font-size: 25px; font-family: Centaur;" runat="server">Shop Our Best Selling Categories</asp:Label>
    </div>
    <div>
        <table>
            <asp:Repeater ID="rptrCategory" runat="server">
                <ItemTemplate>


                    <td>
                        <itemtemplate style="float: left">
                            <a style="text-decoration: none" id="imageLink" href="Category.aspx?CId=<%# Eval("Id") %>">
                                <asp:Image ID="imgCategory" ImageUrl='<%# "~/ProductImages/ProductCategory/" + Eval("FileId") +Eval("FileType")%>' runat="server" Width="274" Height="330" />
                                <%--            <div style="background-image:url(/ProductImages/7.jpg); Width:274px; Height:330px">--%>

                                <asp:Label ID="LblCategory" runat="server" Style="color: whitesmoke; font-size: 25px; position: relative; top: -180px; left: 40%"><%# Eval("CategoryName") %></asp:Label>

                            </a>

                        </itemtemplate>
                    </td>

                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
</asp:Content>
