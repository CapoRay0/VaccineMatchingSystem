<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FrontMaster.Master" AutoEventWireup="true" CodeBehind="ChangePWD.aspx.cs" Inherits="VaccineMatchingSystem.FrontEndPages.ChangePWD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <asp:Label CssClass="col-form-label-lg align-content-center" ID="Label1" runat="server" Text="第一次登入本系統時需要更改密碼"></asp:Label><br /><br />
    <asp:Label CssClass="col-form-label-lg" ID="lblAccount" runat="server" Text="使用者帳號"></asp:Label>
    <asp:TextBox CssClass="form-control" ID="txtAccount" runat="server" placeholder="您的帳號"></asp:TextBox><br />
    <asp:Label CssClass="col-form-label-lg" ID="lblOrigPWD" runat="server" Text="請輸入原密碼"></asp:Label>
    <asp:TextBox CssClass="form-control" ID="txtOrigPWD" runat="server" TextMode="Password" placeholder="您的密碼"></asp:TextBox><br />
    <asp:Label CssClass="col-form-label-lg" ID="lblNewPWD" runat="server" Text="">請輸入新密碼</asp:Label>
    <asp:TextBox CssClass="form-control" ID="txtNewPWD" runat="server" TextMode="Password" placeholder="新的密碼"></asp:TextBox><br />
    <asp:Label CssClass="col-form-label-lg" ID="lblPWDconf" runat="server" Text="確認新密碼"></asp:Label>
    <asp:TextBox CssClass="form-control" ID="txtPWDconf" runat="server" TextMode="Password" placeholder="確認新密碼"></asp:TextBox><br />
    <div class="d-grid gap-2 d-md-flex justify-content-md-end">
    <asp:Button CssClass="btn btn-outline-success btn-lg" ID="btnConfirm" runat="server" Text="確認送出" OnClick="btnConfirm_Click"/></div><br /><br />
    <asp:Label CssClass="col-form-label-lg" ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
