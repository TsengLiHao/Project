<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="OrderPage.aspx.cs" Inherits="Report.OrderPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="Script/jquery-3.6.0.min.js"></script>
    <style>
        th{
            display:inline-block;
            width: 120px;
            position:fixed;
        }
    </style>
 
    <div align="center">
        <asp:HiddenField ID="HiddenField1" runat="server" Value=""/>
        
        <table width="100%" style="border-spacing: 100px;">
            <tr>
                <td align="center">
                    <asp:Image ID="Image1" runat="server" Width="250" Height="250"/>
                </td>
                <td align="center" valign="top"><b style="padding-right:60px;margin-left:-60px">選擇商品:</b>
               <asp:DropDownList ID="ddlProduct" runat="server" AutoPostBack="true" OnTextChanged="ddlProduct_TextChanged" Width="190">
               </asp:DropDownList>
                    <div align="center"">
                            <br />
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false" >
                            <table>
                                <tr>
                                    <th>單價:</th>
                                    <td style="padding-left:130px"> 
                                        <asp:Literal ID="ltlPrice" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <th>重量:</th>
                                    <td style="padding-left:130px">
                                        <asp:Literal ID="ltlWeight" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <th>製造日期:</th>
                                    <td style="padding-left:130px">
                                        <asp:Literal ID="ltlFirst" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <th>有效日期:</th>
                                    <td style="padding-left:130px">
                                        <asp:Literal ID="ltlLast" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <th>其他商品資訊:</th>
                                    <td style="padding-left:130px">
                                        <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Width="250" Height="100" ReadOnly="true" BackColor="antiquewhite" BorderColor="antiquewhite"></asp:TextBox>
                                    </td>

                            </table></asp:PlaceHolder>
                            <asp:Literal ID="ltlProductStatus" runat="server"></asp:Literal>
                    </div>
                </td>
                <td align="center" valign="top">
                    <b>輸入數量:</b>
                    <asp:TextBox ID="txtValue" runat="server"></asp:TextBox>
                   <br />
                    <br>
                    <b >選擇付款方式:</b>
                    <asp:RadioButtonList ID="rblPayment" runat="server">
                        <asp:ListItem Value="0" Selected="True" Text="現金"></asp:ListItem>
                        <asp:ListItem Value="1" Text="信用卡"></asp:ListItem>
                    </asp:RadioButtonList>
                    <br />
                    <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div id="divButton" align="center">
        <asp:Button ID="btnConfirm" runat="server" Text="確認購買" OnClick="btnConfirm_Click"/>
        &emsp;
            <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click"/>
        
    </div>

</asp:Content>
