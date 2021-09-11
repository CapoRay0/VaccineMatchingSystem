<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/GeneralUser.Master" AutoEventWireup="true" CodeBehind="LoginDefaultG.aspx.cs" Inherits="VaccineMatchingSystem.BackEndPages.GeneralUserPages.LoginDefault" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br /><br /><br />
    <div class="d-grid gap-2 d-md-flex justify-content-md-center">
        <h2><asp:Label ID="lblTitleShow" runat="server" Text=""></asp:Label></h2>
    </div>

    <div class="d-grid gap-2 d-md-flex justify-content-md-center">
        <h2><asp:Label ID="lblWelcome" runat="server" Text="歡迎使用疫苗配對系統"></asp:Label></h2>
    </div>
    <br />
    <div class="d-grid gap-2 d-md-flex justify-content-md-center">
        <asp:Repeater ID="RepeaterCurrentUserInfo" runat="server">
            <ItemTemplate>
                <div>
                    <h3>年齡：<%# Eval("Age") + "歲" %></h3>
                    <h3>性別：<%# Convert.ToInt32(Eval("Gender")) == 1 ? "男性":"女性" %></h3>
                    <h3>職業：<%# Eval("Occupation") %></h3>
                    <h3>地區：<%# Eval("Area") %></h3>
                    <h3>狀態：<%# Eval("Status") %></h3>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <br /><hr /><br />
    
    <div class="d-grid gap-2 d-md-flex justify-content-md-center">
        <asp:Button class="btn btn-outline-success btn-lg" ID="btnYesDoes" runat="server" Text="   願意施打   " OnClick="btnYesDoes_Click"/> &nbsp &nbsp &nbsp
        <asp:Button class="btn btn-outline-primary" ID="btnQuery" runat="server" Text="查詢配對狀態" OnClick="btnQuery_Click" /> &nbsp &nbsp &nbsp
        <asp:Button class="btn btn-outline-danger" ID="btnNoDose" runat="server" Text="我有問題" OnClick="btnNoDose_Click"/>
    </div><br /><br /><br /><br /><br />
</asp:Content>
