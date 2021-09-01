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
        #divText{
            position:absolute;
            left:350px;
            float:left;
        }
        #divButton{
           position:absolute;
           bottom:240px;
           left:460px;
           float:left;
        }
    </style>
   
        <h1 align="center">Login</h1>
        <br />
        <div id="divText">
        <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="帳號:"></asp:Label>
        <asp:TextBox ID="txtAccount" runat="server" CssClass="txt"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="密碼:"></asp:Label>
        <asp:TextBox ID="txtPWD" runat="server" TextMode="Password" CssClass="txt"></asp:TextBox>
        </div>
       
         <div id="divButton">
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
        <br />
        <asp:Button ID="btnLogin" runat="server" Text="會員登入" OnClick="btnLogin_Click" />
        &emsp;
        <asp:Button ID="btnAdmin" runat="server" Text="管理者登入" OnClick="btnAdmin_Click" />
        &emsp;
        <asp:Button ID="btnSignUp" runat="server" Text="註冊" OnClick="btnSignUp_Click"/>
        &emsp;
        <asp:Button ID="btnForgetPWD" runat="server" Text="忘記密碼" OnClick="btnForgetPWD_Click" />
       
        
    </div>

</asp:Content>
