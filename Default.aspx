<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_Promo_Web_Equipo10B.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h3 class="destacado">Destacados del mes</h3>

    <div class="container mt-5 mb-5">
        <div class="row">
            <div class="col">
                <div class="card ">
                    <div class="card-details">
                        <p class="text-title">Producto 1</p>
                        <p class="text-codigo">Código del producto</p>
                        <p class="text-body">Descripción del producto</p>
                        <p class="text-marca">Marca del producto</p>
                    </div>
                    <button class="card-button" onclick="mostrarFormVoucher()">Canjear</button>
                </div>
            </div>

            <div class="col">
                <div class="card ">
                    <div class="card-details">
                        <p class="text-title">Producto 2</p>
                        <p class="text-codigo">Código del producto</p>
                        <p class="text-body">Descripción del producto</p>
                        <p class="text-marca">Marca del producto</p>
                    </div>
                    <button class="card-button" onclick="mostrarFormVoucher()">Canjear</button>
                </div>
            </div>

            <div class="col">
                <div class="card ">
                    <div class="card-details">
                        <p class="text-title">Producto 3</p>
                        <p class="text-codigo">Código del producto</p>
                        <p class="text-body">Descripción del producto</p>
                        <p class="text-marca">Marca del producto</p>
                    </div>
                    <button class="card-button" onclick="mostrarFormVoucher()">Canjear</button>
                </div>
            </div>
        </div>
    </div>
    <div id="registro-voucher" class="overlay">
        <div class="modal-form card" style="width: 600px;">
            <h3 class="card-title mb-3 mt-3" style="text-align: center;">Canjea tu voucher</h3>
            <!--<input placeholder="Código" class="form-control mb-3 mt-3" id="codigo" name="codigo" required>-->
            <asp:TextBox ID="TxbCodigo" placeholder="Código" class="form-control mb-3 mt-3" name="codigo" required runat="server"></asp:TextBox>
            <div class="row mb-3 mt-3" style="text-align: center;">
                <div class="col">
                    <button class="B_serch" style="width: 150px;">Ingresar</button>
                </div>
                <div class="col">
                    <button class="B_serch " style="width: 150px;" onclick="cerrarFormVoucher()">Cerrar</button>
                </div>
            </div>
            <p class="card-text" style="font-size: 12px; text-align: center;">Ingresá el código que te dieron con tu compra. Podrás obtener importantes premios</p>
        </div>
    </div>
</asp:Content>
