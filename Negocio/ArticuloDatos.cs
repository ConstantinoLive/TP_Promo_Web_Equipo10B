using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
//using System.Windows.Forms;
using Dominio;




namespace Negocio
{
    public class ArticuloDatos
    {
        public List<Articulos> listar()
        {
            List<Articulos> lista = new List<Articulos>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server = .\\SQLEXPRESS; database = PROMOS_DB; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                //comando.CommandText = "select A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion Marca,C.Descripcion Categoria,Precio, I.ImagenUrl from ARTICULOS A, MARCAS M, CATEGORIAS C, IMAGENES I where M.Id=A.IdMarca and C.Id=A.IdCategoria and I.Id = A.Id";
                //comando.CommandText = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, A.Precio, I.ImagenUrl FROM ARTICULOS A LEFT JOIN MARCAS M ON M.Id = A.IdMarca LEFT JOIN CATEGORIAS C ON C.Id = A.IdCategoria LEFT JOIN IMAGENES I ON I.IdArticulo = A.Id";
                comando.CommandText = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, A.Precio, \r\n       (SELECT TOP 1 ImagenUrl FROM IMAGENES I WHERE I.IdArticulo = A.Id) AS ImagenUrl\r\nFROM ARTICULOS A\r\nLEFT JOIN MARCAS M ON M.Id = A.IdMarca\r\nLEFT JOIN CATEGORIAS C ON C.Id = A.IdCategoria";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.IdProductos = lector["Id"] != DBNull.Value ? Convert.ToInt32(lector["Id"]) : 0;
                    aux.CodArticulo = lector["Codigo"] != DBNull.Value ? lector["Codigo"].ToString() : string.Empty;
                    aux.Nombre = lector["Nombre"] != DBNull.Value ? lector["Nombre"].ToString() : string.Empty;
                    aux.Descripcion = lector["Descripcion"] != DBNull.Value ? lector["Descripcion"].ToString() : string.Empty;
                    aux.Marca=new Marcas();
                    aux.Marca.Marca = lector["Marca"] != DBNull.Value ? lector["Marca"].ToString() : string.Empty;
                    aux.Categoria= new Categorias();
                    aux.Categoria.Categoria = lector["Categoria"] != DBNull.Value ? lector["Categoria"].ToString() : string.Empty;
                    aux.Precio = lector["Precio"] != DBNull.Value ? Convert.ToDouble(lector["Precio"]) : 0.0;
                    
                     
                    lista.Add(aux);
                }

                conexion.Close();

                return lista;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al cargar la base de datos");
                throw ex;
              
            }

        }

       
    }
}
