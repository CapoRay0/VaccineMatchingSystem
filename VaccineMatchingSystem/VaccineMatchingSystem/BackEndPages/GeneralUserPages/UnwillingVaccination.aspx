<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/GeneralUser.Master" AutoEventWireup="true" CodeBehind="UnwillingVaccination.aspx.cs" Inherits="VaccineMatchingSystem.BackEndPages.GeneralUserPages.UnwillingVaccination1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--    <div>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </div>--%>
    
    <div>
        <asp:Label CssClass="col-form-label-lg" ID="lblName" runat="server" Text="姓名"></asp:Label>
        <asp:TextBox CssClass="form-control" ID="txtName" runat="server"></asp:TextBox><br />
        <asp:Label CssClass="col-form-label-lg" ID="lblEmail" runat="server" Text="Email"></asp:Label>
        <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server"></asp:TextBox><br />

        <asp:Label CssClass="col-form-label-lg" ID="lblReaseon" runat="server" Text="請選取不願意施打的原因"></asp:Label>
       
        <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server">
            <asp:ListItem Value="0">系統設計不友善</asp:ListItem>
            <asp:ListItem Value="1">疫苗種類過少</asp:ListItem>
            <asp:ListItem Value="2">基本資料有誤</asp:ListItem>
            <asp:ListItem Value="3">不知道如何使用系統</asp:ListItem>
            <asp:ListItem Value="4">其他原因</asp:ListItem>
        </asp:DropDownList><br />

        <asp:Label CssClass="col-form-label-lg" ID="lblFeedback" runat="server" Text="意見回饋"></asp:Label>
        <textarea class="form-control" id="txtFeedback" cols="20" rows="5" runat="server"></textarea>
        
        <hr />
        <asp:Label CssClass="col-form-label-lg" ID="Label1" runat="server" Text="是否願意收到系統更新後的通知"></asp:Label>
        <asp:RadioButton CssClass="form-control-lg" ID="RBYesFeedback" runat="server" GroupName="ConfirmFeedback" Text="是"/>
        <asp:RadioButton CssClass="form-control-lg" ID="RBNoFeedback" runat="server" GroupName="ConfirmFeedback" Text="否"/><br /><br />
        <div class="d-grid gap-2 d-md-flex justify-content-md-end">
        <asp:Button class="btn btn-outline-secondary" ID="btnClear" runat="server" Text="   重填   " OnClick="btnClear_Click"/> &nbsp &nbsp
        <asp:Button class="btn btn-outline-success" ID="btnSend" runat="server" Text="   送出   " OnClick="btnSend_Click"/>
        </div>
    </div>
</asp:Content>
