<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Saga.Projects.Cart" %>

<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
         <link rel="stylesheet"
        href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/all.min.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <style>
        .container {
            width: 100%;
               margin-top:50px;
        }
       *{ 
            font-family: 'Lucida Bright' !important; 
        } 
        .header {
            width: 100%;
            /*padding: 8px 14px;*/
            background: #d3c9c9;
            color: pink;
        }
      
    </style>
    <%--    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>--%>

    <table style="float: left;">

        <tr>

            <td>
                 <div style="margin-left:12px;margin-bottom:18px;margin-top:15px;">
                      <asp:CheckBox Style="float: left;margin-right:7px; accent-color: black;" runat="server" Id="chkTotalCart"></asp:CheckBox>
                   
                   <asp:Label Style="font-weight: 700; font-size: 17px;" runat="server" Id="lblTotalchk" ></asp:Label>
                </div>
                <div runat="server">

                    <asp:Repeater ID="rptrCartPRdct" runat="server" OnItemCommand="Repeater1_ItemCommand">
                  
                        <ItemTemplate>

                            <div class="" style="border: 1px solid black; display: flex; width: 100%; justify-content: space-between; flex-direction: row;">
                                <itemtemplate>
                                    <a id="imageLink" href="Product?ID=<%# Eval("ID") %>">
                                        <asp:Image ID="imgtraditional" Style="padding-right: 25px; padding-top: 15px;margin-left:12px;" ImageUrl='<%# "~/ProductImages/" + Eval("ID") +Eval("FileType")%>' runat="server" Width="150" Height="200" />
                                    </a>
                                    <asp:CheckBox Style="float: left; padding-top: 12px; accent-color: black; margin-left:12px;" value='<%# Eval("CartId") %>'  runat="server" Id="chkCart" AutoPostBAck="true" OnCheckedChanged="chkCart_CheckedChanged"></asp:CheckBox>
                                </itemtemplate>

                                <div style="text-align: left; padding-top: 12px; width: 504px;">
                                    <asp:TextBox ID="txtCartId" Visible="false" runat="server" Text='<%#Eval("CartId") %>'></asp:TextBox>

                                    <asp:LinkButton ID="btndelete" runat="server" CommandName="delete">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/ProductImages/deleteicon.png" Height="30px" Width="60px" ImageAlign="Right" />
                                    </asp:LinkButton>
                                    <asp:Label Style="font-weight: 900; font-size: 17px;" runat="server"><%# Eval("ProductName") %></asp:Label>
                                    <br />
                                    <div style="width: 300px">
                                        <asp:Label Style="font-size: 14px;" runat="server"><%# Eval("SubDescription") %></asp:Label>
                                    </div>
                                    <br />
                                    <asp:Label Style="font-size: 14px;" runat="server">Size:</asp:Label>
                                    <asp:Label Style="font-weight: 900; font-size: 17px;" runat="server"><%#Eval("Size") %></asp:Label>
                                    <asp:Label Style="font-size: 14px; padding-left: 25px;" runat="server">Qty:</asp:Label>
                                    <asp:TextBox ID="lblQtys" Visible="false" runat="server" Text='<%#Eval("SizeQty") %>'></asp:TextBox>
                                    <asp:TextBox ID="txtQtyCount" Visible="false" runat="server" Text='<%#Eval("ProductCount") %>'></asp:TextBox>

                                    <asp:DropDownList runat="server" ID="ddlQty">
                                    </asp:DropDownList>
                                    <br />
                                    <asp:Label Style="font-weight: 600; font-size: 15px;" runat="server"><%#"Rs."+ Eval("SizePrice") %></asp:Label>

                                    <br />
                                    <br />
                                    <div>
                                        <asp:Image ID="Image1" ImageUrl='~/ProductImages/returnicon.png' runat="server" Width="15" Height="15" />

                                        <asp:Label Style="font-weight: 400; font-size: 14px;" runat="server">14 days return available</asp:Label>
                                    </div>
                                </div>
                            </div>

                        </ItemTemplate>

                    </asp:Repeater>

                </div>
           
               

                <div id="myModal" class="modal fade" role="dialog">
                    <div class="modal-dialog">

                        <!-- Modal content-->
                        <div class="modal-content">
                         
                            <div class="modal-body">
                                <asp:Label runat="server" ID="lblerrMsg" ClientMode="Static"></asp:Label>
                            </div>

                        </div>

                    </div>
                </div>
   
            </td>
        </tr>
    </table>
     
    <div runat="server" id="EmptyCart" visible="false">
        <div runat="server" style="display: block; margin-left: auto; margin-right: auto; width: 25%; padding-top: 20px;">
            <asp:Image ID="Image1" ImageUrl='~/ProductImages/cuteshopppingbag.png' runat="server" Width="250" Height="200" />

        </div>
        <div>
            <asp:Label runat="server" Style="font-weight: 600; font-size: 15px; display: block; margin-left: auto; margin-right: auto; width: 25%;" Text="Hey ,It Feels So Light!"></asp:Label>
        </div>
        <div>
            <asp:Label runat="server" Style="color: darkgray; display: block; margin-left: auto; margin-right: auto; width: 25%;" Text="There is nothing in your bag.Let's Add some Item."></asp:Label>
        </div>
        <br />
        <div>
            <asp:Button runat="server" Style="color: red; display: block; margin-left: auto; margin-right: auto; width: 25%;" Text="Add Items" />
        </div>
    </div>

    
                     <div style="border: 1px solid black; margin-top:55px;margin-left: 720px;">
                         <div style="margin-top:20px;margin-left: 128px;">
                 <asp:label runat="server" ID="lblPriceDetl" Style="font-weight: 700; font-size: 14px;"></asp:label>
                             </div><br />
                         <div style="margin-bottom:8px">
                         <asp:label runat="server" Style="margin-left:25px;"> Total MRP</asp:label>
                          <asp:label runat="server" Style="float:right;margin-right:25px" ID="lblTotalMRP"> Total MRP</asp:label><br />
                             </div>
                         <div style="margin-bottom:8px">
                          <asp:label runat="server" Style="margin-left:25px"> Delivery Charges</asp:label>
                          <asp:label runat="server" Style="float:right;margin-right:25px" ID="Label1"> Rs.50</asp:label><br />
                             </div>
                         <div style="margin-bottom:8px">
                          <asp:label runat="server" Style="margin-left:25px"> Expected Delivery</asp:label>
                          <asp:label runat="server" Style="float:right;margin-right:25px" ID="Label2"> 14 days</asp:label>
                           </div>
                         <hr />
                          <div style="margin-top:8px">
                          <asp:label runat="server" Style="margin-left:25px;font-weight: 700; font-size: 14px;"> Total Amount</asp:label>
                          <asp:label runat="server" Style="float:right;margin-right:25px;font-weight: 700; font-size: 14px;" ID="lblTotalAmount"> </asp:label>
                           </div><br /><br />
                <asp:Button runat="server" ID="Button1" Style="background-color: #ead3d3; color: black; font-size: 20px; font-weight: 500; width: 300px; height: 45px;margin-left:45px" Text="Place Order"></asp:Button>
                         <br /><br /><br />

                </div>
    
</asp:Content>
