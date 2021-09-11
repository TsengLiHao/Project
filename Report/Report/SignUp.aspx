<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Report.SignUp" %>
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
    
        <h1 align="center">Sign Up</h1>
        <br />
        <div id="divText" align="center">
            <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="姓名:"></asp:Label>
            <asp:TextBox ID="txtName" runat="server" CssClass="txt"></asp:TextBox><br />
            <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="地址:"></asp:Label>
            <asp:TextBox ID="txtAdress" runat="server" CssClass="txt"></asp:TextBox><br />
            <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="電話(手機):"></asp:Label>
            <asp:TextBox ID="txtPhone" runat="server" CssClass="txt" TextMode="Number"></asp:TextBox><br />
            <asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Email:"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="txt" TextMode="Email"></asp:TextBox><br />
            <asp:Label ID="Label5" runat="server" CssClass="lbl" Text="帳號:"></asp:Label>
            <asp:TextBox ID="txtAccount" runat="server" CssClass="txt"></asp:TextBox><br />
            &emsp;&emsp;&emsp;&emsp;&emsp;&emsp;<asp:Label ID="Label8" runat="server" Text="帳號名稱創立後不可更改"></asp:Label><br />

            <asp:Label ID="Label6" runat="server" CssClass="lbl" Text="密碼:"></asp:Label>
            <asp:TextBox ID="txtPWD" runat="server" CssClass="txt" TextMode="Password"></asp:TextBox><br />
            <asp:Label ID="Label7" runat="server" CssClass="lbl" Text="密碼確認:"></asp:Label>
            <asp:TextBox ID="txtDoubleCheck"  runat="server" CssClass="txt" TextMode="Password"></asp:TextBox><br />
        </div>
            <br />
        <div id="divButton" align="center">
            <span style="color: red">
            <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
            </span>
            <br />
            <asp:Button ID="btnConfirm" runat="server" Text="確認" OnClick="btnConfirm_Click" CssClass="btn btn-dark"/>
            &emsp;
            <asp:Button ID="btnClear" runat="server" Text="重新輸入" OnClick="btnClear_Click" CssClass="btn btn-dark"/> 
        </div>
</asp:Content>
