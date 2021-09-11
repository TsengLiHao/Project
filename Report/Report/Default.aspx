<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Report.HP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="left">
        <tr>
            <td>
                &emsp;<asp:Button ID="btnMemberInfo" runat="server" Text="會員資訊" Visible="false" OnClick="btnMemberInfo_Click" CssClass="btn btn-dark"/>
                <br />
                <br />
                &emsp;<asp:Button ID="btnEditProduct" runat="server" Text="管理商品" Visible="false" OnClick="btnEditProduct_Click" CssClass="btn btn-dark"/>
                <br />
                <br />
                &emsp;<asp:Button ID="btnOrderList" runat="server" Text="管理訂單" Visible="false" OnClick="btnOrderList_Click" CssClass="btn btn-dark"/>
                <br />
                <br />
                &emsp;<asp:Button ID="btnStock" runat="server" Text="管理庫存" Visible="false" OnClick="btnStock_Click" CssClass="btn btn-dark"/>
                <br />
                <br />
            </td>
        </tr>
    </table>
    <div  align="center">
    <div id="carouselExampleCaptions" class="carousel slide" data-bs-ride="carousel" style="width:600px;height:300px">
        <div class="carousel-indicators">
            <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
            <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="1" aria-label="Slide 2"></button>
            <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="2" aria-label="Slide 3"></button>
        </div>
        <div class="carousel-inner">
            <div class="carousel-item active">
                <img src="image/cheese.jpg" class="d-block w-100 h-100" alt="...">
                <div class="carousel-caption d-none d-md-block">
                    <h5></h5>
                    <p></p>
                </div>
            </div>
            <div class="carousel-item">
                <img src="image/cheese2.jpg" class="d-block w-100 h-100" alt="...">
                <div class="carousel-caption d-none d-md-block">
                    <h5></h5>
                    <p></p>
                </div>
            </div>
            <div class="carousel-item">
                <img src="image/cheese3.jpg" class="d-block w-100 h-100" alt="...">
                <div class="carousel-caption d-none d-md-block">
                    <h5></h5>
                    <p></p>
                </div>
            </div>
        </div>
        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
        </button>
    </div>
</div>
</asp:Content>
