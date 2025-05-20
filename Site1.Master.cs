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

        public string nombreCliente="Ingresar";
        protected void Page_Load(object sender, EventArgs e)
        {
            lnkNombreCliente.Text = nombreCliente;
           
        }

        /*protected void BtnIngresarDatos_Click(object sender, EventArgs e)
        {
            string dniIngresado = dni.Text;
           
            if (string.IsNullOrWhiteSpace(dniIngresado) || dniIngresado.Length < 7)
            {
                Lblvalidacion.Text = "Por favor, ingrese un DNI válido.";

            }

            try
            {
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


                    nombreCliente = encontrado.Nombre;
                    Lblvalidacion.Text = "Usuario registrado";

                }
                else
                {
                    LimpiarCampos();

                    Lblvalidacion.Text = "No se encontró usuario. Registrese";

                }
            }
            catch (Exception ex)
            {
                Lblvalidacion.Text = "Error: " + ex.Message;
                throw ex;
            }
        }

       private void LimpiarCampos()
        {
            nombre.Text = "";
            Apellido.Text = "";
            mail.Text = "";
            direccion.Text = "";
            ciudad.Text = "";
            cp.Text = "";
        }*/

       
    }
    
}