<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MemberList.aspx.cs" Inherits="Report.SystemAdmin.MemberList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gvMemberList" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" align="center" >
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

                <asp:TemplateField >
                    <ItemTemplate>
                       <a href="/SystemAdmin/MemberEdit.aspx?UserID=<%# Eval("UserID") %>">編輯</a>
                    </ItemTemplate>
                </asp:TemplateField>

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
            <asp:Button ID="btnBack" runat="server" Text="返回" OnClick="btnBack_Click"/>
        </div>
</asp:Content>
