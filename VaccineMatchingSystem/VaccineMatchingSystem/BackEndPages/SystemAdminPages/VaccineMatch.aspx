<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SystemAdmin.Master" AutoEventWireup="true" CodeBehind="VaccineMatch.aspx.cs" Inherits="VaccineMatchingSystem.BackEndPages.SystemAdminPages.VaccineMatch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br /><br /><br />
    <div class="text-center">
        <h3>進行新一輪的配對</h3>
        <asp:Label ID="lbShow" runat="server" Text=""></asp:Label><br />
        <asp:Button class="btn btn-outline-success" ID="btnGetVaccName" runat="server" Text="取得疫苗批次" OnClick="btnGetVaccData_Click" />
        <asp:Button class="btn btn-outline-secondary" ID="btnGetVaccDataCancel" runat="server" Text="取消重選" Visible="false" OnClick="btnGetVaccDataCancel_Click" /> &nbsp &nbsp
        <asp:Button class="btn btn-outline-primary btn-lg" ID="btnGetVaccData" runat="server" Text="        確定        " Visible="false" OnClick="btnGetVaccData_Click1" />
        <br /><br />
        <asp:DropDownList class="btn btn-outline-primary dropdown-toggle" ID="ddlVaccName" runat="server">
            <asp:ListItem Value="0">請選擇</asp:ListItem>
        </asp:DropDownList> &nbsp &nbsp
        <asp:DropDownList class="btn btn-outline-primary dropdown-toggle" ID="ddlVaccBatch" runat="server" Visible="false"></asp:DropDownList>
