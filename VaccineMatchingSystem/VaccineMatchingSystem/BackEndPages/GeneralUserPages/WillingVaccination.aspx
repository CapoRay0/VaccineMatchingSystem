<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/GeneralUser.Master" AutoEventWireup="true" CodeBehind="WillingVaccination.aspx.cs" Inherits="VaccineMatchingSystem.BackEndPages.GeneralUserPages.WillingVaccination" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <asp:Literal ID="ltlTitleShow" runat="server"></asp:Literal><br />
    </div>
    
        <div>
        <h3>疫苗施打意願登記</h3>
        <table>
            <tr>
                <td><asp:Label ID="lblVaccAZ" runat="server" Text="AZ"></asp:Label></td>
                <td><asp:CheckBox ID="CheckBoxVaccAZ" runat="server" Text="願意施打"/></td>
                <td><asp:LinkButton ID="LinkVaccAZ" runat="server" OnClick="LinkVaccAZ_Click" >AZ疫苗資訊介紹</asp:LinkButton></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblVaccMoz" runat="server" Text="Moderna"></asp:Label></td>
                <td><asp:CheckBox ID="CheckBoxVaccMoz" runat="server" Text="願意施打"/></td>
                <td><asp:LinkButton ID="LinkVaccMoz" runat="server" OnClick="LinkVaccMoz_Click">Moderna疫苗資訊介紹</asp:LinkButton></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblVaccBNT" runat="server" Text="BNT"></asp:Label></td>
                <td><asp:CheckBox ID="CheckBoxVaccBNT" runat="server" Text="願意施打"/></td>
                <td><asp:LinkButton ID="LinkVaccBNT" runat="server" OnClick="LinkVaccBNT_Click">BNT疫苗資訊介紹</asp:LinkButton></td>
           
            </tr>
        </table>
            <br /><br />
            <asp:Button ID="btnConfirm" runat="server" Text="確認並送出" OnClick="btnConfirm_Click"/>
            <asp:Button ID="btnReject" runat="server" Text="取消登記" OnClick="btnReject_Click"/>
    </div>
   
    
</asp:Content>
