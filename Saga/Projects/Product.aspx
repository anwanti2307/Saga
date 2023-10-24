<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Product.aspx.cs" Inherits="Saga.Projects.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <link href="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"
        rel="stylesheet" type="text/css" />

    <style>
        * {
            box-sizing: border-box;

        }
        
        .container{
            margin-top:60px;
        }
        .row {
            display: flex;
            flex-direction: row;
            flex-wrap: wrap;
            width: 54%;
        }

        .column {
            flex: 35%;
            width: 100%;
        }

        .pagewidth {
            display: flex;
            width: 100%;
            justify-content: space-between;
            flex-direction: row;
        }

        .Contentdiv {
            width: 45%;
        }

        .rcorners2 {
            border-radius: 50%;
            border: 2px solid black;
            padding: 12px;
            width: 45px;
            height: 45px;
        }

        .ui-widget-content {
            background: #d7dbe6;
        /*    #e5d7e6*/
        }
    </style>
    <div class="mydiv">
        <div class="pagewidth">
            <asp:Repeater ID="rptrProductImages" runat="server">
                <HeaderTemplate>
                    <div class="row">
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="column">

                        <itemtemplate>
                            <a id="imageLink" target="_blank" href='<%#"/ProductImages/AssetImages/"+ Eval("ID")+ Eval("FileType")%>'>
                                <asp:Image ID="imgCategory" ImageUrl='<%# "~/ProductImages/AssetImages/" + Eval("ID") +Eval("FileType")%>' runat="server" Width="281" Height="355" />
                            </a>
                        </itemtemplate>

                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="Contentdiv">
            <div style="text-align: left;" class="ContentDivLabel" runat="server" id="lblPdt">
                <asp:Label runat="server" ID="ltrlContent" Style="color: black; font-family: Centaur; font-size: 27px; font-weight: 900;"></asp:Label>
                <br />
                <asp:Label runat="server" ID="lblSubDescription" Style="color: grey; font-family: Centaur; font-size: 23px; font-weight: 500;"></asp:Label>
                <br />
                <br />
                <asp:Label runat="server" ID="lblPrice" Style="color: black; font-family: Centaur; font-size: 25px; font-weight: bold;"></asp:Label>
                <br />
                <asp:Label runat="server" ID="lbltxinc" Style="color: mediumseagreen; font-family: Arial; font-size: 13px; font-weight: bold;">Inclusive of all Taxes</asp:Label>

                <br />
                <br />
                <asp:Label runat="server" ID="lblSizeAvailable" Style="color: black; font-family: Arial; font-size: 17px;">Select Size</asp:Label>
                <%-- <div>
                                <asp:Label Visible="false" runat="server" ID="LblSizeError" style="color: red; font-family: Arial; font-size: 15px;  " >Please Select a Size</asp:Label>
                                   </div> --%>
                <br />
                <br />


                <asp:Button CssClass="rcorners2" runat="server" ID="lblS" Style="color: black; font-family: Arial; font-size: 13px; font-weight: bold;" Text="S" OnClick="btnSizeS_Click"></asp:Button>
                <asp:Button CssClass="rcorners2" runat="server" ID="lblM" Style="color: black; font-family: Arial; font-size: 13px; font-weight: bold;" Text="M" OnClick="btnSizeMedium_Click"></asp:Button>
                <asp:Button CssClass="rcorners2" runat="server" ID="lblL" Style="color: black; font-family: Arial; font-size: 13px; font-weight: bold;" Text="L" OnClick="btnSizeLarge_Click"></asp:Button>
                <asp:Label Visible="false" runat="server" ID="LblSizeError" Style="color: red; font-family: Arial; font-size: 15px;">Please Select a Size</asp:Label>

                <br />
                <br />
                <asp:Button runat="server" ID="Button1" Style="background-color: #ead3d3; color: black; font-family: Arial; font-size: 20px; font-weight: 500; width: 160px; height: 65px;" Text="Buy Now"></asp:Button>
                <asp:Button runat="server" ID="btnAddCart" Style="background-color: #ead3d3; color: black; font-family: Arial; font-size: 20px; font-weight: 500; width: 160px; height: 65px;" Text="Add to Cart" OnClick="btnAddCart_Click"></asp:Button>

                <br />
                <br />
                <asp:Label runat="server" ID="Label1" Style="color: black; font-family: Arial; font-size: 15px;">  100% Original Products</asp:Label><br />
                <asp:Label runat="server" ID="Label2" Style="color: black; font-family: Arial; font-size: 15px;">Pay on delivery available</asp:Label><br />
                <asp:Label runat="server" ID="Label3" Style="color: black; font-family: Arial; font-size: 15px;">Easy 14 days returns and exchanges</asp:Label><br />
                <br />
                <asp:Label runat="server" ID="Label4" Style="color: black; font-family: Arial; font-size: 17px; font-weight: 600;">ProductDetails</asp:Label><br />
                <asp:Label runat="server" ID="lblProdctdetails" Style="color: black; font-family: Arial; font-size: 11px;"></asp:Label><br />
                <br />
                <asp:Label runat="server" ID="Label5" Style="color: black; font-family: Arial; font-size: 17px; font-weight: bold;">Fabric</asp:Label><br />
                <asp:Label runat="server" ID="lblFabric" Style="color: black; font-family: Arial; font-size: 11px;"></asp:Label><br />



            </div>
        </div>
    </div>
    <div id="modal_dialog" style="display: none">

        <asp:Label runat="server" ID="lblerrMsg" ClientMode="Static"></asp:Label>

    </div>

    <script type="text/javascript">
        function showmodalpopup() {
            //$("#modal_dialog").dialog({
            //    title: "jQuery Dialog Popup",
            //    buttons: {
            //        Close: function () {
            //            $(this).dialog('close');
            //        }
            //    }
            //});
            //return false;
            $("#modal_dialog").dialog({
                width: 400,
                height: 70,

                modal: true,
                hide: { effect: 'drop', duration: 250 },
                resizable: false,
                draggable: false,
                position: "center",
                closeOnEscape: true,
                create: function (event, ui) {
                    $(".ui-widget-header").hide();
                    //#d4c6e5
                    setTimeout(function () {
                        $("#modal_dialog").dialog("close");
                    }, 2000);
                }

            });
        };
    </script>
    <%--<asp:Button ID="btnModalPopup" runat="server" Text="Show Modal Popup" />--%>
    <%--    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>--%>
</asp:Content>

