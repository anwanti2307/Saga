<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="Saga.Projects.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <link rel="stylesheet"
        href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/all.min.css">
    <style>
        .container {
            width: 100%;
            margin-top: 100px;
        }

    </style>

        <div style="float: left;  margin-left: 150px;">
            <asp:Image ID="imgLogin" ImageUrl="~/ProductImages/Adminlogin.jpg" runat="server" Width="371" Height="346" />

        </div>

        <div style="float: left; padding-left: 50px; padding-bottom: 93px; width: 390px; height: 242px; padding-top: 11px; background-color: #0b0258;">
            <div style="font-weight: 700;color:white; font-size: 20px;">
                <asp:Label runat="server" ID="lblLogo">Welcome Back!</asp:Label>
            </div>
            <div style="margin-top: 6px;color:white; margin-bottom: 10px" color: darkgray">
                <asp:Label runat="server" ID="Label1">Login to Continue</asp:Label>
            </div>
  
            <div style="margin-top: 25px">
                <%--  <div class="input-group-addon"Style="position: absolute; margin-left:20px;margin-top:10px;width:20px;display: block;">
                    <asp:Image runat="server" ID="icnUsername" ImageUrl='~/ProductImages/username.png' 
                        Height="18px" Width="17px" />
                </div>--%>
                <i class="fa fa-user fa-lg" style="position: absolute; margin-left: 20px; margin-top: 20px; display: block;"></i>
                <asp:TextBox runat="server" ID="txtEmailId" Style="text-align: center; border-width: 3px; height: 30px; width: 255px; padding-left: 40px;" placeholder="usernamexyz12@gmail.com">
                </asp:TextBox>
                </div>
              <div>
                <asp:RequiredFieldValidator ID="rfvEmailId" runat="server"
                    ControlToValidate="txtEmailId" ValidationGroup="btnSubmitGrp" ErrorMessage="PLease Insert Email ID." ForeColor="#FF3300"></asp:RequiredFieldValidator>
            </div>
            <div style="margin-top: 5px">
                <i class="fa fa-lock" style="position: absolute; margin-left: 20px; margin-top: 10px; display: block; font-size: 20px"></i>

                <asp:TextBox runat="server" ID="txtPassWord" Style="text-align: center; border-width: 3px; height: 30px; width: 255px; padding-left: 40px;" placeholder="Enter Password" AutoComplete="Off" TextMode="Password"></asp:TextBox>
           </div>
            <div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="txtPassWord" ValidationGroup="btnSubmitGrp" ErrorMessage="PLease Fill Password." ForeColor="#FF3300"></asp:RequiredFieldValidator>
            </div>
                      <div Style="margin-left:45px;font-size:18px;" >
                <asp:Label runat="server" Visible="false" ID="lblinvalidErr" ForeColor="#FF3300">Ínvalid User Credentials</asp:Label>

            </div>
            <div style="margin-top: 25px">
                <asp:Button runat="server" ID="btnSubmit" ValidationGroup="btnSubmitGrp" Text="Submit" Style="border-width: 3px; border-radius: 999px; background-color: #efd9ef; font-size: 19px; height: 35px; width: 130px;" OnClick="btnSubmit_Click" causesvalidation="true" UseSubmitBehavior="false"/>
                <asp:HyperLink runat="server" Style="color: #2fc4c4; margin-left: 42px; font-size: 19px" ID="hplForgotPassword">Forgot Password</asp:HyperLink>
            </div>
        </div>


</asp:Content>
