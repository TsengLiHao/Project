<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="Report.SystemMember.Member" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gvMemberList" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="Black" GridLines="Horizontal" align="center" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
            <Columns>
                <asp:TemplateField HeaderText="等級">
                    <ItemTemplate>
                        <%#  ((int)Eval("UserLevel") == 0) ? "管理者" : "會員"%>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:BoundField DataField="MemberName" HeaderText="姓名" />
                <asp:BoundField DataField="Account" HeaderText="帳號" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="MobilePhone" HeaderText="電話(手機)" />
                <asp:BoundField DataField="Adress" HeaderText="地址" />
                <asp:BoundField DataField="CreateDate" HeaderText="創建日期" />
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
        <div align="center">
            <asp:Button ID="btnEdit" runat="server" Text="變更個人資訊" OnClick="btnEdit_Click"/>
            &emsp;
            <asp:Button ID="btnLogout" runat="server" Text="登出" OnClick="btnLogout_Click" />
        </div>
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
</asp:Content>
