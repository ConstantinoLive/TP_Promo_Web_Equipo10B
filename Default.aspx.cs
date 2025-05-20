using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TP_Promo_Web_Equipo10B
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public List<Articulos>ListaArticulos {  get; set; }
        public List<Imagenes>ListarImagenes { get; set; }

      
        protected void Page_Load(object sender, EventArgs e)
        {
           
                ArticuloDatos articulos = new ArticuloDatos();
                ListaArticulos = articulos.listar();

                ImagenesDatos imagenes = new ImagenesDatos();
                ListarImagenes = imagenes.listarImagenes();

                
            
        }

        protected void BtnSaludo_Click(object sender, EventArgs e)
        {
            string nombre=TxtNombre.Text;
            LblHola.Text ="Hola"+ nombre;
        }
    }
}