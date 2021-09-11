<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="Report.SystemProduct.ProductList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gvProductList" runat="server" AutoGenerateColumns="False" CellPadding="3" align="center" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2" >
        <Columns>
            <asp:BoundField DataField="ProductName" HeaderText="商品名稱" />
            <asp:BoundField DataField="UnitPrice" HeaderText="單價" />
            <asp:BoundField DataField="WeightPerUnit" HeaderText="重量" />
            <asp:BoundField DataField="ManufactureDate" HeaderText="製造日期" DataFormatString="{0:yyyy/MM/dd}" />
            <asp:BoundField DataField="ExpirationDate" HeaderText="有效日期" DataFormatString="{0:yyyy/MM/dd}"/>
            <asp:BoundField DataField="Body" HeaderText="其他商品資訊" />
            <asp:BoundField DataField="Discontinued" HeaderText="商品狀態 (0 : 下架中 ; 1 : 上架中)" />
            <asp:TemplateField HeaderText="商品照">
                <ItemTemplate>
                    <asp:Image runat="server" ID="imgCover" Width="80" Height="50"
                        Visible='<%# Eval("Photo") != null %>'
                        ImageUrl='<%# "../FileDownload/Admin/" + Eval("Photo") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <a href="/SystemProduct/EditProduct.aspx?ProductID=<%# Eval("ProductID") %>">編輯</a>
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
            <asp:Button ID="btnCreate" runat="server" Text="新增商品" OnClick="btnCreate_Click" CssClass="btn btn-dark"/>
            &emsp;
            <asp:Button ID="btnBack" runat="server" Text="回首頁" OnClick="btnBack_Click" CssClass="btn btn-dark"/>
        </div>
</asp:Content>
