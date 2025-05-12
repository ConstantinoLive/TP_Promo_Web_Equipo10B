using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CategoriaDatos
    {
        public List<Categorias> listarCategorias()
        {
            List<Categorias> lista = new List<Categorias>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.Consulta("select Id, Descripcion from CATEGORIAS");
                datos.EjecutarConsulta();

                while (datos.Reader.Read())
                {
                    Categorias aux = new Categorias();

                    aux.Id = (int)datos.Reader["Id"];
                    aux.Categoria = (string)datos.Reader["Descripcion"];
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
