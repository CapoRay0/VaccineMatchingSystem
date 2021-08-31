<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FrontMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VaccineMatchingSystem.FrontEndPages.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<%-- 主板頁面區 --%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<%--    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>--%>

    <%-- 引用外部套件區 --%>
    <link href="../ExternalTools/css/bootstrap.css" rel="stylesheet" />
    <script src="../ExternalTools/js/bootstrap.js"></script>
    <script src="../ExternalTools/jquery-3.6.0.min.js"></script>

    <%-- CSS編輯區 --%>
    <style type="text/css">

    </style>

    <%-- Html頁面編輯區 --%>

    <asp:Button ID="btnToLogin" runat="server" Text="進入系統" OnClick="btnToLogin_Click"/>

</asp:Content>
