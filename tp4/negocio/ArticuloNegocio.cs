using accesoDatos;
using dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            //lista de las imagenes cargadas
            ImagenesNegocio negocio = new ImagenesNegocio();
            List<Imagenes> listaImagenes = new List<Imagenes>(); 
            //aca se va a inicializar negocio imagenes para poder cargar la lista de imagenes
            //listaImagenes = negocio.listar();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, A.IdCategoria, A.Precio FROM ARTICULOS A");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    //listaImagenes cargar va a comparar el parametro pasado y devolver todos los objetos de la lista que coincidan con ese id
                    aux.Imagenes = negocio.buscar(aux.Id);
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    //aux.Tipo = new Elemento();
                    //aux.Tipo.Id = (int)datos.Lector["IdTipo"];
                    //aux.Tipo.Descripcion = (string)datos.Lector["Tipo"];
                    //aux.Debilidad = new Elemento();
                    //aux.Debilidad.Id = (int)datos.Lector["IdDebilidad"];
                    //aux.Debilidad.Descripcion = (string)datos.Lector["Debilidad"];
                    
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
    }
}
