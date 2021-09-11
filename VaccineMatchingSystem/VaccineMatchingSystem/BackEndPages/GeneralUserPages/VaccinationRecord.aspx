<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/GeneralUser.Master" AutoEventWireup="true" CodeBehind="VaccinationRecord.aspx.cs" Inherits="VaccineMatchingSystem.BackEndPages.GeneralUserPages.VaccinationRecord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .table-condensed{
            font-size: 25px;
        }
    </style>
    <br /><br /><br /><br />
    <div class="d-grid gap-2 d-md-flex justify-content-md-center">
        <h2><asp:Label ID="lblTitleShow" runat="server" Text=""></asp:Label></h2>
    </div>
    <br /><br />
    <div class="text-center">
        <asp:GridView class="table table-condensed" ID="GridViewShowResult" runat="server" CellPadding="4" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField HeaderText="疫苗種類"  DataField="VName"/>
                <asp:BoundField HeaderText="施打地區"  DataField="TargetArea"/>
            </Columns>
            <FooterStyle BackColor="#CCCC77" />
            <HeaderStyle BackColor="#EFC59A" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#FDF9F2" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
    </div><br />
    <div class="text-center col-form-label-lg">
        <asp:Label ID="lblNoResult" runat="server" Text=""></asp:Label>
    </div>
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />


</asp:Content>
