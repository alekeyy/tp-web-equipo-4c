using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace tp4
{
    public partial class Datos : System.Web.UI.Page
    {
        List<Cliente> listaClientes;
        protected void Page_Load(object sender, EventArgs e)
        {
            listaClientes = new List<Cliente>();
            ClienteNegocio negocio = new ClienteNegocio();
            listaClientes = negocio.listar();
        }

        //Ver si cambia el texto de textBoxDni y ahi en base al ingresado, buscarlo en la base de datos
        //Si existe, rellenar los demas campos con los valores ya cargado
    }
}