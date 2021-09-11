<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Report.Login" %>
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
   
        <h1 align="center">Login</h1>
        <br />
        <div id="divText" align="center">
        <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="帳號:"></asp:Label><br />
        <asp:TextBox ID="txtAccount" runat="server" CssClass="txt"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="密碼:"></asp:Label><br />
        <asp:TextBox ID="txtPWD" runat="server" TextMode="Password" CssClass="txt"></asp:TextBox>
        </div>
       
         <div id="divButton" align="center">
            <span style="color: red">
            <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
            </span>
        <br />
        <asp:Button ID="btnLogin" runat="server" Text="登入" OnClick="btnLogin_Click" CssClass="btn btn-dark"/>
        &emsp;
        <asp:Button ID="btnSignUp" runat="server" Text="註冊" OnClick="btnSignUp_Click" CssClass="btn btn-dark"/>
        &emsp;
        <asp:Button ID="btnForgetPWD" runat="server" Text="忘記密碼" OnClick="btnForgetPWD_Click" CssClass="btn btn-dark"/>
       
        
    </div>

</asp:Content>
