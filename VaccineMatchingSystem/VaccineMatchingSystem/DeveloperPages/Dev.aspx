<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dev.aspx.cs" Inherits="VaccineMatchingSystem.DeveloperPages.Dev" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>開發者面</h1>
        <div>
            <asp:Literal ID="lt_show" runat="server"></asp:Literal>
             <br />
            <asp:TextBox ID="txt_addUsers" runat="server" TextMode="Number">0</asp:TextBox>
            <asp:Button ID="btn_addUsers" runat="server" Text="新增使用者" OnClick="btn_addUsers_Click" />
            <br />
            <asp:Button ID="btn_clearDB" runat="server" Text="清空民眾與願望" OnClick="btn_clearDB_Click" />
            <br />
            <asp:Button ID="btn_clearDB2" runat="server" Text="清空疫苗庫存，配對紀錄，演算法參數紀錄" OnClick="btn_clearDB2_Click" />
            <br />
            <asp:Button ID="btn_returnToDefault" runat="server" Text="回首頁" OnClick="btn_returnToDefault_Click" />
            <br />
        </div>
    </form>
</body>
</html>

