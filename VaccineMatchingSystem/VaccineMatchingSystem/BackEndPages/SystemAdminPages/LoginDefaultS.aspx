<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SystemAdmin.Master" AutoEventWireup="true" CodeBehind="LoginDefaultS.aspx.cs" Inherits="VaccineMatchingSystem.BackEndPages.SystemAdminPages.LoginDefault" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <h2>
        <asp:Label ID="lblShowTotalUserNumb" runat="server" Text="一般使用者總數"></asp:Label>
        <asp:Literal ID="ltlShowTotalUserNumb" runat="server" Text=""></asp:Literal><br /><br />
        <asp:Label ID="lblShowTotalAdminUserNumb" runat="server" Text="系統管理者總數"></asp:Label>
        <asp:Literal ID="ltlShowTotalAdminUserNumb" runat="server" Text=""></asp:Literal><br /><br />
        <asp:Label ID="lblWillingNumb" runat="server" Text="已填寫意願人數"></asp:Label>
        <asp:Literal ID="ltlWillingNumb" runat="server" Text=""></asp:Literal><br /><br />
        </h2>
    </div>

    <div>
        <asp:Button ID="btnGetVaccData" runat="server" Text="取得本批次疫苗資料" Width="100%" OnClick="btnGetVaccData_Click"/>
        <asp:GridView ID="GridViewVaccInv" runat="server"></asp:GridView>
    
        <asp:Button ID="btnStartMatching" runat="server" Text="檢視配對" OnClick="btnStartMatching_Click"/>
    </div>

    <asp:Button ID="btnToFeedback" runat="server" Text="前往回饋頁" OnClick="btnToFeedback_Click"/>

</asp:Content>
