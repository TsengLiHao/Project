<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MemberPWD.aspx.cs" Inherits="Report.SystemMember.MemberPWD" %>
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
           bottom:200px;
           left:570px;
        }
    </style>
    
        <h1 align="center">Edit Password</h1>
        <br />
        <div id="divText">
            <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="帳號:"></asp:Label>
            <asp:TextBox ID="txtAccount" runat="server" CssClass="txt"></asp:TextBox><br />
            <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="舊密碼:"></asp:Label>
            <asp:TextBox ID="txtPWD" runat="server" CssClass="txt" TextMode="Password"></asp:TextBox><br />
            <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="新密碼:"></asp:Label>
            <asp:TextBox ID="txtNewPWD" runat="server" CssClass="txt" TextMode="Password"></asp:TextBox><br />
            <asp:Label ID="Label4" runat="server" CssClass="lbl" Text="新密碼確認:"></asp:Label>
            <asp:TextBox ID="txtDoubleCheck" runat="server" CssClass="txt" TextMode="Password"></asp:TextBox><br />
        </div>
            <br />
        <div id="divButton">
            <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
            <br />
            <asp:Button ID="btnConfirm" runat="server" Text="確認修改" OnClick="btnConfirm_Click"/>
            &emsp;
            <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click"/> 
        </div>
</asp:Content>
