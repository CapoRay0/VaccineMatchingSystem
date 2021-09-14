<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SystemAdmin.Master" AutoEventWireup="true" CodeBehind="UserMatchResult.aspx.cs" Inherits="VaccineMatchingSystem.BackEndPages.SystemAdminPages.UserMatchResult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br /><br /><br />    
    <div class="text-center">
        <asp:Literal ID="Lt_timeSpan" runat="server"></asp:Literal><br />
        <h3>檢視現有配對</h3><br />
        <asp:Button class="btn btn-outline-success" ID="btnGetVaccName" runat="server" Text="取得疫苗批次" OnClick="btnGetVaccData_Click" />
        <asp:Button class="btn btn-outline-secondary" ID="btnGetVaccDataCancel" runat="server" Text=" 取消重選 " Visible="false" OnClick="btnGetVaccDataCancel_Click" /> &nbsp &nbsp
        <asp:Button class="btn btn-outline-primary btn-lg" ID="btnGetVaccData" runat="server" Text="        確定        " Visible="false" OnClick="btnGetVaccData_Click1" />
        <br /><br />
        <asp:DropDownList class="btn btn-outline-primary dropdown-toggle" ID="ddlVaccName" runat="server">
            <asp:ListItem Value="0">請選擇</asp:ListItem>
        </asp:DropDownList> &nbsp &nbsp
        <asp:DropDownList class="btn btn-outline-primary dropdown-toggle" ID="ddlVaccBatch" runat="server" Visible="false"></asp:DropDownList>
    </div>

    <br /><br /><br />
    <div class="text-center">
        <asp:GridView class="container table" ID="GridViewMatchResult" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </div>
        <br /><br /><br /><br /><br /><br /><br /><br />
    <div class="d-grid gap-2 col-6 mx-auto">
        <asp:Button class="btn btn-outline-success btn-lg" ID="btnVaccineMatch" runat="server" Text="進行新一輪的配對" OnClick="btnVaccineMatch_Click" />
        <asp:Button class="btn btn-outline-success btn-lg" ID="btn_MatchResToXls" runat="server" Text="Excel下載" OnClick="btn_MatchResToXls_Click" Visible="false"/>
    </div>
    <br /><br /><br />
</asp:Content>
