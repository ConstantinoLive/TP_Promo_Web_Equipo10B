<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_Promo_Web_Equipo10B.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h3 class="destacado">Destacados del mes</h3>

    <div class="container mt-5 mb-5">
        <div class="row">

            <%
                foreach (Dominio.Articulos Art in ListaArticulos)
                {
                    string carouselId = "carousel_" + Art.IdProductos;
            %>
            <div class="col">
                <div class="card ">
                    <div class="card-details">
                        <div class="card-img-top">
                            <div id="<%= carouselId %>" class="carousel slide" data-bs-ride="false" >
                                <div class="carousel-inner"> 
                                    <%
                                        var imagenesArticulo = ListarImagenes.Where(img => img.IdArticulo == Art.IdProductos).ToList();
                                        bool firstImage = true;
                                        foreach (Dominio.Imagenes Img in imagenesArticulo)
                                        {
                                    %>
                                            <div class="carousel-item <%= firstImage ? "active" : "" %>">

                                            <img src="<%= Img.ImagenUrl %>" alt="<%:Art.Nombre %>" class="d-block w-100 h-100" style="object-fit: contain;" />
                                            </div>
                                          <% firstImage = false;
                                        } %>
                                </div>
                                <button class="carousel-control-prev" type="button" data-bs-target="#<%= carouselId %>" data-bs-slide="prev">
                                    <span class="carousel-control-prev-icon"></span>
                                </button>
                                <button class="carousel-control-next" type="button" data-bs-target="#<%= carouselId %>" data-bs-slide="next">
                                    <span class="carousel-control-next-icon"></span>
                                </button>
                            </div>
                        </div>

                        <p class="text-title"><%:Art.Nombre %></p>
                        <p class="text-codigo"><%:Art.CodArticulo%></p>
                        <p class="text-body"><%:Art.Descripcion%></p>
                        <p class="text-marca"><%:Art.Marca%></p>
                    </div>
                    <button class="card-button" onclick="mostrarFormVoucher()">Canjear</button>
                </div>
            </div>

            <% }%>
        </div>
    </div>
    <div id="registro-voucher" class="overlay">
        <div class="modal-form card" style="width: 600px;">
            <h3 class="card-title mb-3 mt-3" style="text-align: center;">Canjea tu voucher</h3>
            <!--<input placeholder="Código" class="form-control mb-3 mt-3" id="codigo" name="codigo" required>-->
            <asp:TextBox ID="TxbCodigo" placeholder="Código" class="form-control mb-3 mt-3" name="codigo" required runat="server"></asp:TextBox>
            <div class="row mb-3 mt-3" style="text-align: center;">
                <div class="col">
                    <!--<button class="B_serch" style="width: 150px;">Ingresar</button>-->
                    <asp:Button ID="BtnIngresar" class="B_serch" Style="width: 150px;" runat="server" Text="Ingresar" />
                </div>
                <div class="col">
                    <button class="B_serch " style="width: 150px;" onclick="cerrarFormVoucher()">Cerrar</button>
                </div>
            </div>
            <p class="card-text" style="font-size: 12px; text-align: center;">Ingresá el código que te dieron con tu compra. Podrás obtener importantes premios</p>
        </div>
    </div>
</asp:Content>
