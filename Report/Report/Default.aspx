<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Report.HP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <h2>新鮮起司（Fresh Cheese）</h2>
    </div>
    <div align="center">
        <input type="button" data-bs-toggle="modal" data-bs-target="#exampleModal" style="background-image: url(image/logo.jpg); border: none; width: 200px; height: 200px; background-size: 100%">
        &emsp;
        <input type="button" data-bs-toggle="modal" data-bs-target="#exampleModal" style="background-image: url(image/logo.jpg); border: none; width: 200px; height: 200px; background-size: 100%">
    </div>
    

    <div align="center">
        <h2>水洗式起司 (Washed Rind Cheese)</h2>
    </div>
    <div align="center">
        <input type="button" data-bs-toggle="modal" data-bs-target="#exampleModal" style="background-image: url(image/logo.jpg); border: none; width: 200px; height: 200px; background-size: 100%">
        &emsp;
        <input type="button" data-bs-toggle="modal" data-bs-target="#exampleModal" style="background-image: url(image/logo.jpg); border: none; width: 200px; height: 200px; background-size: 100%">
    </div>

    <div align="center">
        <h2>白黴起司 (White Mould Cheese)</h2>
    </div>
    <div align="center">
        <input type="button" data-bs-toggle="modal" data-bs-target="#exampleModal" style="background-image: url(image/logo.jpg); border: none; width: 200px; height: 200px; background-size: 100%">
        &emsp;
        <input type="button" data-bs-toggle="modal" data-bs-target="#exampleModal" style="background-image: url(image/logo.jpg); border: none; width: 200px; height: 200px; background-size: 100%">
    </div>

    <div align="center">
        <h2>半硬質起司（Semi-Hard Cheese）</h2>
    </div>
    <div align="center">
        <input type="button" data-bs-toggle="modal" data-bs-target="#exampleModal" style="background-image: url(image/logo.jpg); border: none; width: 200px; height: 200px; background-size: 100%">
        &emsp;
        <input type="button" data-bs-toggle="modal" data-bs-target="#exampleModal" style="background-image: url(image/logo.jpg); border: none; width: 200px; height: 200px; background-size: 100%">
    </div>

    <div align="center">
        <h2>硬質起司（Hard Cheeses）</h2>
    </div>
    <div align="center">
        <input type="button" data-bs-toggle="modal" data-bs-target="#exampleModal" style="background-image: url(image/logo.jpg); border: none; width: 200px; height: 200px; background-size: 100%">
        &emsp;
        <input type="button" data-bs-toggle="modal" data-bs-target="#exampleModal" style="background-image: url(image/logo.jpg); border: none; width: 200px; height: 200px; background-size: 100%">
    </div>

    <div align="center">
        <h2>羊奶起司 (Chever Cheese)</h2>
    </div>
    <div align="center">
        <input type="button" data-bs-toggle="modal" data-bs-target="#exampleModal" style="background-image: url(image/logo.jpg); border: none; width: 200px; height: 200px; background-size: 100%">
        &emsp;
        <input type="button" data-bs-toggle="modal" data-bs-target="#exampleModal" style="background-image: url(image/logo.jpg); border: none; width: 200px; height: 200px; background-size: 100%">
    </div>

    <div align="center">
        <h2>藍紋起司（Blue-Vein Cheese）</h2>
    </div>
    <div align="center">
        <input type="button" data-bs-toggle="modal" data-bs-target="#exampleModal" style="background-image: url(image/logo.jpg); border: none; width: 200px; height: 200px; background-size: 100%">
        &emsp;
        <input type="button" data-bs-toggle="modal" data-bs-target="#exampleModal" style="background-image: url(image/logo.jpg); border: none; width: 200px; height: 200px; background-size: 100%">
    </div>

    <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">莫札瑞拉（Mozzarella）</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    [商品詳細]莫札瑞拉是起源於義大利的淡起司，莫札瑞拉通常呈純白色或米白色，口感滑順、風味清新，加熱可以產生強烈的拉絲效果。傳統莫札瑞拉以水牛乳製作，但現在多數已由牛乳取代。
                    [料理用法]莫札瑞拉適合品嚐原味，可搭配切片番茄、新鮮羅勒葉，再加上海鹽與幾滴橄欖油食用。
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
