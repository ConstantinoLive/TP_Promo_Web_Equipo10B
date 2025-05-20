using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ClientesDatos
    {
        public List<Clientes> ListarClientes()
        { 
            List<Clientes>lista = new List<Clientes>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.Consulta("select Id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP from Clientes");
                datos.EjecutarConsulta();

                while(datos.Reader.Read())
                {
                    Clientes clientesAux = new Clientes();
                    
                    clientesAux.Id=(int)datos.Reader["Id"];
                    clientesAux.Documento = (string)datos.Reader["Documento"];
                    clientesAux.Nombre = (string)datos.Reader["Nombre"];
                    clientesAux.Apellido = (string)datos.Reader["Apellido"];
                    clientesAux.Email = (string)datos.Reader["Email"];
                    clientesAux.Direccion = (string)datos.Reader["Direccion"];
                    clientesAux.Ciudad = (string)datos.Reader["Ciudad"];
                    clientesAux.CP = (int)datos.Reader["CP"];

                    lista.Add(clientesAux);
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

        public void ingresarCliente(Clientes nuevo)
        {
            AccesoDatos IngresarDatos = new AccesoDatos();
            
            try
            {
                IngresarDatos.Consulta("INSERT INTO Clientes (Documento,Nombre,Apellido,Email,Direccion,Ciudad, CP) VALUES (@Documento,@Nombre,@Apellido,@Email,@Direccion,@Ciudad,@CP)");
                IngresarDatos.SetearParametros("@Documento", nuevo.Documento);
                IngresarDatos.SetearParametros("@Nombre", nuevo.Nombre);
                IngresarDatos.SetearParametros("@Apellido", nuevo.Apellido);
                IngresarDatos.SetearParametros("@Email", nuevo.Email);
                IngresarDatos.SetearParametros("@Direccion", nuevo.Direccion);
                IngresarDatos.SetearParametros("@Ciudad", nuevo.Ciudad);
                IngresarDatos.SetearParametros("@CP", nuevo.CP);


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

        public Clientes BuscarClientePorDNI(string dni)
        {
            Clientes cliente = null;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.Consulta("SELECT Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP FROM Clientes WHERE Documento = @DNI");
                datos.SetearParametros("@DNI", dni);
                datos.EjecutarConsulta();

                if (datos.Reader.Read())
                {
                    cliente = new Clientes
                    {
                        Documento = (string)datos.Reader["Documento"],
                        Nombre = (string)datos.Reader["Nombre"],
                        Apellido = (string)datos.Reader["Apellido"],
                        Email = (string)datos.Reader["Email"],
                        Direccion = (string)datos.Reader["Direccion"],
                        Ciudad = (string)datos.Reader["Ciudad"],
                        CP = (int)datos.Reader["CP"]
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

            return cliente;
        }

        


    }
}
