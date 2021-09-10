<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FrontMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VaccineMatchingSystem.FrontEndPages.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="../ExternalTools/css/bootstrap.css" rel="stylesheet" />
    <script src="../ExternalTools/js/bootstrap.js"></script>

    <div class="container text-center">
        <h4>系統介紹</h4>

        <table class="table table-striped table-light">
            <thead>
                <tr>
                    <th>系統簡述</th>
                    <th>系統起源</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>取得外部資料，進入主系統搭配演算法，計算配對結果並將結果輸出報表</td>
                    <td>渴望了解整體疫苗系統的運作架構及邏輯</td>
                </tr>
            </tbody>
        </table>
        <br />
        <h4>系統目標</h4>
        <div class="text-center">
            模擬疫苗登記配對系統運作<br />
            提供管理者疫苗分配方法<br />
            以不浪費疫苗為原則
        </div><br />
        <br />
        <h4>系統開發者</h4>
        <p class="text-center font-weight-bold">陳顥文  &nbsp &nbsp &nbsp  廖子寬  &nbsp &nbsp &nbsp  吳宗叡</p>
    </div>

    <div class="text-center">
        <asp:Button  CssClass="btn btn-secondary align" ID="btnToLogin" runat="server" Text="進入系統" OnClick="btnToLogin_Click" />
    </div><br />

    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <divAnimate>
        <img src="Pics/duck%20Animation.png" height="50" width="50"/>
    </divAnimate>
</asp:Content>

