using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Promo_Web_Equipo10B
{
    public partial class FormCliente : System.Web.UI.Page
    {
        public bool ingresoOK = false;

        public string nombreCliente = "Ingresar";
        protected void Page_Load(object sender, EventArgs e)
        {
            Lblvalidacion.Text = "Hola mundo";
        }

        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            string dniIngresado = dni.Text.Trim();
            try
            {
                /*Clientes encontrado = ListarClientes.FirstOrDefault(x => x.Documento == dniIngresado);*/
                ClientesDatos negocio = new ClientesDatos();
                Clientes encontrado = negocio.BuscarClientePorDNI(dniIngresado);

                if (encontrado != null)
                {
                    nombre.Text = encontrado.Nombre;
                    Apellido.Text = encontrado.Apellido;
                    mail.Text = encontrado.Email;
                    direccion.Text = encontrado.Direccion;
                    ciudad.Text = encontrado.Ciudad;
                    cp.Text = encontrado.CP.ToString();

                    /*nombre.Enabled=true;
                    Apellido.Enabled = true;
                    mail.Enabled = true;
                    direccion.Enabled = true;
                    ciudad.Enabled = true;
                    cp.Enabled = true;

                    ingresoOK =true;*/
                    nombreCliente = encontrado.Nombre;
                    Lblvalidacion.Text = "Usuario registrado";

                   

                    /*ScriptManager.RegisterStartupScript(this, GetType(), "abrirModal", "mostrarFormulario();", true);*/

                }
                else
                {
                    nombre.Text = "";
                    Apellido.Text = "";
                    mail.Text = "";
                    direccion.Text = "";
                    ciudad.Text = "";
                    cp.Text = "";
                    /* ingresoOK=false;

                     nombre.Enabled = false;
                     Apellido.Enabled = false;
                     mail.Enabled = false;
                     direccion.Enabled = false;
                     ciudad.Enabled = false;
                     cp.Enabled = false;*/

                    Lblvalidacion.Text = "No se encontró usuario. Registrese";
                   

                    /*ScriptManager.RegisterStartupScript(this, GetType(), "abrirModal", "mostrarFormulario();", true);*/

                }
            }
            catch (Exception ex)
            {
                Lblvalidacion.Text = "Error: " + ex.Message;
                
            }
        }
    }
}