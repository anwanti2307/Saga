<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="Saga.Projects.Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        * {
            box-sizing: border-box;
        }

        .container {
            width: 100%;
            margin-top: 50px;
        }

        .rows {
            display: flex;
            flex-direction: row;
            flex-wrap: wrap;
            width: 100%;
        }

        .columns {
            flex: 65%;
            width: 65%;
            flex-basis: 20%
        }
    </style>
    <div>

        <asp:Repeater ID="rptrctgrImages" runat="server">
            <HeaderTemplate>
                <div class="rows">
            </HeaderTemplate>

            <ItemTemplate>

                <div class="">
                    <itemtemplate>
                        <a id="imageLink" href="Product?ID=<%# Eval("ID") %>">
                            <asp:Image ID="imgtraditional" Style="padding-left: 25px; padding-right: 25px; padding-top: 15px;" ImageUrl='<%# "~/ProductImages/" + Eval("ID") +Eval("FileType")%>' runat="server" Width="260" Height="300" />
                        </a>
                    </itemtemplate>

                    <div style="text-align: center;">
                        <asp:Label Style="font-size: 14px;" runat="server"><%# Eval("ProductName") %></asp:Label>
                        <br />

                        <asp:Label Style="font-size: 14px;" runat="server"><%#"Rs."+ Eval("SizeMPrice") %></asp:Label>
                    </div>
                </div>

            </ItemTemplate>
        </asp:Repeater>

    </div>
</asp:Content>
