<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Report.SystemAdmin.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gvAdminList" runat="server" AutoGenerateColumns="False" align="center" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" >
            <Columns>
                <asp:TemplateField HeaderText="等級">
                    <ItemTemplate>
                        <%# ((int)Eval("UserLevel") == 0) ? "管理者" : "會員" %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="AdminName" HeaderText="使用者" />
                <asp:BoundField DataField="AdminAccount" HeaderText="帳號" />
                <asp:TemplateField >
                    <ItemTemplate>
                       <a href="/SystemAdmin/AdminEdit.aspx?AdminID=<%# Eval("AdminID") %>">編輯</a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
            </asp:GridView>
        <br />
        <div align="center">
            <asp:Button ID="btnEdit" runat="server" Text="新增管理者名稱" OnClick="btnEdit_Click"/>
            &emsp;
            <asp:Button ID="btnLogout" runat="server" Text="登出" OnClick="btnLogout_Click" />
        </div>
</asp:Content>
