<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SystemAdmin.Master" AutoEventWireup="true" CodeBehind="LoginDefaultS.aspx.cs" Inherits="VaccineMatchingSystem.BackEndPages.SystemAdminPages.LoginDefault" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="d-grid gap-2 d-md-flex justify-content-md-center">
        <h4>
            <asp:Label ID="lblShowTotalUserNumb" runat="server" Text="一般使用者總數："></asp:Label>
            <asp:Literal ID="ltlShowTotalUserNumb" runat="server" Text=""></asp:Literal><br />
            <br />
            <asp:Label ID="lblShowTotalAdminUserNumb" runat="server" Text="系統管理者總數："></asp:Label>
            <asp:Literal ID="ltlShowTotalAdminUserNumb" runat="server" Text=""></asp:Literal><br />
            <br />
            <asp:Label ID="lblWillingNumb" runat="server" Text="意願登記總筆數："></asp:Label>
            <asp:Literal ID="ltlWillingNumb" runat="server" Text=""></asp:Literal><br />
        </h4>
    </div>

    <br />
    <hr />
    <br />


    <div>
        <asp:FileUpload ID="fuUserInfoExcel" runat="server" />
        <asp:Literal ID="ltUserInfoUploadWarning" runat="server"></asp:Literal><br />



        <div class="d-grid gap-2 d-md-flex justify-content-md-center">

            <asp:Button class="btn btn-outline-primary" ID="btnReadUserInfo" runat="server" Text="讀取本批次使用者資料" Width="100%" OnClick="btnReadUserInfo_Click" /><br />
            <asp:Button class="btn btn-outline-primary" ID="btnInsetUserInfo" runat="server" Text="匯入使用者資料" Width="100%" OnClick="btnInsetUserInfo_Click" /><br />

        </div>



        <asp:GridView ID="gvReadUserInfoFromExel" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvReadUserInfoFromExel_RowDataBound"
            CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="姓名" />

                <asp:TemplateField HeaderText="性別">
                    <ItemTemplate>
                        <asp:Label ID="lblGender" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="Age" HeaderText="年齡" />
                <asp:BoundField DataField="Occupation" HeaderText="職業" />
                <asp:BoundField DataField="Area" HeaderText="居住城市" />
                <asp:BoundField DataField="ID" HeaderText="使用者ID" />
                <asp:BoundField DataField="Status" HeaderText="使用者當前狀態" />
                <asp:BoundField DataField="DoseCount" HeaderText="已注射疫苗總數" />
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
        <br />
        <asp:FileUpload ID="fuVaccQuinExcel" runat="server" />
        <asp:Literal ID="ltVaccQuinUploadWarning" runat="server"></asp:Literal><br />


        <div class="d-grid gap-2 d-md-flex justify-content-md-center">
            <asp:Button class="btn btn-outline-success" ID="btnReadVaccInfoThisBatch" runat="server" Text="讀取本批次疫苗資料" Width="100%" OnClick="btnReadVaccInfoThisBatch_Click" /><br />
            <asp:Button class="btn btn-outline-success" ID="btnInsertVaccQuin" runat="server" Text="匯入本批疫苗資料" Width="100%" OnClick="btnInsertVaccQuin_Click" /><br />
        </div>


        <asp:Repeater ID="rpReadVaccQuinFromExcel" runat="server">
            <ItemTemplate>
                <div>
                    <h5><%# "批次：第" + Eval("VBatch") + "批" %></h5>
                    <h5><%# "疫苗名：" + Eval("VName") %></h5>
                    <h5><%# "疫苗數量：" + Eval("Quantity") %></h5>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>






    <br />
    <hr />
    <br />

    <div class="d-grid gap-2 d-md-flex justify-content-md-center">
        <asp:Button class="btn btn-outline-primary" ID="btnGetUserInfo" runat="server" Text="讀取匯入使用者的資料" Width="50%" OnClick="btnGetUserInfo_Click" /><br />
    </div>
    <br />
    <asp:GridView class="container" ID="GridUserInfo" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridUserInfo_RowDataBound"
        CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="姓名" />

            <asp:TemplateField HeaderText="性別">
                <ItemTemplate>
                    <asp:Label ID="lblGender" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="Age" HeaderText="年齡" />
            <asp:BoundField DataField="Occupation" HeaderText="職業" />
            <asp:BoundField DataField="Area" HeaderText="居住城市" />
            <asp:BoundField DataField="ID" HeaderText="使用者ID" />
            <asp:BoundField DataField="Status" HeaderText="使用者當前狀態" />
            <asp:BoundField DataField="DoseCount" HeaderText="已注射疫苗總數" />
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
    <br />
    <div class="d-grid gap-2 d-md-flex justify-content-md-center">
        <asp:Button class="btn btn-outline-success" ID="btnGetVaccData" runat="server" Text="讀取匯入疫苗資料" Width="50%" OnClick="btnGetVaccData_Click" />
    </div>
    <br />
    <div class="d-grid gap-2 d-md-flex justify-content-md-center">
        <asp:Repeater ID="RepeaterShowVacc" runat="server">
            <ItemTemplate>
                <div>
                    <h5><%# "批次：第" + Eval("VBatch") + "批" %></h5>
                    <h5><%# "疫苗名：" + Eval("VName") %></h5>
                    <h5><%# "疫苗數量：" + Eval("Quantity") %></h5>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <br />
    <div class="d-grid gap-2 d-md-flex justify-content-md-center">
        <asp:GridView ID="GridViewVaccInv" runat="server"></asp:GridView>
    </div>
    <br />

    <div class="d-grid gap-2 d-md-flex justify-content-md-center">
        <asp:Button class="btn btn-outline-dark btn-lg" ID="btnStartMatching" runat="server" Text="檢視配對" OnClick="btnStartMatching_Click" />
        &nbsp &nbsp &nbsp
        <asp:Button class="btn btn-outline-info btn-lg" ID="btnToFeedback" runat="server" Text="前往回饋頁" OnClick="btnToFeedback_Click" />
        &nbsp &nbsp &nbsp
        <asp:Button class="btn btn-outline-secondary" ID="btnSystemExit" runat="server" Text="離開系統" OnClick="btnSystemExit_Click" />
    </div>
    <br />
    <br />
</asp:Content>
