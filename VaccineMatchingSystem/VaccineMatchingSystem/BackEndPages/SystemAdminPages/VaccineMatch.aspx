<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SystemAdmin.Master" AutoEventWireup="true" CodeBehind="VaccineMatch.aspx.cs" Inherits="VaccineMatchingSystem.BackEndPages.SystemAdminPages.VaccineMatch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div>
            <asp:Literal ID="Literal1" runat="server">[User參數]</asp:Literal><br />
            <asp:Label ID="lblAge" runat="server" Text="年齡"></asp:Label> &nbsp &nbsp &nbsp
            <asp:Label ID="lblShowAge" runat="server" Text=""></asp:Label>
            <%--<asp:TextBox ID="txtUerAge" runat="server" TextMode="Number"></asp:TextBox><br />--%>
            <asp:Label ID="lblJob" runat="server" Text="職業"></asp:Label>
            <asp:Label ID="lblShowJob" runat="server" Text=""></asp:Label>
            <%--<asp:TextBox ID="txtUserJob" runat="server"></asp:TextBox><br />--%>
            <asp:Label ID="lblArea" runat="server" Text="地區"></asp:Label>
            <%--<asp:TextBox ID="txtUerArea" runat="server"></asp:TextBox><br />--%>
            <asp:Label ID="lblState" runat="server" Text="狀態"></asp:Label>
            <%--<asp:TextBox ID="txtUserState" runat="server"></asp:TextBox><br />--%>
            <asp:Label ID="lblDoseCount" runat="server" Text="劑次"></asp:Label>
            <%--<asp:TextBox ID="txtUerDoseCount" runat="server"></asp:TextBox><br />--%>
            <br />
        </div>
        <div>
            <asp:Label ID="Label5" runat="server" Text="====================="></asp:Label><br />
            <asp:Literal ID="Literal2" runat="server">[演算法參數]</asp:Literal><br />
            <asp:Label ID="Label2" runat="server" Text="目標年齡-底" TextMode="Number"></asp:Label>
            <asp:TextBox ID="txt_age_targetAgeButtom" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label3" runat="server" Text="目標年齡-頂" TextMode="Number"></asp:Label>
            <asp:TextBox ID="txt_age_targetAgeTop" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label4" runat="server" Text="小的先/老的先(0/1)" ></asp:Label>
            <asp:TextBox ID="txt_age_direction" runat="server" TextMode="Number"></asp:TextBox><br />
            <asp:Label ID="Label10" runat="server" Text="讓要打第n劑的先" TextMode="Number"></asp:Label>
            <asp:TextBox ID="txt_ordinal" runat="server" TextMode="Number"></asp:TextBox><br />
            <asp:Label ID="Label13" runat="server" Text="地區"></asp:Label>
            <asp:TextBox ID="txt_area" runat="server"></asp:TextBox><br />

            <br /><asp:Label ID="Label6" runat="server" Text="====================="></asp:Label><br />
        </div>
        <asp:Button ID="btnCalculate" runat="server" Text="進行配對" OnClick="btnCalculate_Click" />
        <br />
        <asp:Literal ID="ltShow" runat="server"></asp:Literal>

</asp:Content>
