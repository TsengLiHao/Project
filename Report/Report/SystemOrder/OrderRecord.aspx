<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="OrderRecord.aspx.cs" Inherits="Report.SystemOrder.OrderRecord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gvOrderList" runat="server" AutoGenerateColumns="False" CellPadding="3" align="center" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2">
            <Columns>
                <asp:BoundField DataField="Account" HeaderText="帳號" />
                <asp:BoundField DataField="MemberName" HeaderText="姓名" />
                <asp:BoundField DataField="ProductName" HeaderText="商品名稱" />
                <asp:BoundField DataField="UnitPrice" HeaderText="單價" />
                <asp:BoundField DataField="OrderedQuantity" HeaderText="數量" />
                <asp:TemplateField HeaderText="總計金額">
                    <ItemTemplate>
                        <%# Convert.ToDecimal(Eval("UnitPrice")) * Convert.ToInt32(Eval("OrderedQuantity")) %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Payment" HeaderText="付款方式" />
                <asp:BoundField DataField="OrderDate" HeaderText="訂購日期" />
                <asp:TemplateField >
                    <ItemTemplate>
                       <a href="/SystemMember/MemberOrderEdit.aspx?OrderID=<%# Eval("OrderID") %>">取消訂單</a>
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
        <asp:Button ID="btnBack" runat="server" Text="回首頁" OnClick="btnBack_Click" CssClass="btn btn-dark"/>
    </div>
        
</asp:Content>
