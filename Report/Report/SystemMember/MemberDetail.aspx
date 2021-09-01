﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MemberDetail.aspx.cs" Inherits="Report.SystemMember.MemberDetail" %>
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
        #divText{
            position:absolute;
            left:350px;
        }
        #divButton{
           position:absolute;
           bottom:170px;
           left:570px;
        }
    </style>
    
        <h1 align="center">Edit</h1>
        <br />
        <div id="divText">
            <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="帳號:"></asp:Label>
            <asp:TextBox ID="txtAccount" runat="server" CssClass="txt"></asp:TextBox><br />
            <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="姓名:"></asp:Label>
            <asp:TextBox ID="txtName" runat="server" CssClass="txt"></asp:TextBox><br />
            <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="地址:"></asp:Label>
            <asp:TextBox ID="txtAdress" runat="server" CssClass="txt"></asp:TextBox><br />
            <asp:Label ID="Label4" runat="server" CssClass="lbl" Text="電話(手機):"></asp:Label>
            <asp:TextBox ID="txtPhone" runat="server" CssClass="txt" TextMode="Phone"></asp:TextBox><br />
            <asp:Label ID="Label5" runat="server" CssClass="lbl" Text="Email:"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="txt" TextMode="Email"></asp:TextBox><br />
        </div>
            <br />
        <div id="divButton">
            <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
            <br />
            <asp:Button ID="btnConfirm" runat="server" Text="確認修改" OnClick="btnConfirm_Click"/>
            &emsp;
            <asp:Button ID="btnChangePWD" runat="server" Text="變更密碼" OnClick="btnChangePWD_Click"/> 
            &emsp;
            <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" />
        </div>
</asp:Content>