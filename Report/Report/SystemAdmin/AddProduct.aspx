<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="Report.SystemAdmin.AddProduct" %>
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
    
        <h1 align="center">Add Product</h1>
        <br />
        <div id="divText" align="center">
            <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="商品名稱:"></asp:Label>
            <asp:TextBox ID="txtName" runat="server" CssClass="txt"></asp:TextBox><br />
            <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="單價:"></asp:Label>
            <asp:TextBox ID="txtPrice" runat="server" CssClass="txt" TextMode="Number"></asp:TextBox><br />
            <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="重量(g):"></asp:Label>
            <asp:TextBox ID="txtWeight" runat="server" CssClass="txt" ></asp:TextBox><br />
            <asp:Label ID="Label4" runat="server" CssClass="lbl" Text="製造日期"></asp:Label>
            <asp:TextBox ID="txtFirstDate" runat="server" CssClass="txt" TextMode="Date"></asp:TextBox><br />
            <asp:Label ID="Label5" runat="server" CssClass="lbl" Text="有效日期:"></asp:Label>
            <asp:TextBox ID="txtLastDate" runat="server" CssClass="txt" TextMode="Date"></asp:TextBox><br />
            <asp:Label ID="Label7" runat="server" CssClass="lbl" Text="其他商品資訊:"></asp:Label>
            <asp:TextBox ID="txtInfo" runat="server" CssClass="txt" TextMode="MultiLine"></asp:TextBox><br />
            <asp:Label ID="Label8" runat="server" CssClass="lbl" Text="商品狀態:"></asp:Label>
            
            <asp:DropDownList ID="ddlDiscontinued" runat="server" Width="100">
                <asp:ListItem Value="0">0</asp:ListItem>
                <asp:ListItem Value="1">1</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="Label9" runat="server" Text="商品狀態輸入值為( 0 : 下架中 ; 1 : 上架中)"></asp:Label><br />
            <asp:Label ID="Label6" runat="server" CssClass="lbl" Text="商品照:"></asp:Label>
            <asp:FileUpload ID="fileUpload" runat="server" />
        </div>
            <br />
        <div id="divButton" align="center">
            <span style="color:red">
            <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
            </span>
            <br />
            <asp:Button ID="btnConfirm" runat="server" Text="確認新增" OnClick="btnConfirm_Click" CssClass="btn btn-dark"/>
            &emsp;
            <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" CssClass="btn btn-dark"/> 
        </div>
</asp:Content>
