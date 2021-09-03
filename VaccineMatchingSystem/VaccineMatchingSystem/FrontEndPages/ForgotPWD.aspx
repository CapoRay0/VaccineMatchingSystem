<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FrontMaster.Master" AutoEventWireup="true" CodeBehind="ForgotPWD.aspx.cs" Inherits="VaccineMatchingSystem.FrontEndPages.ForgetPWD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <asp:Label ID="lblName" runat="server" Text="請輸入姓名"></asp:Label>
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />
    <asp:Label ID="lblID" runat="server" Text="請輸入身分證(ID)"></asp:Label>
    <asp:TextBox ID="txtID" runat="server"></asp:TextBox><br />
    <asp:Label ID="lblNewPWD" runat="server" Text="">請輸入新密碼</asp:Label>
    <asp:TextBox ID="txtNewPWD" runat="server"></asp:TextBox><br />
    <asp:Label ID="lblPWDconf" runat="server" Text="確認新密碼"></asp:Label>
    <asp:TextBox ID="txtPWDconf" runat="server"></asp:TextBox><br />
    <asp:Literal ID="litMSG" runat="server"></asp:Literal><br />
    <asp:Button ID="btnConfirm" runat="server" Text="確認送出" OnClick="btnConfirm_Click"/>
    </div>
</asp:Content>
