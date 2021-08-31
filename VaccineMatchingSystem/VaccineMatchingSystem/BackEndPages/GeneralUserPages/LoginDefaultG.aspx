<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/GeneralUser.Master" AutoEventWireup="true" CodeBehind="LoginDefaultG.aspx.cs" Inherits="VaccineMatchingSystem.BackEndPages.GeneralUserPages.LoginDefault" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Literal ID="ltlTitleShow" runat="server"></asp:Literal><br />
    </div>
    <div>
        <asp:GridView ID="GridViewCurrentUserInfo" runat="server"></asp:GridView><br />
    </div>
    <div>
        <asp:Button ID="btnSystemExit" runat="server" Text="離開系統" OnClick="btnSystemExit_Click"/>
        <asp:Button ID="btnYesDoes" runat="server" Text="願意施打" OnClick="btnYesDoes_Click"/>
        <asp:Button ID="btnNoDose" runat="server" Text="不願意施打" OnClick="btnNoDose_Click"/>
    </div>
</asp:Content>
