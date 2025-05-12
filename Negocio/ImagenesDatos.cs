using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ImagenesDatos
    {
        public List<Imagenes> listarImagenes()
        {
            List<Imagenes> lista = new List<Imagenes>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.Consulta("select Id, IdArticulo, ImagenUrl from IMAGENES");
                datos.EjecutarConsulta();

                while (datos.Reader.Read())
                {
                    Imagenes aux = new Imagenes();

                    aux.Id = (int)datos.Reader["Id"];
                    aux.IdArticulo = (int)datos.Reader["IdArticulo"];
                    aux.ImagenUrl = (string)datos.Reader["ImagenUrl"]; 
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
