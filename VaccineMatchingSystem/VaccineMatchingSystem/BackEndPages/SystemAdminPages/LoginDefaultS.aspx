<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SystemAdmin.Master" AutoEventWireup="true" CodeBehind="LoginDefaultS.aspx.cs" Inherits="VaccineMatchingSystem.BackEndPages.SystemAdminPages.LoginDefault" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <asp:Label ID="lblShowTotalUserNumb" runat="server" Text="一般使用者總數"></asp:Label>
        <asp:Literal ID="ltlShowTotalUserNumb" runat="server" Text=""></asp:Literal><br /><br />
        <asp:Label ID="lblShowTotalAdminUserNumb" runat="server" Text="系統管理者總數"></asp:Label>
        <asp:Literal ID="ltlShowTotalAdminUserNumb" runat="server" Text=""></asp:Literal><br /><br />
        <asp:Label ID="lblWillingNumb" runat="server" Text="已填寫意願人數"></asp:Label>
        <asp:Literal ID="ltlWillingNumb" runat="server" Text=""></asp:Literal><br /><br />
    </div>

</asp:Content>
