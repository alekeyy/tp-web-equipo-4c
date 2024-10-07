using accesoDatos;
using dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> listar(string dni = "")
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP FROM CLIENTES");
                if(dni != "")
                {
                    datos.setearConsulta("SELECT Id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP FROM CLIENTES WHERE Documento = @Documento");
                    datos.setearParametro("@Documento", dni);
                }
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Documento = (string)datos.Lector["Documento"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.Direccion = (string)datos.Lector["Direccion"];
                    aux.Ciudad = (string)datos.Lector["Ciudad"];
                    aux.CP = (int)datos.Lector["CP"];

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
                datos.cerrarConexion();
            }
        }

        public void Agregar(Cliente nuevo)
        {

            AccesoDatos datos = new AccesoDatos();
           
            try
            {
                datos.setearConsulta(" INSERT INTO CLIENTES(Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP) Values(@Documento, @Nombre, @Apellido, @Email, @Direccion, @Ciudad, @CP);");
                datos.setearParametro("@Documento", nuevo.Documento);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Apellido", nuevo.Apellido);
                datos.setearParametro("@Email", nuevo.Email);
                datos.setearParametro("@Direccion", nuevo.Direccion);
                datos.setearParametro("@Ciudad", nuevo.Ciudad);
                datos.setearParametro("@CP", nuevo.CP);
                datos.ejecutarAccion();
            } 
            catch (Exception ex)
            {
                throw ex;
            } 
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void Modificar(Cliente modificar)
        {

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE CLIENTES SET Documento = @Documento, Nombre = @Nombre, Apellido = @Apellido, Email = @Email, Direccion = @Direccion, Ciudad = @Ciudad, CP = @CP WHERE ID = @Id;");
                datos.setearParametro("@Documento", modificar.Documento);
                datos.setearParametro("@Nombre", modificar.Nombre);
                datos.setearParametro("@Apellido", modificar.Apellido);
                datos.setearParametro("@Email", modificar.Email);
                datos.setearParametro("@Direccion", modificar.Direccion);
                datos.setearParametro("@Ciudad", modificar.Ciudad);
                datos.setearParametro("@CP", modificar.CP);
                datos.setearParametro("@ID", modificar.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool Buscar(string dni)
        {

            AccesoDatos datos = new AccesoDatos();

            try
            {
                //Creo un cliente auxiliar y le asigno el valor de ID 0, luego lo busco en la base de datos filtrando por su documento. Una vez que se realiza la consulta, de haber un resultado este se guardara en el Id del cliente auxiliar.
                Cliente aux = new Cliente();
                aux.Id = 0;

                datos.setearConsulta("SELECT Id FROM CLIENTES WHERE Documento = @Documento");

                datos.setearParametro("@Documento", dni);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    aux.Id = (int)datos.Lector["Id"];
                }

                //Si el cliente auxiliar tiene un Id asignado distinto de cero, significa que existe en la base de datos y por ende returno true
                if (aux.Id != 0)
                {
                    return true;
                } else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int DevolverId(string dni)
        {

            AccesoDatos datos = new AccesoDatos();

            try
            {
                Cliente aux = new Cliente();
                aux.Id = 0;

                datos.setearConsulta("SELECT Id FROM CLIENTES WHERE Documento = @Documento");

                datos.setearParametro("@Documento", dni);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    aux.Id = (int)datos.Lector["Id"];
                }

                return aux.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
