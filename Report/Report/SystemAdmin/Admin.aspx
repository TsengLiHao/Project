<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Report.SystemAdmin.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gvAdminList" runat="server" AutoGenerateColumns="False" align="center" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" >
            <Columns>
                <asp:TemplateField HeaderText="等級">
                    <ItemTemplate>
                        <%# ((int)Eval("UserLevel") == 0) ? "管理者" : "會員" %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="AdminName" HeaderText="使用者" />
                <asp:BoundField DataField="AdminAccount" HeaderText="帳號" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>
        <br />
        <div align="center">
            <asp:Button ID="btnEdit" runat="server" Text="編輯管理者資訊" OnClick="btnEdit_Click"/>
            &emsp;
            <asp:Button ID="btnMemberList" runat="server" Text="會員資訊" OnClick="btnMemberList_Click"/>
            &emsp;
            <asp:Button ID="btnLogout" runat="server" Text="登出" OnClick="btnLogout_Click" />
        </div>
</asp:Content>
