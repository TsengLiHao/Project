﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MemberOrderEdit.aspx.cs" Inherits="Report.SystemMember.MemberOrderEdit" %>
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
        <br />
    <asp:HiddenField ID="HiddenField1" runat="server" />
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
            <asp:TextBox ID="txtQuantity" runat="server" CssClass="txt" Enabled="false"></asp:TextBox><br />
            <asp:Label ID="Label9" runat="server" CssClass="lbl" Text="總計金額:"></asp:Label>
            <asp:TextBox ID="txtTotal" runat="server" CssClass="txt" Enabled="false"></asp:TextBox><br />
            <asp:Label ID="Label10" runat="server" CssClass="lbl" Text="付款方式:"></asp:Label>
            <asp:TextBox ID="txtPayment" runat="server" CssClass="txt" Enabled="false"></asp:TextBox><br />
            <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="訂購日期:"></asp:Label>
            <asp:TextBox ID="txtDate" runat="server" CssClass="txt" Enabled="false"></asp:TextBox>
        </div>
            <br />
        <div id="divButton" align="center">
            <span style="color:red">
            <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
            </span>
            <br />
            <br />
            <asp:Button ID="btnConfirm" runat="server" Text="確認取消訂單" OnClick="btnConfirm_Click" OnClientClick="return confirm('確定取消這筆訂單嗎?')" CssClass="btn btn-dark"/>
            &emsp;
            <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" CssClass="btn btn-dark"/> 
        </div>
</asp:Content>
