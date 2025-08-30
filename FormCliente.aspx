<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FormCliente.aspx.cs" Inherits="TP_Promo_Web_Equipo10B.FormCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	   <div id="registro-form" class="overlay">
       <div class="modal-form card" style="width: 600px;">
           <h5 class="card-title" style="text-align: center;">Ingresá para canjear tu premio</h5>

           <div class="form-floating mb-3 mt-3 col">
               <asp:TextBox ID="dni" placeholder="" cssclass="form-control" type="text" name="dni" runat="server" AutoPostBack="false"></asp:TextBox>
               <label for="dni">DNI</label>
           </div>
           <asp:Label ID="Lblvalidacion" runat="server" Text=""></asp:Label>
           <div class="row">
               <div class="form-floating mb-3 mt-4 col-md-6">
                   <asp:TextBox ID="nombre" runat="server" placeholder="" cssclass="form-control" type="text" name="nombre"></asp:TextBox>
                   <label for="nombre">Nombre</label>
               </div>
               <div class="form-floating mb-3 mt-4 col-md-6">
                   <asp:TextBox ID="Apellido" placeholder="" cssclass="form-control" type="text" name="apellido" runat="server"></asp:TextBox>
                   <label for="apellido">Apellido</label>
               </div>
           </div>
           <div class="row">
               <div class="form-floating mb-3 mt-3 col">
                   <asp:TextBox ID="mail" placeholder="" cssclass="form-control" type="email" name="mail" runat="server"></asp:TextBox>
                   <label for="mail">E-mail</label>
               </div>
           </div>
           <div class="row">
               <div class="form-floating mb-3 mt-3 col-md-4">
                   <asp:TextBox ID="direccion" placeholder="" cssclass="form-control" type="text" name="direccion" runat="server"></asp:TextBox>
                   <label for="direccion">Dirección</label>
               </div>
               <div class="form-floating mb-3 mt-3 col-md-4">
                   <asp:TextBox ID="ciudad" placeholder="" cssclass="form-control" type="text" name="ciudad" runat="server"></asp:TextBox>
                   <label for="ciudad">Ciudad</label>
               </div>
               <div class="form-floating mb-3 mt-3 col-md-4">
                   <asp:TextBox ID="cp" placeholder="" cssclass="form-control" type="text" name="cp" runat="server"></asp:TextBox>
                   <label for="cp">Código postal</label>
               </div>
           </div>

           <div class="row pt-4" style="text-align: center;">
               <div class="col">
                   <asp:Button ID="BtnIngresar" cssclass="B_serch" type="submit" Style="width: 10vw;" runat="server" OnClick="BtnIngresar_Click" Text="Ingresar" />
               </div>
               <div class="col">
                   <button class="B_serch " style="width: 10vw;" onclick="cerrarFormulario()">Cerrar</button>
                   <!--<asp:Button ID="BtnCerrar" runat="server" CssClass="B_serch" Text="Cerrar" OnClientClick="cerrarFormulario(); return false;" />-->
               </div>
           </div>
       </div>
   </div>

</asp:Content>
