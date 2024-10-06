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
        }

        protected void textBoxDni_TextChanged(object sender, EventArgs e)
        {
            Cliente seleccionado = new Cliente();
            ClienteNegocio negocio = new ClienteNegocio();
            string dni = textBoxDni.Text;
            listaClientes = negocio.listar(dni);
            if(listaClientes.Count != 0)
            {
                seleccionado = listaClientes[0];
                if (!(seleccionado.Documento is DBNull))
                {
                    textBoxNombre.Text = seleccionado.Nombre;
                    textBoxApellido.Text = seleccionado.Apellido;
                    textBoxEmail.Text = seleccionado.Email;
                    textBoxCiudad.Text = seleccionado.Ciudad;
                    textBoxDireccion.Text = seleccionado.Direccion;
                    textBoxCodigoPostal.Text = seleccionado.CP.ToString();
                }
            }

        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            VoucherNegocio voucherRegistro = new VoucherNegocio();
            Voucher voucher = new Voucher();
            string codigo = Request.QueryString["cod"];
            int idArticulo = int.Parse(Request.QueryString["id"]);

            List<Cliente> listaClientes = new List<Cliente>();
            ClienteNegocio negocio = new ClienteNegocio();
            Cliente nuevo = new Cliente();
            int idCliente;

            //Cargamos los datos del formulario al cliente
            nuevo.Documento = textBoxDni.Text;
            nuevo.Nombre = textBoxNombre.Text;
            nuevo.Apellido = textBoxApellido.Text;
            nuevo.Email = textBoxEmail.Text;
            nuevo.Ciudad = textBoxCiudad.Text;
            nuevo.Direccion = textBoxDireccion.Text;
            nuevo.CP = int.Parse(textBoxCodigoPostal.Text);

            //Agregamos el cliente o modificamos en caso de que ya exista
            //busco con .buscar si existe el documento en la bd, en caso de serlo que devuelva true
            bool existe = negocio.Buscar(nuevo.Documento);
            if (existe)
            {
                //Ya existe en la db, lo que hago es ir a buscar el valor con el metodo devolver id y asi poder asignarlo al cliente "Nuevo" para poder modificarlo(esto requiere id)
                nuevo.Id = negocio.DevolverId(nuevo.Documento);
                negocio.Modificar(nuevo);
            } else
            {
                negocio.Agregar(nuevo);
            }

            //buscamos el id del cliente
            listaClientes = negocio.listar(nuevo.Documento);
            idCliente = listaClientes[0].Id;

            //Modificamos el registro del voucher
            voucherRegistro.Usar(codigo, idCliente, idArticulo);
            Response.Redirect("VerificacionVoucher.aspx");
        }

        //Ver si cambia el texto de textBoxDni y ahi en base al ingresado, buscarlo en la base de datos
        //Si existe, rellenar los demas campos con los valores ya cargado
    }
}