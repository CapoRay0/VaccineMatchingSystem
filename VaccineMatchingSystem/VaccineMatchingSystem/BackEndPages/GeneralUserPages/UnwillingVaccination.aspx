<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/GeneralUser.Master" AutoEventWireup="true" CodeBehind="UnwillingVaccination.aspx.cs" Inherits="VaccineMatchingSystem.BackEndPages.GeneralUserPages.UnwillingVaccination1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </div>
    
    <div>
        <asp:Label ID="lblName" runat="server" Text="姓名"></asp:Label>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />
        <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br /><br />

        <asp:Label ID="lblReaseon" runat="server" Text="請勾選不願意施打原因"></asp:Label>
       
        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            <asp:ListItem Value="1">系統設計不友善</asp:ListItem>
            <asp:ListItem Value="2">疫苗種類過少</asp:ListItem>
            <asp:ListItem Value="3">基本資料有誤</asp:ListItem>
            <asp:ListItem Value="4">不知道如何使用系統</asp:ListItem>
            <asp:ListItem Value="5">其他 不願說明</asp:ListItem>
            </asp:RadioButtonList><br />

        <asp:Label ID="lblFeedback" runat="server" Text="意見回饋"></asp:Label>
        <textarea id="txtFeedback" cols="20" rows="2" runat="server"></textarea>
        
        <hr />
        <asp:Label ID="Label1" runat="server" Text="是否願意收到系統更新後的通知"></asp:Label>
        <asp:RadioButton ID="RBYesFeedback" runat="server" GroupName="ConfirmFeedback" Text="是"/>
        <asp:RadioButton ID="RBNoFeedback" runat="server" GroupName="ConfirmFeedback" Text="否"/><br />
        
        <asp:Button ID="btnSend" runat="server" Text="送出"/>
    </div>
</asp:Content>
