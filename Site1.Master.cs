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
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["NombreUsuario"] != null)
                {
                    nombreCliente = Session["NombreUsuario"].ToString();
                    ingresoOK = true;
                }
                else
                {
                    nombreCliente = "Ingresar";
                    ingresoOK = false;
                }

                lnkNombreCliente.Text = nombreCliente;
            }
            else
            {
                if (Session["NombreUsuario"] != null)
                {
                    lnkNombreCliente.Text = Session["NombreUsuario"].ToString();
                    ingresoOK = true;
                }
                else
                {
                    lnkNombreCliente.Text = "Ingresar";
                    ingresoOK = false;
                }
                    
            }




        }

        protected void BtnIngresarDatos_Click(object sender, EventArgs e)
        {
            string dniIngresado = dni.Text;

            if (string.IsNullOrWhiteSpace(dniIngresado) || dniIngresado.Length < 7)
            {
                Lblvalidacion.Text = "Por favor, ingrese un DNI válido.";
                Session["NombreUsuario"] = null;
            }

            try
            {
                ClientesDatos negocio = new ClientesDatos();
                Clientes encontrado = negocio.BuscarClientePorDNI(dniIngresado);

                if (encontrado != null)
                {
                    dni2.Text = encontrado.Documento;
                    nombre.Text = encontrado.Nombre;
                    Apellido.Text = encontrado.Apellido;
                    mail.Text = encontrado.Email;
                    direccion.Text = encontrado.Direccion;
                    ciudad.Text = encontrado.Ciudad;
                    cp.Text = encontrado.CP.ToString();


                    Session["NombreUsuario"] = encontrado.Nombre;
                    Lblvalidacion.Text = "Usuario registrado";
                    ingresoOK = true;
                }
                else
                {
                    LimpiarCampos();

                    Lblvalidacion.Text = "No se encontró usuario. Registrese";
                    Session["NombreUsuario"] = null;
                    ingresoOK= false;
                }
            }
            catch (Exception ex)
            {
                Lblvalidacion.Text = "Error: " + ex.Message;
                throw ex;
            }
            //DesactivarBoton();
            ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", "mostrarFormulario();", true);
        }

        

       private void LimpiarCampos()
        {
            nombre.Text = "";
            Apellido.Text = "";
            mail.Text = "";
            direccion.Text = "";
            ciudad.Text = "";
            cp.Text = "";
        }

       /* private void DesactivarBoton()
        {
            if (Session["NombreUsuario"] != null)
            {
                BtnIngresarDatos2.Enabled = false;
                BtnIngresarDatos2.CssClass = BtnIngresarDatos.CssClass.Replace("B_serch", "B_serch_desactivado");
            }
            
        }*/

        protected void BtnRegistro_Click(object sender, EventArgs e)
        {
            Clientes AgregarCliente = new Clientes();
            ClientesDatos AgregarBD = new ClientesDatos();
            try
            {
                AgregarCliente.Documento = dni2.Text;
                AgregarCliente.Nombre=nombre.Text;
                AgregarCliente.Apellido=Apellido.Text;
                AgregarCliente.Email=mail.Text;
                AgregarCliente.Direccion=direccion.Text;
                AgregarCliente.Ciudad=ciudad.Text;
                AgregarCliente.CP=int.Parse(cp.Text);

                AgregarBD.ingresarCliente(AgregarCliente);

                Session["NombreUsuario"] = nombre.Text;
                Lblvalidacion.Text = "El registro fue exitoso";
                ingresoOK = true;
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModal", "mostrarFormulario();", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    
}