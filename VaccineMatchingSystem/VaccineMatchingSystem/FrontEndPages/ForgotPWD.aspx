<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FrontMaster.Master" AutoEventWireup="true" CodeBehind="ForgotPWD.aspx.cs" Inherits="VaccineMatchingSystem.FrontEndPages.ForgetPWD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br />
    <div>
    <asp:Label CssClass="col-form-label-lg" ID="lblName" runat="server" Text="請輸入姓名"></asp:Label>
    <asp:TextBox CssClass="form-control" ID="txtName" runat="server" placeholder="您的姓名"></asp:TextBox><br />
    <asp:Label CssClass="col-form-label-lg" ID="lblID" runat="server" Text="請輸入身分證(ID)"></asp:Label>
    <asp:TextBox CssClass="form-control" ID="txtID" runat="server" placeholder="您的身分證字號"></asp:TextBox><br />
    <asp:Label CssClass="col-form-label-lg" ID="lblNewPWD" runat="server" Text="">請輸入新密碼</asp:Label>
    <asp:TextBox CssClass="form-control" ID="txtNewPWD" runat="server" TextMode="Password" placeholder="新的密碼"></asp:TextBox><br />
    <asp:Label CssClass="col-form-label-lg" ID="lblPWDconf" runat="server" Text="確認新密碼"></asp:Label>
    <asp:TextBox CssClass="form-control" ID="txtPWDconf" runat="server" TextMode="Password" placeholder="確認新密碼"></asp:TextBox><br />
    <div class="d-grid gap-2 d-md-flex justify-content-md-end">
    <asp:Label CssClass="col-form-label-lg" ID="lblMsg" runat="server" Text=""></asp:Label> &nbsp &nbsp
    <asp:Button class="btn btn-outline-secondary btn-lg" ID="btnBackToLogin" runat="server" Text="返回" OnClick="btnBackToLogin_Click" />
    <asp:Button CssClass="btn btn-outline-success btn-lg" ID="btnConfirm" runat="server" Text="確認送出" OnClick="btnConfirm_Click"/></div>

    </div>
    <br /><br />
</asp:Content>
