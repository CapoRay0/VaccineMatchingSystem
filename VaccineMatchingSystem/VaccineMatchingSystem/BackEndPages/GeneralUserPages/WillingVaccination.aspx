<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/GeneralUser.Master" AutoEventWireup="true" CodeBehind="WillingVaccination.aspx.cs" Inherits="VaccineMatchingSystem.BackEndPages.GeneralUserPages.WillingVaccination" %>

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
    <br /><br />
    <div class="d-grid gap-2 d-md-flex justify-content-md-center">
    <h3>請登記您的疫苗施打意願</h3>
    </div>
    <br />

    <div class="d-grid gap-2 d-md-flex justify-content-md-center">
    <table>
        <tr>
            <td>
                <asp:Label class="col-form-label-lg" ID="lblVaccAZ" runat="server" Text="AZ"></asp:Label></td>
            <td>
                <asp:CheckBox class="form-control-lg" ID="CheckBoxVaccAZ" runat="server" Text=" 願意施打" /></td>
        </tr>
        <tr>
            <td>
                <asp:Label class="col-form-label-lg" ID="lblVaccMoz" runat="server" Text="Moderna"></asp:Label></td>
            <td>
                <asp:CheckBox class="form-control-lg" ID="CheckBoxVaccMoz" runat="server" Text=" 願意施打" /></td>
        </tr>
        <tr>
            <td>
                <asp:Label class="col-form-label-lg" ID="lblVaccBNT" runat="server" Text="BNT"></asp:Label></td>
            <td>
                <asp:CheckBox class="form-control-lg" ID="CheckBoxVaccBNT" runat="server" Text=" 願意施打" /></td>
        </tr>
    </table>
    </div>

    <br />
    <div class="d-grid gap-2 d-md-flex justify-content-md-center">
    <a href="https://www.cdc.gov.tw/Category/MPage/epjWGimoqASwhAN8X-5Nlw" target="_blank">衛生福利部疾病管制署 - 疫苗資訊介紹 </a>
    </div>
    <br />
    <br />
    <div class="d-grid gap-2 d-md-flex justify-content-md-center">
    <asp:Button class="btn btn-outline-success btn-lg" ID="btnConfirm" runat="server" Text="確認並送出" OnClick="btnConfirm_Click" />
    &nbsp &nbsp &nbsp
        <asp:Button class="btn btn-outline-danger" ID="btnReject" runat="server" Text="取消登記" OnClick="btnReject_Click" />
    </div>
    <br /><br /><br /><br />

</asp:Content>
