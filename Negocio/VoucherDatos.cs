using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class VoucherDatos
    {
        public List<Vouchers> listarVouchers()
        {
            List<Vouchers> lista = new List<Vouchers>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.Consulta("select CodigoVoucher, IdClinete, FechaCanje, IdArticulo from VOUCHERS");
                datos.EjecutarConsulta();

                while (datos.Reader.Read())
                {
                    Vouchers aux = new Vouchers();

                    aux.CodigoVoucher = (string)datos.Reader["CodigoVoucher"];
                    aux.IdCliente = (int)datos.Reader["IdClinete"];
                    aux.FechaCanje = (DateTime)datos.Reader["fechaCanje"];
                    aux.IdArticulo = (int)datos.Reader["IdArticulo"];
                    
                    lista.Add(aux);
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

        public Vouchers CheckearVoucherCanjeadoXCliente(int IdCliente)
        {
            Vouchers vouchers = null;
            AccesoDatos datos=new AccesoDatos();

            try
            {
                datos.Consulta("select CodigoVoucher, IdCliente, FechaCanje, IdArticulo from Vouchers where IdCliente=@Cliente");
                datos.SetearParametros("@Cliente", IdCliente);
                datos.EjecutarConsulta();
                if (datos.Reader.Read())
                {
                    vouchers = new Vouchers
                    {
                        CodigoVoucher = (string)datos.Reader["CodigoVoucher"],
                        IdCliente = (int)datos.Reader["IdCliente"],
                        FechaCanje = (DateTime)datos.Reader["FechaCanje"],
                        IdArticulo = (int)datos.Reader["IdArticulo"],
                       
                    };
                }
        
            }
            catch (Exception ex) 
            { 
                throw ex; 
            }
            finally
            {  
                datos.CerrarConexion();
            }
            return vouchers;
        }

        public void CanjearVoucher(string codigo, int idCliente, int IdArticulo)
        {
            AccesoDatos IngresarDatos = new AccesoDatos();

            try
            {
                IngresarDatos.Consulta("UPDATE Vouchers SET IdCliente = @IdCliente, IdArticulo = @IdArticulo, FechaCanje = @FechaCanje WHERE CodigoVoucher = @CodigoVoucher");

                IngresarDatos.SetearParametros("@IdCliente", idCliente);
                IngresarDatos.SetearParametros("@IdArticulo", IdArticulo);
                IngresarDatos.SetearParametros("@FechaCanje", DateTime.Today);
                IngresarDatos.SetearParametros("@CodigoVoucher", codigo);

                IngresarDatos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                IngresarDatos.CerrarConexion();
            }

        }

        public Vouchers BuscarVoucherPorCodigo(string codigo)
        {
            AccesoDatos datos = new AccesoDatos();
            Vouchers voucher = null;

            try
            {
                datos.Consulta("SELECT CodigoVoucher, IdCliente, FechaCanje,IdArticulo FROM Vouchers WHERE CodigoVoucher = @CodigoVoucher");
                datos.SetearParametros("@CodigoVoucher", codigo);
                datos.EjecutarConsulta();

                if (datos.Reader.Read())
                {
                    voucher = new Vouchers
                    {
                        CodigoVoucher = datos.Reader["CodigoVoucher"].ToString(),
                        IdCliente = datos.Reader["IdCliente"] != DBNull.Value ? (int)datos.Reader["IdCliente"] : (int?)null,
                        FechaCanje = datos.Reader["FechaCanje"] != DBNull.Value ? (DateTime)datos.Reader["FechaCanje"] : (DateTime?)null,
                        IdArticulo = datos.Reader["IdArticulo"] != DBNull.Value ? (int)datos.Reader["IdArticulo"] : (int?)null
                    };
                }

                return voucher;
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
