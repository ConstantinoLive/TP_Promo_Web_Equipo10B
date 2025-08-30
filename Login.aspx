<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TP_Promo_Web_Equipo10B.FormularioCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<main>
		<div id="registro-form" class="overlay">
				<!--<div class="modal-form card" style="width: 600px;">-->
					<div class="card" style="width: 600px;">
					<h5 class="card-title" style="text-align: center;">Ingresá para canjear tu premio</h5>

					<div class="form-floating mb-3 mt-3 col">
						<asp:TextBox ID="dni" placeholder="" CssClass="form-control"  runat="server"></asp:TextBox>
						<label for="dni">DNI</label>
					</div>
					<asp:Label ID="Lblvalidacion" runat="server"  Text=""></asp:Label>
					
					<div class="row">
						<div class="form-floating mb-3 mt-4 col-md-6">
							<asp:TextBox ID="nombre" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
							<label for="nombre">Nombre</label>
						</div>
						<div class="form-floating mb-3 mt-4 col-md-6">
							<asp:TextBox ID="Apellido" placeholder="" CssClass="form-control" runat="server"></asp:TextBox>
							<label for="apellido">Apellido</label>
						</div>
					</div>
					<div class="row">
						<div class="form-floating mb-3 mt-3 col">
							<asp:TextBox ID="mail" placeholder="" CssClass="form-control" runat="server"></asp:TextBox>
							<label for="mail">E-mail</label>
						</div>
					</div>
					<div class="row">
						<div class="form-floating mb-3 mt-3 col-md-4">
							<asp:TextBox ID="direccion" placeholder="" CssClass="form-control" runat="server"></asp:TextBox>
							<label for="direccion">Dirección</label>
						</div>
						<div class="form-floating mb-3 mt-3 col-md-4">
							<asp:TextBox ID="ciudad" placeholder="" CssClass="form-control" runat="server"></asp:TextBox>
							<label for="ciudad">Ciudad</label>
						</div>
						<div class="form-floating mb-3 mt-3 col-md-4">
							<asp:TextBox ID="cp" placeholder="" CssClass="form-control" runat="server"></asp:TextBox>
							<label for="cp">Código postal</label>
						</div>
					</div>

					<div class="row pt-4" style="text-align: center;">
						<div class="col">
						<asp:Button ID="BtnIngresarDatos" CssClass="B_serch" Style="width: 10vw;" runat="server" Text="Ingresar" />
						</div>
						<div class="col">
						<asp:Button ID="BtnCerrar" runat="server" CssClass="B_serch" Style="width: 10vw;" OnClientClick="cerrarFormulario()" Text="Cerrar" />
						</div>
					</div>
				</div>
</div>

	</main>
</asp:Content>
