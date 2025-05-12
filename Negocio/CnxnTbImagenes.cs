using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CnxnTbImagenes
    {
        public List<Imagenes> listarImagenes()
        {
            List<Imagenes> lista = new List<Imagenes>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.Consulta("select ImagenUrl from IMAGENES");
                datos.EjecutarConsulta();

                while (datos.Reader.Read())
                {
                    Imagenes aux = new Imagenes();

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

        public void eliminarFisico(int idArticulo)
        {
            try
            {
                AccesoDatos accesoDatos = new AccesoDatos();
                accesoDatos.Consulta("DELETE FROM IMAGENES WHERE IdArticulo = @IdArticulo");
                accesoDatos.SetearParametros("@IdArticulo", idArticulo);
                accesoDatos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ingresarUrl(string nuevo, int url)
        {
            AccesoDatos IngresarDatos = new AccesoDatos();

            try
            {
                IngresarDatos.Consulta("INSERT INTO IMAGENES (IdArticulo,ImagenUrl) VALUES (@IdArticulos,@ImagenUrl)");
                IngresarDatos.SetearParametros("@IdArticulos", url);
                IngresarDatos.SetearParametros("@ImagenUrl", nuevo);
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

    }
}
