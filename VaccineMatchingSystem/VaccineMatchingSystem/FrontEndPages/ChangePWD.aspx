<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FrontMaster.Master" AutoEventWireup="true" CodeBehind="ChangePWD.aspx.cs" Inherits="VaccineMatchingSystem.FrontEndPages.ChangePWD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <asp:Label ID="lblAccount" runat="server" Text="使用者帳號"></asp:Label>
    <asp:TextBox ID="txtAccount" runat="server"></asp:TextBox><br />
    <asp:Label ID="lblOrigPWD" runat="server" Text="請輸入原密碼"></asp:Label>
    <asp:TextBox ID="txtOrigPWD" runat="server"></asp:TextBox><br />
    <asp:Label ID="lblNewPWD" runat="server" Text="">請輸入新密碼</asp:Label>
    <asp:TextBox ID="txtNewPWD" runat="server"></asp:TextBox><br />
    <asp:Label ID="lblPWDconf" runat="server" Text="確認新密碼"></asp:Label>
    <asp:TextBox ID="txtPWDconf" runat="server"></asp:TextBox><br />
    <asp:Literal ID="litMSG" runat="server"></asp:Literal><br />
    <asp:Button ID="btnConfirm" runat="server" Text="確認送出" OnClick="btnConfirm_Click"/>
    </div>
</asp:Content>
