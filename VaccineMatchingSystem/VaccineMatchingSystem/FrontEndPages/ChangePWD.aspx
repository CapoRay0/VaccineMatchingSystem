<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FrontMaster.Master" AutoEventWireup="true" CodeBehind="ChangePWD.aspx.cs" Inherits="VaccineMatchingSystem.FrontEndPages.ChangePWD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div>
    <asp:Label CssClass="col-form-label-lg" ID="Label1" runat="server" Text="歡迎使用本疫苗配對系統，首次登入時請更改您的密碼"></asp:Label><br /><br />
    <asp:Label CssClass="col-form-label-lg" ID="lblAccount" runat="server" Text="使用者帳號"></asp:Label>
    <asp:TextBox CssClass="form-control" ID="txtAccount" runat="server" placeholder="您的帳號"></asp:TextBox><br />
    <asp:Label CssClass="col-form-label-lg" ID="lblOrigPWD" runat="server" Text="請輸入原密碼"></asp:Label>
    <asp:TextBox CssClass="form-control" ID="txtOrigPWD" runat="server" TextMode="Password" placeholder="您的密碼"></asp:TextBox><br />
    <asp:Label CssClass="col-form-label-lg" ID="lblNewPWD" runat="server" Text="">請輸入新密碼</asp:Label>
    <asp:TextBox CssClass="form-control" ID="txtNewPWD" runat="server" TextMode="Password" placeholder="新的密碼"></asp:TextBox><br />
    <asp:Label CssClass="col-form-label-lg" ID="lblPWDconf" runat="server" Text="確認新密碼"></asp:Label>
    <asp:TextBox CssClass="form-control" ID="txtPWDconf" runat="server" TextMode="Password" placeholder="確認新密碼"></asp:TextBox><br />
    <div class="d-grid gap-2 d-md-flex justify-content-md-end">
    <asp:Label CssClass="col-form-label-lg" ID="lblMsg" runat="server" Text=""></asp:Label> &nbsp &nbsp
    <asp:Button class="btn btn-outline-secondary btn-lg" ID="btnBackToLogin" runat="server" Text="返回" OnClick="btnBackToLogin_Click" />
    <asp:Button CssClass="btn btn-outline-success btn-lg" ID="btnConfirm" runat="server" Text="確認送出" OnClick="btnConfirm_Click"/></div>
    </div>
    <br />

    <script src="../ExternalTools/jquery-3.6.0.min.js"></script>
    <button type="button" id="btnShowdiv">密碼建議開啟</button>
    <button type="button" id="btnHidediv">收起</button><br /><br />
    <style>
        .c1{
            text-align:center;
            text-emphasis-color:aqua
        }
    </style>
    <script>
        $(document).ready(function () {
            $("#btnShowdiv").click(function () {
                $("#div1").fadeIn();
                $("#div2").fadeIn("slow");
                $("#div3").fadeIn(1000);
                $(".c1").fadeIn(2000);
            });

            $("#btnHidediv").click(function () {
                $("#div1").fadeOut();
                $("#div2").fadeOut("slow");
                $("#div3").fadeOut(1000);
                $(".c1").fadeOut(2000);
            });
        });
    </script>
    <div class="text-center">
        <div id="div1" style="width:50px;height:50px;display:none;background-color:red;">
            
        </div>
        <span id="span1" class="c1">請輸入新密碼，無法與原密碼相同<br /></span>
        <div id="div2" style="width:50px;height:50px;display:none;background-color:green;">
            
        </div>
        <span id="span2" class="c1">請確認密碼強度，建議輸入大小寫英文混合</span><br />
        <div id="div3" style="width:50px;height:50px;display:none;background-color:blue;">
            
        </div>
        <span id="span3" class="c1">密碼更改完成後即可使用本系統</span>
    </div>

</asp:Content>
