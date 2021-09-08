<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SystemAdmin.Master" AutoEventWireup="true" CodeBehind="GetFeedback.aspx.cs" Inherits="VaccineMatchingSystem.BackEndPages.SystemAdminPages.GetFeedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br /><br /><br />
    <div class="d-grid gap-2 d-md-flex justify-content-md-center">
        <h3>系統管理者 - 查詢使用者回饋</h3>
    </div><br />
    <div class="d-grid gap-2 d-md-flex justify-content-md-center">
        <asp:Button class="btn btn-outline-primary btn-lg" ID="RepeaterbtnGetFeedback" runat="server" Text="回饋查詢" Width="60%" OnClick="Button1_Click" />
    </div>
        <br />
    <div class="d-grid gap-2 d-md-flex justify-content-md-center">
        <asp:GridView class="container" ID="GridViewFeedback" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnRowDataBound="GridViewFeedback_RowDataBound">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField HeaderText="使用者姓名"  DataField="FName"/>
                <asp:BoundField HeaderText="使用者信箱"  DataField="Email"/>
                <asp:BoundField HeaderText="使用者回饋"  DataField="Opinion"/>
                <asp:TemplateField HeaderText="不願施打理由"  >
                    <ItemTemplate>
                        <asp:Label ID="lblReasob" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="系統更新後通知">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblGetFeedbackorNot"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
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
    <br />
    <div class="d-grid gap-2 d-md-flex justify-content-md-center">
        <asp:Button class="btn btn-outline-success" ID="btnToExcel" runat="server" Text="輸出成 Excel 報表" Width="40%" OnClick="btnToExcel_Click" />
    </div><br /><br />

</asp:Content>
