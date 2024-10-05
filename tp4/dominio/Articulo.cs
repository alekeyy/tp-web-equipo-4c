using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class Articulo
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        public String Codigo { get; set; }
        public int IdMarca { get; set; }
        public int IdCategoria { get; set; }
        public float Precio { get; set; }
        //traer de otra tabla
        public List<Imagenes> Imagenes { get; set; }
    }
}
