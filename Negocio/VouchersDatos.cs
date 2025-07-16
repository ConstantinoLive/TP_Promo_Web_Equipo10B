using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Dominio;  

namespace Negocio
{
    public class VouchersDatos
    {
        public List<Vouchers> BuscaVouchers(string CDG)
        {
            List<Vouchers> lista = new List<Vouchers>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.Consulta("SELECT CodigoVoucher, IdCliente, FechaCanje, IdArticulo FROM Vouchers where CodigoVoucher=@Codigo");
                datos.SetearParametros("@Codigo", CDG);
                datos.EjecutarConsulta();

                while (datos.Reader.Read())
                {
                    Vouchers voucherAux = new Vouchers();
                    
                    voucherAux.CodigoVoucher = datos.Reader["CodigoVoucher"] != DBNull.Value ? (string)datos.Reader["CodigoVoucher"] : string.Empty;
                    voucherAux.IdCliente = datos.Reader["IdCliente"] != DBNull.Value ? (int)datos.Reader["IdCliente"] : 0;    
                    voucherAux.FechaCanje = datos.Reader["FechaCanje"] != DBNull.Value ? (DateTime)datos.Reader["FechaCanje"] : DateTime.MinValue;
                    voucherAux.IdArticulo = datos.Reader["IdArticulo"] != DBNull.Value ? (int)datos.Reader["IdArticulo"] : 0;


                    lista.Add(voucherAux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void RegistrarVoucher(string codigo, int idCliente, int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.Consulta("UPDATE Vouchers SET IdCliente = @IdCliente, FechaCanje = @FechaCanje, IdArticulo = @IdArticulo WHERE CodigoVoucher = @Codigo");

                datos.SetearParametros("@Codigo", codigo);
                datos.SetearParametros("@IdCliente", idCliente);
                datos.SetearParametros("@FechaCanje", DateTime.Now);
                datos.SetearParametros("@IdArticulo", idArticulo);

                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

    }
}
