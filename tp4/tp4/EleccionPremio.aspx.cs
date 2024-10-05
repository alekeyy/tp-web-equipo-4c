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
    public partial class EleccionPremio : System.Web.UI.Page
    {
        public List<Articulo> listaArticulo {  get; set; }
        public string codigo;
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulo = negocio.listar();
            codigo = Request.QueryString["cod"];
            if (!IsPostBack)
            {
                repRepetidor.DataSource = listaArticulo;
                repRepetidor.DataBind();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(((Button)sender).CommandArgument);

            Response.Redirect("Datos.aspx?cod=" + codigo + "&id=" + id, false);
        }
    }
}