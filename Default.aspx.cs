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

        public bool canje=false;

        protected void Page_Load(object sender, EventArgs e)
        {
           
                ArticuloDatos articulos = new ArticuloDatos();
                ListaArticulos = articulos.listar();

                ImagenesDatos imagenes = new ImagenesDatos();
                ListarImagenes = imagenes.listarImagenes();
            
            if(IsPostBack)
            {
                canje = false;
            }
        }

        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            string codigoIngresado = TxbCodigo.Text.Trim();
            int idArticulo;
            int idCliente = Convert.ToInt32(Session["IdCliente"]);

            if (!int.TryParse(hfIdArticulo.Value, out idArticulo))
            {
                LblAlertaVoucher.Text = "Error interno: artículo no identificado.";
                LblAlertaVoucher.ForeColor = System.Drawing.Color.Red;
                LblAlertaVoucher.Visible = true;
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModalVoucher", $"mostrarFormVoucher({hfIdArticulo.Value})", true);
                return;
            }
           
            if (Session["IdCliente"] == null)
            {
                LblAlertaVoucher.Text = "Debe registrarse o iniciar sesión para canjear un voucher.";
                LblAlertaVoucher.ForeColor = System.Drawing.Color.Red;
                LblAlertaVoucher.Visible = true;
                ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModalVoucher", $"mostrarFormVoucher({hfIdArticulo.Value})", true);
                return;
            }
            if (string.IsNullOrEmpty(codigoIngresado))
            {
                LblAlertaVoucher.Text = "Debe ingresar un código válido.";
                LblAlertaVoucher.ForeColor = System.Drawing.Color.Red;
                LblAlertaVoucher.Visible = true;
                return;
            }
           
            VouchersDatos datos = new VouchersDatos();
            var resultado = datos.BuscaVouchers(codigoIngresado).FirstOrDefault(x=>x.CodigoVoucher==codigoIngresado);

            try
            {
                             
                if (resultado == null)
                {
                    LblAlertaVoucher.Text = "El código ingresado no existe.";
                    LblAlertaVoucher.ForeColor = System.Drawing.Color.Red;
                    LblAlertaVoucher.Visible = true;
                    TxbCodigo.Text = string.Empty;
                    ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModalVoucher", $"mostrarFormVoucher({hfIdArticulo.Value})", true);
                    return;
                }

                if (resultado.IdCliente != 0)
                {
                    LblAlertaVoucher.Text = "El código ingresado ya fue utilizado.";
                    LblAlertaVoucher.ForeColor = System.Drawing.Color.Red;
                    LblAlertaVoucher.Visible = true;
                    TxbCodigo.Text = string.Empty;
                    ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModalVoucher", $"mostrarFormVoucher({hfIdArticulo.Value})", true);
                    return;
                }
                if (resultado.IdCliente == 0)
                {
                    VouchersDatos VoucherCanje = new VouchersDatos();
                    VoucherCanje.RegistrarVoucher(codigoIngresado, idCliente, idArticulo);

                    LblAlertaVoucher.Text = "¡Felicitaciones! El premio es tuyo.";
                    LblAlertaVoucher.ForeColor = System.Drawing.Color.Green;
                    LblAlertaVoucher.Visible = true;
                    canje = true;
                    ScriptManager.RegisterStartupScript(this, GetType(), "MostrarModalVoucher", $"mostrarFormVoucher({hfIdArticulo.Value})", true);

                    return;
                }
                
            }
            catch(Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error: {ex.Message}');", true);
                return;
            }
            
        }

        protected void BtnCerrar_Click(object sender, EventArgs e)
        {
            LblAlertaVoucher.Visible = false;
            canje = false;
        }
    }
}