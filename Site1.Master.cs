using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using System.Data;

namespace TP_Promo_Web_Equipo10B
{
    public partial class Site1 : System.Web.UI.MasterPage
    {

        public string nombreCliente;
        public bool ingresoOK;
        public bool registreseOK=false;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["NombreUsuario"] != null)
                {
                    nombreCliente = Session["NombreUsuario"].ToString();
                    ingresoOK = true;
                    formularioRegistroCompleto.Style["display"] = "block";
                    BtnsIngresar.Style["display"] = "none";
                    CheckRegistrese.Enabled = false; 
                }
                else
                {
                    nombreCliente = "Ingresar";
                    ingresoOK = false;
                    formularioRegistroCompleto.Style["display"] = "none";
                    BtnsIngresar.Style["display"] = "block";
                    CheckRegistrese.Enabled = true; 
                }

                lnkNombreCliente.Text = nombreCliente;
            }
            else
            {
                if (Session["NombreUsuario"] != null)
                {
                    lnkNombreCliente.Text = Session["NombreUsuario"].ToString();
                    ingresoOK = true;
                    formularioRegistroCompleto.Style["display"] = "block";
                    BtnsIngresar.Style["display"] = "none";
                    CheckRegistrese.Enabled = false;
                }
                else
                {
                    lnkNombreCliente.Text = "Ingresar";
                    ingresoOK = false;
                    formularioRegistroCompleto.Style["display"] = "none";
                    BtnsIngresar.Style["display"] = "block";
                    CheckRegistrese.Enabled = true;
                }
                
            }


        }

        protected void BtnIngresarDatos_Click(object sender, EventArgs e)
        {
            string dniIngresado = dni.Text;
            

            if (string.IsNullOrWhiteSpace(dniIngresado) || dniIngresado.Length < 7)
            {
                Lblvalidacion.ForeColor = System.Drawing.Color.Red;
                Lblvalidacion.Text = "Por favor, ingrese un DNI válido.";
                Session["NombreUsuario"] = null;
            }

            try
            {
                ClientesDatos negocio = new ClientesDatos();
                Clientes encontrado = negocio.BuscarClientePorDNI(dniIngresado);

                if (encontrado != null)
                {
                    /*dni2.Text = encontrado.Documento;*/
                    /*dni.Text = encontrado.Documento;*/
                    nombre.Text = encontrado.Nombre;
                    Apellido.Text = encontrado.Apellido;
                    mail.Text = encontrado.Email;
                    direccion.Text = encontrado.Direccion;
                    ciudad.Text = encontrado.Ciudad;
                    cp.Text = encontrado.CP.ToString();
                    
                    Session["NombreUsuario"] = encontrado.Nombre;
                    Session["IdCliente"] = encontrado.Id;
                    Lblvalidacion.ForeColor = System.Drawing.Color.Green;
                    Lblvalidacion.Text = "Usuario registrado";
                    ingresoOK = true;
                    formularioRegistroCompleto.Style["display"] = "block";
                    BtnsIngresar.Style["display"] = "none";
                }
                else
                {
                    LimpiarCampos();

                    Lblvalidacion.ForeColor = System.Drawing.Color.Red;
                    Lblvalidacion.Text = "No se encontró usuario. Registrese";
                    Session["NombreUsuario"] = null;
                    ingresoOK= false;
                    formularioRegistroCompleto.Style["display"] = "none";
                    BtnsIngresar.Style["display"] = "block";
                }
            }
            catch (Exception ex)
            {
                Lblvalidacion.Text = "Error: " + ex.Message;
                throw ex;
            }
           
            ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", "mostrarFormulario();", true);
        }

        

       private void LimpiarCampos()
        {
            dni.Text = "";
            nombre.Text = "";
            Apellido.Text = "";
            mail.Text = "";
            direccion.Text = "";
            ciudad.Text = "";
            cp.Text = "";
            Lblvalidacion.Text="";
       }

       
        protected void BtnRegistro_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(dni.Text) ||
                string.IsNullOrWhiteSpace(nombre.Text) ||
                string.IsNullOrWhiteSpace(Apellido.Text) ||
                string.IsNullOrWhiteSpace(mail.Text) ||
                string.IsNullOrWhiteSpace(direccion.Text) ||
                string.IsNullOrWhiteSpace(ciudad.Text) ||
                string.IsNullOrWhiteSpace(cp.Text))
            {
                Lblvalidacion.ForeColor = System.Drawing.Color.Red;
                Lblvalidacion.Text = "Por favor, complete todos los campos antes de registrarse.";
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", "mostrarFormulario();", true);
                return; 
            }

            Clientes AgregarCliente = new Clientes();
            ClientesDatos AgregarBD = new ClientesDatos();
            try
            {
                /*AgregarCliente.Documento = dni2.Text;*/
                AgregarCliente.Documento = dni.Text;
                AgregarCliente.Nombre=nombre.Text;
                AgregarCliente.Apellido=Apellido.Text;
                AgregarCliente.Email=mail.Text;
                AgregarCliente.Direccion=direccion.Text;
                AgregarCliente.Ciudad=ciudad.Text;
                AgregarCliente.CP=int.Parse(cp.Text);

                AgregarBD.ingresarCliente(AgregarCliente);

               
                Session["NombreUsuario"] = nombre.Text;
                Session["IdCliente"] = AgregarCliente.Id;
                Lblvalidacion.ForeColor = System.Drawing.Color.Green;
                Lblvalidacion.Text = "El registro fue exitoso";
                ingresoOK = true;
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", "mostrarFormulario();", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void BtnSalir_Click(object sender, EventArgs e)
        {
            Session["NombreUsuario"] = null;
            Session["IdCliente"] = null;
            LimpiarCampos();
        }

        protected void CheckRegistrese_CheckedChanged(object sender, EventArgs e)
        {
            if(CheckRegistrese.Checked)
            {
                formularioRegistroCompleto.Style["display"] = "block";
                BtnsIngresar.Style["display"] = "none";
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", "mostrarFormulario();", true);
            }
            else
            {
                formularioRegistroCompleto.Style["display"] = "none";
                BtnsIngresar.Style["display"] = "block";
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", "mostrarFormulario();", true);
                
                LimpiarCampos();
            }
        }
    }
    
}