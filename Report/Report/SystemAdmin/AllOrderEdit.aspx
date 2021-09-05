<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AllOrderEdit.aspx.cs" Inherits="Report.SystemAdmin.AllOrderEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style>
        .txt{
           text-align:center;
           width:400px;
           
        }
        .lbl{
           display:inline-block;
           width:100px;
        }
    </style>
    
        <h1 align="center">Cancel Order</h1>
    <asp:HiddenField ID="HiddenField1" runat="server" />
        <br />
        <div id="divText" align="center">
            <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="帳號:"></asp:Label>
            <asp:TextBox ID="txtAccount" runat="server" CssClass="txt" Enabled="false"></asp:TextBox><br />
            <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="姓名:"></asp:Label>
            <asp:TextBox ID="txtName" runat="server" CssClass="txt" Enabled="false"></asp:TextBox><br />
            <asp:Label ID="Label6" runat="server" CssClass="lbl" Text="商品名稱:"></asp:Label>
            <asp:TextBox ID="txtProductName" runat="server" CssClass="txt" Enabled="false"></asp:TextBox><br />
           <asp:Label ID="Label7" runat="server" CssClass="lbl" Text="單價:"></asp:Label>
            <asp:TextBox ID="txtPrice" runat="server" CssClass="txt" Enabled="false"></asp:TextBox><br />
            <asp:Label ID="Label8" runat="server" CssClass="lbl" Text="數量:"></asp:Label>
            <asp:TextBox ID="txtQuantity" runat="server" CssClass="txt" TextMode="Number"></asp:TextBox>
            <br />
            <asp:Button ID="btnCal" runat="server" Text="計算總計金額" OnClick="btnCal_Click" Width="200"/>
            <br />
            <asp:Label ID="Label9" runat="server" CssClass="lbl" Text="總計金額:"></asp:Label>
            <asp:TextBox ID="txtTotal" runat="server" CssClass="txt" Enabled="false"></asp:TextBox><br />
            <asp:Label ID="Label10" runat="server" CssClass="lbl" Text="付款方式:"></asp:Label>
            <asp:TextBox ID="txtPayment" runat="server" CssClass="txt" Enabled="false"></asp:TextBox><br />
            <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="訂購日期:"></asp:Label>
            <asp:TextBox ID="txtDate" runat="server" CssClass="txt" Enabled="false"></asp:TextBox>
        </div>
            <br />
        <div id="divButton" align="center">
            <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
            <br />
            <asp:Button ID="btnConfirm" runat="server" Text="確認修改" OnClick="btnConfirm_Click"/>
            &emsp;
            <asp:Button ID="btnDelete" runat="server" Text="刪除訂單" OnClick="btnDelete_Click"/>
            &emsp;
            <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click"/> 
        </div>
</asp:Content>
