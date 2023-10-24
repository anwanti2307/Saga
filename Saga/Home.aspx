<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Saga.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .Love {
            color: black;
            font-family: Centaur;
            font-size: 20px;
        }
   
    </style>
    <div style="text-align: center;">
        <asp:Label Class="label Love " runat="server">You Will Love It</asp:Label>
    </div>
    <br />
    <div style="text-align: center;">
      <asp:HyperLink style=" font-size: 17px;font-weight: bold; font-family: 'Centaur';" ID="hplView" runat="server" NavigateUrl="./ViewAll.aspx">View All</asp:HyperLink>
    </div>
    <br />
    <div>
       <table>
    <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
        <ItemTemplate>
            <tr>
                <td><%# Eval("Title") %></td>
                <td>
                    <asp:DataList ID="dlImages" runat="server" DataKeyField="ID" RepeatDirecton="Horizontal" RepeatColumns="3" CellPadding="5">
                        <ItemTemplate>
                            <a id="imageLink" href="~/SlideImages/<%# Eval("filename") %>" title="<%# Eval("imageDesc") %>" rel="lightbox[Brussels]">
                                <asp:Image ID="Image1" ImageUrl='<%# "~/SlideImages/" + Eval("filename") %>' runat="server" Width="112" Height="84" />
                            </a>
                        </ItemTemplate>
                    </asp:DataList>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</table>
    </div>
</asp:Content>