<%--        <asp:Repeater ID="RepeaterShowVacc" runat="server">
            <ItemTemplate>
                <div>
                    <h4>疫苗批次：<%# "批次：第" + Eval("VBatch") + "批" %></h4>
                    <h4>性別：<%# "疫苗名：" + Eval("VName") %></h4>
                    <h4>職業：<%# "疫苗數量：" + Eval("Quantity") %></h4>
                </div>
            </ItemTemplate>
        </asp:Repeater>--%>
    </div>
    <br />
    <div class="form-control text-center border-0">
        <asp:PlaceHolder ID="phAlgWeightList" runat="server" Visible="false">
            <asp:Label CssClass="col-form-label-lg" ID="Label1" runat="server" Text=""> 演算法參數 </asp:Label><br /><br />
            <asp:Label CssClass="col-form-label-lg" ID="Label2" runat="server" Text="目標年齡 - 底部 "></asp:Label>
            <asp:TextBox class="form-control text-center" ID="txt_age_targetAgeButtom" runat="server" TextMode="Number" Text="30"></asp:TextBox><br />
            <asp:Label CssClass="col-form-label-lg" ID="Label3" runat="server" Text="目標年齡 - 頂部 "></asp:Label>
            <asp:TextBox class="form-control text-center" ID="txt_age_targetAgeTop" runat="server" TextMode="Number" Text="50"></asp:TextBox><br />
            <asp:Label CssClass="col-form-label-lg" ID="Label4" runat="server" Text="年輕的先 / 年長的先 "></asp:Label>
            <asp:DropDownList class="form-control text-center" ID="ddl_age_direction" runat="server">
                <asp:ListItem Value="0">年輕的先配對</asp:ListItem>
                <asp:ListItem Value="1">年長的先配對</asp:ListItem>
            </asp:DropDownList><br />
            <asp:Label CssClass="col-form-label-lg" ID="Label10" runat="server" Text="打第 N 劑者優先 " TextMode="Number"></asp:Label>
            <asp:DropDownList class="form-control text-center" ID="ddl_ordinal" runat="server">
                <asp:ListItem Value="1">施打第 1 劑者優先</asp:ListItem>
                <asp:ListItem Value="2">施打第 2 劑者優先</asp:ListItem>
            </asp:DropDownList><br />
            <asp:Label CssClass="col-form-label-lg" ID="Label13" runat="server" Text="地區 "></asp:Label>
            <asp:DropDownList class="form-control text-center" ID="ddl_Area" runat="server">
                <asp:ListItem>請選擇</asp:ListItem>
                <asp:ListItem>北區</asp:ListItem>
                <asp:ListItem>中區</asp:ListItem>
                <asp:ListItem>南區</asp:ListItem>
                <asp:ListItem>東區</asp:ListItem>
                <asp:ListItem>離島</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList class="form-control text-center" ID="ddl_Country" runat="server" Visible="false"></asp:DropDownList><br />
            <asp:Button class="btn btn-success" ID="btn_AreaCheck" runat="server" Text="確定" OnClick="btnAreaCheck_Click" />
            <asp:Button class="btn btn-secondary" ID="btn_AreaCancel" runat="server" Text="取消" OnClick="btnAreaCancel_Click" Visible="false" /><br /><br /><br />
            <asp:Label CssClass="col-form-label-lg" ID="Label7" runat="server" Text="">職業權重</asp:Label><br /><br />
            
            <asp:PlaceHolder ID="ph_JobWeightList" runat="server">
                <asp:TextBox CssClass="form-control-sm w-50 text-center" ID="txt_JobInput1" runat="server" Text="醫護人員"></asp:TextBox>
                <asp:DropDownList CssClass="btn w-25 text-center" ID="ddl_JobWeightSelect1" runat="server">
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
                <asp:TextBox CssClass="form-control-sm w-50 text-center" ID="txt_JobInput2" runat="server" Text="政府職員"></asp:TextBox>
                <asp:DropDownList CssClass="btn w-25 text-center" ID="ddl_JobWeightSelect2" runat="server">
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
                <asp:TextBox CssClass="form-control-sm w-50 text-center" ID="txt_JobInput3" runat="server" Text="航空從業者"></asp:TextBox>
                <asp:DropDownList CssClass="btn w-25 text-center" ID="ddl_JobWeightSelect3" runat="server">
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
                <asp:TextBox CssClass="form-control-sm w-50 text-center" ID="txt_JobInput4" runat="server" Text="長照人員"></asp:TextBox>
                <asp:DropDownList CssClass="btn w-25 text-center" ID="ddl_JobWeightSelect4" runat="server">
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
                <asp:TextBox CssClass="form-control-sm w-50 text-center" ID="txt_JobInput5" runat="server" Text="軍警"></asp:TextBox>
                <asp:DropDownList CssClass="btn w-25 text-center" ID="ddl_JobWeightSelect5" runat="server">
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
                </asp:DropDownList><br /><br />
            </asp:PlaceHolder>
            

            <br />
            <asp:Label CssClass="col-form-label-lg" ID="Label8" runat="server" Text="">狀態權重</asp:Label><br /><br />
            
            <asp:PlaceHolder ID="ph_StateWeightList" runat="server">
                <asp:TextBox CssClass="form-control-sm w-50 text-center" ID="txt_StateInput1" runat="server" Text="因公出國"></asp:TextBox>
                <asp:DropDownList CssClass="btn w-25 text-center" ID="ddl_StateWeightSelect1" runat="server">
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
                  <asp:TextBox CssClass="form-control-sm w-50 text-center" ID="txt_StateInput2" runat="server" Text="業務出國"></asp:TextBox>
                <asp:DropDownList CssClass="btn w-25 text-center" ID="ddl_StateWeightSelect2" runat="server">
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
                  <asp:TextBox CssClass="form-control-sm w-50 text-center" ID="txt_StateInput3" runat="server" Text="重大傷病"></asp:TextBox>
                <asp:DropDownList CssClass="btn w-25 text-center" ID="ddl_StateWeightSelect3" runat="server">
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
                  <asp:TextBox CssClass="form-control-sm w-50 text-center" ID="txt_StateInput4" runat="server" ></asp:TextBox>
                <asp:DropDownList CssClass="btn w-25 text-center" ID="ddl_StateWeightSelect4" runat="server">
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
                  <asp:TextBox CssClass="form-control-sm w-50 text-center" ID="txt_StateInput5" runat="server"></asp:TextBox>
                <asp:DropDownList CssClass="btn w-25 text-center" ID="ddl_StateWeightSelect5" runat="server">
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
                </asp:DropDownList><br /><br />
            </asp:PlaceHolder>
        </asp:PlaceHolder>
        <br />
        <asp:Button CssClass="btn btn-outline-danger btn-lg" ID="btnCalculate" runat="server" Text="進行配對" OnClick="btnCalculate_Click" Visible="false" /><br /><br /><br />
    </div>
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
<%--    <asp:Literal ID="ltShow" runat="server"></asp:Literal>--%>

</asp:Content>