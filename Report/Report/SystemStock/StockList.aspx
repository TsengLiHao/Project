<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="StockList.aspx.cs" Inherits="Report.SystemStock.StockList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gvStockList" runat="server" AutoGenerateColumns="False" CellPadding="3" align="center" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2" >
            <Columns>
                <asp:BoundField DataField="ProductName" HeaderText="商品名稱" />
                <asp:BoundField DataField="CurrentQuantity" HeaderText="庫存數量" />
                <asp:BoundField DataField="OrderedQuantity" HeaderText="已訂購商品數量" />
                <asp:BoundField DataField="ExpirationQuantity" HeaderText="即期品數量" />
                <asp:BoundField DataField="ProductStatus" HeaderText="商品狀態 : (0 : 已過期 ; 1 : 良好)" />
                <asp:BoundField DataField="ChangedDate" HeaderText="變更日期" />
                <asp:TemplateField>
                <ItemTemplate>
                    <a href="/SystemStock/EditStock.aspx?StockID=<%# Eval("StockID") %>">編輯</a>
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
        <div align="center">
            <span style="color: red">
            <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
            </span>
            <br />
            <asp:Button ID="btnEdit" runat="server" Text="新增庫存商品" OnClick="btnEdit_Click" CssClass="btn btn-dark"/>
            &emsp;
            <asp:Button ID="btnLogout" runat="server" Text="回首頁" OnClick="btnLogout_Click" CssClass="btn btn-dark"/>
        </div>
</asp:Content>
