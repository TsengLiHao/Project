<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EditStock.aspx.cs" Inherits="Report.SystemStock.EditStock" %>
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
    
        <h1 align="center">Edit Stock</h1>
        <br />
        <div id="divText" align="center">
            <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="商品名稱:"></asp:Label>
            <asp:TextBox ID="txtName" runat="server" CssClass="txt"></asp:TextBox><br />
            <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="庫存數量:"></asp:Label>
            <asp:TextBox ID="txtCurrentValue" runat="server" CssClass="txt" TextMode="Number"></asp:TextBox><br />
            <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="已訂購商品數:"></asp:Label>
            <asp:TextBox ID="txtOrderedValue" runat="server" CssClass="txt" TextMode="Number"></asp:TextBox><br />
            <asp:Label ID="Label4" runat="server" CssClass="lbl" Text="商品狀態:"></asp:Label>
            <asp:TextBox ID="txtStatus" runat="server" CssClass="txt" TextMode="Number" ></asp:TextBox><br />
            <asp:Label ID="Label6" runat="server" Text="商品狀態輸入值為( 0 : 已過期 ; 1 : 良好)"></asp:Label><br>
            
        </div>
            <br />
        <div id="divButton" align="center">
            <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
            <br />
            <asp:Button ID="btnConfirm" runat="server" Text="確認修改" OnClick="btnConfirm_Click"/>
            &emsp;
            <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click"/> 
        </div>
</asp:Content>
