<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SystemAdmin.Master" AutoEventWireup="true" CodeBehind="GetFeedback.aspx.cs" Inherits="VaccineMatchingSystem.BackEndPages.SystemAdminPages.GetFeedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>查詢回饋</h3>
    <div style="border: 1px solid black;">
        <asp:Button ID="RepeaterbtnGetFeedback" runat="server" Text="查詢使用者回饋" width="100%"  OnClick="Button1_Click"/>
    
        <asp:GridView ID="GridViewFeedback" runat="server"></asp:GridView><br /><br />
    
        <asp:Button ID="btnToExcel" runat="server" Text="輸出成報表" OnClick="btnToExcel_Click" />
    </div>
</asp:Content>
