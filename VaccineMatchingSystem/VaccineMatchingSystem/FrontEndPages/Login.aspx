<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FrontMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VaccineMatchingSystem.FrontEndPages.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="lblAccount" runat="server" Text="帳號"></asp:Label> &nbsp &nbsp &nbsp
        <asp:TextBox ID="txtAccount" runat="server"></asp:TextBox>
        <asp:Label ID="lblPWD" runat="server" Text="密碼"></asp:Label> &nbsp &nbsp &nbsp
        <asp:TextBox ID="txtPWD" runat="server"></asp:TextBox><br />
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
    </div>

    <div>
        <asp:Button ID="btnForgetPWD" runat="server" Text="忘記密碼" OnClick="btnForgetPWD_Click"/>
        <asp:Button ID="btnLogin" runat="server" Text="登入" OnClick="btnLogin_Click"/>
    </div>
</asp:Content>
