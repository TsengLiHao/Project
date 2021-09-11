<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="Report.SystemMember.Member" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gvMemberList" runat="server" AutoGenerateColumns="False" CellPadding="3" align="center" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2" >
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
        <div align="center">
            <span style="color:red">
            <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
            </span>
            <br />
            <br />
            <asp:Button ID="btnEdit" runat="server" Text="變更個人資訊" OnClick="btnEdit_Click" CssClass="btn btn-dark"/>
            &emsp;
            <asp:Button ID="btnLogout" runat="server" Text="登出" OnClick="btnLogout_Click" CssClass="btn btn-dark"/>
        </div>
</asp:Content>
