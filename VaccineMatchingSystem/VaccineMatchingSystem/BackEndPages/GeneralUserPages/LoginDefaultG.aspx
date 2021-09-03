<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/GeneralUser.Master" AutoEventWireup="true" CodeBehind="LoginDefaultG.aspx.cs" Inherits="VaccineMatchingSystem.BackEndPages.GeneralUserPages.LoginDefault" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Literal ID="ltlTitleShow" runat="server"></asp:Literal><br />
    </div>
    <div>
        <%--<asp:GridView ID="GridViewCurrentUserInfo" runat="server"></asp:GridView><br />--%>
        <asp:Repeater ID="RepeaterCurrentUserInfo" runat="server">
            <ItemTemplate>
                <div style="border: 1px solid black;">
                    <h2>年齡：<%# Eval("Age") + "歲" %></h2>
                    <h2>性別：<%# Convert.ToInt32(Eval("Gender")) == 1 ? "男性":"女性" %></h2>
                    <h2>職業：<%# Eval("Occupation") %></h2>
                    <h2>地區：<%# Eval("Area") %></h2>
                    <h2>狀態：<%# Eval("Status") %></h2>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <hr />
    
    <div>
        <asp:Button ID="btnSystemExit" runat="server" Text="離開系統" OnClick="btnSystemExit_Click"/>
        <asp:Button ID="btnYesDoes" runat="server" Text="願意施打" OnClick="btnYesDoes_Click"/>
        <asp:Button ID="btnNoDose" runat="server" Text="不願意施打" OnClick="btnNoDose_Click"/>
    </div>
</asp:Content>
