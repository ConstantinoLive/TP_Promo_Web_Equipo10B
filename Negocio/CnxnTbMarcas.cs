using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CnxnTbMarcas
    {
        public List<Marcas> listarMarca()
        {
            List<Marcas> lista = new List<Marcas>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.Consulta("select Descripcion from MARCAS");
                datos.EjecutarConsulta();

                while (datos.Reader.Read())
                {
                    Marcas aux = new Marcas();

                    aux.Marca = (string)datos.Reader["Descripcion"];
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

        
    }
    
}
