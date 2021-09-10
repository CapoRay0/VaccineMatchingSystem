<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SystemAdmin.Master" AutoEventWireup="true" CodeBehind="VaccineMatch.aspx.cs" Inherits="VaccineMatchingSystem.BackEndPages.SystemAdminPages.VaccineMatch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br /><br /><br />
    <div class="text-center">
        <h3>進行新一輪的配對</h3>
        <asp:Label ID="lbShow" runat="server" Text=""></asp:Label><br />
        <asp:Button ID="btnGetVaccName" runat="server" Text="取得疫苗批次" OnClick="btnGetVaccData_Click" />
        <asp:Button ID="btnGetVaccData" runat="server" Text="確定" Visible="false" OnClick="btnGetVaccData_Click1" />
        <asp:Button ID="btnGetVaccDataCancel" runat="server" Text="取消重選" Visible="false" OnClick="btnGetVaccDataCancel_Click" />
        <br />
        <asp:DropDownList ID="ddlVaccName" runat="server">
            <asp:ListItem Value="0">請選擇</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="ddlVaccBatch" runat="server" Visible="false"></asp:DropDownList>
        <asp:Repeater ID="RepeaterShowVacc" runat="server">
            <ItemTemplate>
                <div>
                    <h4>疫苗批次：<%# "批次：第" + Eval("VBatch") + "批" %></h4>
                    <h4>性別：<%# "疫苗名：" + Eval("VName") %></h4>
                    <h4>職業：<%# "疫苗數量：" + Eval("Quantity") %></h4>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <div>
        <asp:PlaceHolder ID="phAlgWeightList" runat="server" Visible="false">
            <asp:Label ID="Label5" runat="server" Text="====================="></asp:Label><br />
            <asp:Literal ID="Literal2" runat="server">[演算法參數]</asp:Literal><br />
            <asp:Label ID="Label2" runat="server" Text="目標年齡-底"></asp:Label>
            <asp:TextBox ID="txt_age_targetAgeButtom" runat="server" TextMode="Number" Text="30"></asp:TextBox><br />
            <asp:Label ID="Label3" runat="server" Text="目標年齡-頂"></asp:Label>
            <asp:TextBox ID="txt_age_targetAgeTop" runat="server" TextMode="Number" Text="50"></asp:TextBox><br />
            <asp:Label ID="Label4" runat="server" Text="小的先/老的先"></asp:Label>
            <asp:DropDownList ID="ddl_age_direction" runat="server">
                <asp:ListItem Value="0">小的先</asp:ListItem>
                <asp:ListItem Value="1">老的先</asp:ListItem>
            </asp:DropDownList><br />
            <asp:Label ID="Label10" runat="server" Text="打第n劑者優先" TextMode="Number"></asp:Label>
            <asp:DropDownList ID="ddl_ordinal" runat="server">
                <asp:ListItem Value="1">施打第1劑者優先</asp:ListItem>
                <asp:ListItem Value="2">施打第2劑者優先</asp:ListItem>
            </asp:DropDownList><br />
            <asp:Label ID="Label13" runat="server" Text="地區"></asp:Label>
            <asp:DropDownList ID="ddl_Area" runat="server">
                <asp:ListItem>請選擇</asp:ListItem>
                <asp:ListItem>北區</asp:ListItem>
                <asp:ListItem>中區</asp:ListItem>
                <asp:ListItem>南區</asp:ListItem>
                <asp:ListItem>東區</asp:ListItem>
                <asp:ListItem>離島</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="ddl_Country" runat="server" Visible="false"></asp:DropDownList>
            <asp:Button ID="btn_AreaCheck" runat="server" Text="確定" OnClick="btnAreaCheck_Click" />
            <asp:Button ID="btn_AreaCancel" runat="server" Text="取消" OnClick="btnAreaCancel_Click" Visible="false" /><br />
            <asp:Literal ID="Literal12" runat="server">職業權重</asp:Literal><br />
            <asp:PlaceHolder ID="ph_JobWeightList" runat="server">
                <asp:TextBox ID="txt_JobInput1" runat="server" Text="醫護人員"></asp:TextBox>
                <asp:DropDownList ID="ddl_JobWeightSelect1" runat="server">
                    <asp:ListItem>請選擇</asp:ListItem>
                    <asp:ListItem>0.5</asp:ListItem>
                    <asp:ListItem>0.6</asp:ListItem>
                    <asp:ListItem>0.7</asp:ListItem>
                    <asp:ListItem>0.8</asp:ListItem>
                    <asp:ListItem>0.9</asp:ListItem>
                    <asp:ListItem>1.0</asp:ListItem>
                    <asp:ListItem>1.1</asp:ListItem>
                    <asp:ListItem>1.2</asp:ListItem>
                    <asp:ListItem>1.3</asp:ListItem>
                    <asp:ListItem>1.4</asp:ListItem>
                    <asp:ListItem>1.5</asp:ListItem>
                </asp:DropDownList><br />
                <asp:TextBox ID="txt_JobInput2" runat="server" Text="政府職員"></asp:TextBox>
                <asp:DropDownList ID="ddl_JobWeightSelect2" runat="server">
                    <asp:ListItem>請選擇</asp:ListItem>
                    <asp:ListItem>0.5</asp:ListItem>
                    <asp:ListItem>0.6</asp:ListItem>
                    <asp:ListItem>0.7</asp:ListItem>
                    <asp:ListItem>0.8</asp:ListItem>
                    <asp:ListItem>0.9</asp:ListItem>
                    <asp:ListItem>1.0</asp:ListItem>
                    <asp:ListItem>1.1</asp:ListItem>
                    <asp:ListItem>1.2</asp:ListItem>
                    <asp:ListItem>1.3</asp:ListItem>
                    <asp:ListItem>1.4</asp:ListItem>
                    <asp:ListItem>1.5</asp:ListItem>
                </asp:DropDownList><br />
                <asp:TextBox ID="txt_JobInput3" runat="server" Text="航空從業者"></asp:TextBox>
                <asp:DropDownList ID="ddl_JobWeightSelect3" runat="server">
                    <asp:ListItem>請選擇</asp:ListItem>
                    <asp:ListItem>0.5</asp:ListItem>
                    <asp:ListItem>0.6</asp:ListItem>
                    <asp:ListItem>0.7</asp:ListItem>
                    <asp:ListItem>0.8</asp:ListItem>
                    <asp:ListItem>0.9</asp:ListItem>
                    <asp:ListItem>1.0</asp:ListItem>
                    <asp:ListItem>1.1</asp:ListItem>
                    <asp:ListItem>1.2</asp:ListItem>
                    <asp:ListItem>1.3</asp:ListItem>
                    <asp:ListItem>1.4</asp:ListItem>
                    <asp:ListItem>1.5</asp:ListItem>
                </asp:DropDownList><br />
                <asp:TextBox ID="txt_JobInput4" runat="server" Text="長照人員"></asp:TextBox>
                <asp:DropDownList ID="ddl_JobWeightSelect4" runat="server">
                    <asp:ListItem>請選擇</asp:ListItem>
                    <asp:ListItem>0.5</asp:ListItem>
                    <asp:ListItem>0.6</asp:ListItem>
                    <asp:ListItem>0.7</asp:ListItem>
                    <asp:ListItem>0.8</asp:ListItem>
                    <asp:ListItem>0.9</asp:ListItem>
                    <asp:ListItem>1.0</asp:ListItem>
                    <asp:ListItem>1.1</asp:ListItem>
                    <asp:ListItem>1.2</asp:ListItem>
                    <asp:ListItem>1.3</asp:ListItem>
                    <asp:ListItem>1.4</asp:ListItem>
                    <asp:ListItem>1.5</asp:ListItem>
                </asp:DropDownList><br />
                <asp:TextBox ID="txt_JobInput5" runat="server" Text="軍警"></asp:TextBox>
                <asp:DropDownList ID="ddl_JobWeightSelect5" runat="server">
                    <asp:ListItem>請選擇</asp:ListItem>
                    <asp:ListItem>0.5</asp:ListItem>
                    <asp:ListItem>0.6</asp:ListItem>
                    <asp:ListItem>0.7</asp:ListItem>
                    <asp:ListItem>0.8</asp:ListItem>
                    <asp:ListItem>0.9</asp:ListItem>
                    <asp:ListItem>1.0</asp:ListItem>
                    <asp:ListItem>1.1</asp:ListItem>
                    <asp:ListItem>1.2</asp:ListItem>
                    <asp:ListItem>1.3</asp:ListItem>
                    <asp:ListItem>1.4</asp:ListItem>
                    <asp:ListItem>1.5</asp:ListItem>
                </asp:DropDownList><br />
            </asp:PlaceHolder>
            <br />
            <asp:Literal ID="Literal14" runat="server">狀態權重</asp:Literal><br />
            <asp:PlaceHolder ID="ph_StateWeightList" runat="server">
                <asp:TextBox ID="txt_StateInput1" runat="server" Text="因公出國"></asp:TextBox>
                <asp:DropDownList ID="ddl_StateWeightSelect1" runat="server">
                    <asp:ListItem>請選擇</asp:ListItem>
                    <asp:ListItem>0.5</asp:ListItem>
                    <asp:ListItem>0.6</asp:ListItem>
                    <asp:ListItem>0.7</asp:ListItem>
                    <asp:ListItem>0.8</asp:ListItem>
                    <asp:ListItem>0.9</asp:ListItem>
                    <asp:ListItem>1.0</asp:ListItem>
                    <asp:ListItem>1.1</asp:ListItem>
                    <asp:ListItem>1.2</asp:ListItem>
                    <asp:ListItem>1.3</asp:ListItem>
                    <asp:ListItem>1.4</asp:ListItem>
                    <asp:ListItem>1.5</asp:ListItem>
                </asp:DropDownList><br />
                  <asp:TextBox ID="txt_StateInput2" runat="server" Text="業務出國"></asp:TextBox>
                <asp:DropDownList ID="ddl_StateWeightSelect2" runat="server">
                    <asp:ListItem>請選擇</asp:ListItem>
                    <asp:ListItem>0.5</asp:ListItem>
                    <asp:ListItem>0.6</asp:ListItem>
                    <asp:ListItem>0.7</asp:ListItem>
                    <asp:ListItem>0.8</asp:ListItem>
                    <asp:ListItem>0.9</asp:ListItem>
                    <asp:ListItem>1.0</asp:ListItem>
                    <asp:ListItem>1.1</asp:ListItem>
                    <asp:ListItem>1.2</asp:ListItem>
                    <asp:ListItem>1.3</asp:ListItem>
                    <asp:ListItem>1.4</asp:ListItem>
                    <asp:ListItem>1.5</asp:ListItem>
                </asp:DropDownList><br />
                  <asp:TextBox ID="txt_StateInput3" runat="server" Text="重大傷病"></asp:TextBox>
                <asp:DropDownList ID="ddl_StateWeightSelect3" runat="server">
                    <asp:ListItem>請選擇</asp:ListItem>
                    <asp:ListItem>0.5</asp:ListItem>
                    <asp:ListItem>0.6</asp:ListItem>
                    <asp:ListItem>0.7</asp:ListItem>
                    <asp:ListItem>0.8</asp:ListItem>
                    <asp:ListItem>0.9</asp:ListItem>
                    <asp:ListItem>1.0</asp:ListItem>
                    <asp:ListItem>1.1</asp:ListItem>
                    <asp:ListItem>1.2</asp:ListItem>
                    <asp:ListItem>1.3</asp:ListItem>
                    <asp:ListItem>1.4</asp:ListItem>
                    <asp:ListItem>1.5</asp:ListItem>
                </asp:DropDownList><br />
                  <asp:TextBox ID="txt_StateInput4" runat="server" ></asp:TextBox>
                <asp:DropDownList ID="ddl_StateWeightSelect4" runat="server">
                    <asp:ListItem>請選擇</asp:ListItem>
                    <asp:ListItem>0.5</asp:ListItem>
                    <asp:ListItem>0.6</asp:ListItem>
                    <asp:ListItem>0.7</asp:ListItem>
                    <asp:ListItem>0.8</asp:ListItem>
                    <asp:ListItem>0.9</asp:ListItem>
                    <asp:ListItem>1.0</asp:ListItem>
                    <asp:ListItem>1.1</asp:ListItem>
                    <asp:ListItem>1.2</asp:ListItem>
                    <asp:ListItem>1.3</asp:ListItem>
                    <asp:ListItem>1.4</asp:ListItem>
                    <asp:ListItem>1.5</asp:ListItem>
                </asp:DropDownList><br />
                  <asp:TextBox ID="txt_StateInput5" runat="server"></asp:TextBox>
                <asp:DropDownList ID="ddl_StateWeightSelect5" runat="server">
                    <asp:ListItem>請選擇</asp:ListItem>
                    <asp:ListItem>0.5</asp:ListItem>
                    <asp:ListItem>0.6</asp:ListItem>
                    <asp:ListItem>0.7</asp:ListItem>
                    <asp:ListItem>0.8</asp:ListItem>
                    <asp:ListItem>0.9</asp:ListItem>
                    <asp:ListItem>1.0</asp:ListItem>
                    <asp:ListItem>1.1</asp:ListItem>
                    <asp:ListItem>1.2</asp:ListItem>
                    <asp:ListItem>1.3</asp:ListItem>
                    <asp:ListItem>1.4</asp:ListItem>
                    <asp:ListItem>1.5</asp:ListItem>
                </asp:DropDownList><br />
            </asp:PlaceHolder>

        </asp:PlaceHolder>
        <br />
        <asp:Label ID="Label6" runat="server" Text="====================="></asp:Label><br />
    </div>
    <asp:Button ID="btnCalculate" runat="server" Text="進行配對" OnClick="btnCalculate_Click" Visible="false" />
    <br />
    <asp:Literal ID="ltShow" runat="server"></asp:Literal>

</asp:Content>