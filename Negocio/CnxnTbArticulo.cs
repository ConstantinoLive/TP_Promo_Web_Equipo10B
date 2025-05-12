using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class CnxnTbArticulo
    {
        public List<Articulos> listarCodArt()
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.Consulta("select Codigo from ARTICULOS");
                datos.EjecutarConsulta();

                while(datos.Reader.Read())
                {
                    Articulos aux = new Articulos();

                    aux.CodArticulo=(string)datos.Reader["Codigo"];
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

        public List<Articulos> listarNombreArt()
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.Consulta("select nombre from ARTICULOS");
                datos.EjecutarConsulta();

                while (datos.Reader.Read())
                {
                    Articulos aux = new Articulos();

                    aux.Nombre = (string)datos.Reader["Nombre"];
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

        public void ingresar(Articulos nuevo)
        {
            AccesoDatos IngresarDatos = new AccesoDatos();
            CnxnTbImagenes CargarImagen = new CnxnTbImagenes();

            try
            {
                IngresarDatos.Consulta("INSERT INTO ARTICULOS (Codigo,Nombre,Descripcion,IdMarca,IdCategoria,Precio) VALUES ('" + nuevo.CodArticulo + "','" + nuevo.Nombre + "','" + nuevo.Descripcion + "', @IdMarca ,@IdCategoria ," + nuevo.Precio + ")");
                IngresarDatos.SetearParametros("@IdMarca", nuevo.Marca.Id);
                IngresarDatos.SetearParametros("@IdCategoria", nuevo.Categoria.Id);
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

        public void eliminarFisico(int idArticulo)
        {
            try
            {
                AccesoDatos accesoDatos = new AccesoDatos();
                accesoDatos.Consulta("DELETE FROM ARTICULOS WHERE Id = @Id");
                accesoDatos.SetearParametros("@Id", idArticulo);
                //accesoDatos.SetearParametro("@Id", idArticulo);
                accesoDatos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void modificar(Articulos Art)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.Consulta("UPDATE ARTICULOS SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, Precio = @Precio WHERE Id = @Id");
                datos.SetearParametros("@Id", Art.IdProductos);
                datos.SetearParametros("@Codigo", Art.CodArticulo);
                datos.SetearParametros("@Nombre", Art.Nombre);
                datos.SetearParametros("@Descripcion", Art.Descripcion);
                datos.SetearParametros("@IdMarca", Art.Marca.Id);
                datos.SetearParametros("@IdCategoria", Art.Categoria.Id);
                datos.SetearParametros("@Precio", Art.Precio);

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
