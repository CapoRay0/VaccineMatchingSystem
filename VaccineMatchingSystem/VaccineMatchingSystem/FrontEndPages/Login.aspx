<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FrontMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VaccineMatchingSystem.FrontEndPages.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script>
        document.body.oncopy = function () {event.returnValue = false}
    </script>

    <div>
        <asp:Label ID="lblAccount" runat="server" Text="帳號"></asp:Label> &nbsp &nbsp &nbsp
        <asp:TextBox ID="txtAccount" runat="server"></asp:TextBox><br />
        <asp:Label ID="lblPWD" runat="server" Text="密碼"></asp:Label> &nbsp &nbsp &nbsp
        <asp:TextBox ID="txtPWD" runat="server" TextMode="Password"></asp:TextBox><br />
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal><br />
        <asp:Label ID="lblVerification" runat="server" Text="驗證碼"></asp:Label>
        <asp:Label ID="lblCode" runat="server" Text="驗證碼"></asp:Label>
        <img src="DrawingVerification.ashx" />
        <asp:TextBox ID="txtConfirmCode" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Button ID="btnLogin" runat="server" Text="登入系統" OnClick="btnLogin_Click"/><br />
        <asp:Button ID="btnForgetPWD" runat="server" Text="忘記密碼" OnClick="btnForgetPWD_Click"/>
    </div>
</asp:Content>
