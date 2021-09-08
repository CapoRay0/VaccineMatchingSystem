<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SystemAdmin.Master" AutoEventWireup="true" CodeBehind="UserMatchResult.aspx.cs" Inherits="VaccineMatchingSystem.BackEndPages.SystemAdminPages.UserMatchResult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br /><br /><br />
    <div>
        <asp:GridView ID="GridViewMatchResult" runat="server"></asp:GridView><br />

        <asp:Button ID="btnCalculateScore" runat="server" Text="計算使用者分數" OnClick="btnCalculateScore_Click"/>
        <asp:Literal ID="litShowScore" runat="server"></asp:Literal><br />
        <asp:Button ID="btnVaccineMatch" runat="server" Text="進行新一輪的配對" OnClick="btnVaccineMatch_Click" />
    </div>
</asp:Content>
