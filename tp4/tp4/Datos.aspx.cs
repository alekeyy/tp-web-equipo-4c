﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
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
            if (soloNumeros((string)textBoxDni.Text))
            {
                lblSoloNumerosDNI.Text = "El campo solo admite numeros";
                lblSoloNumerosDNI.ForeColor = Color.Red;
            }
            else
            {
                lblSoloNumerosDNI.Text = "";
                lblSoloNumerosDNI.ForeColor = Color.White;
            }
            if (string.IsNullOrWhiteSpace(textBoxDni.Text))
            {
                lblDni.ForeColor = Color.Red;
                lblApellido.ForeColor = Color.Red;
                lblCiudad.ForeColor = Color.Red;
                lblCP.ForeColor = Color.Red;
                lblDireccion.ForeColor = Color.Red;
                lblDni.ForeColor = Color.Red;
                lblEmail.ForeColor = Color.Red;
                lblNombre.ForeColor = Color.Red;
                lblDni.ForeColor = Color.Red;
                lblTermsCond.ForeColor = Color.Red;
            }
            else
            {
                Cliente seleccionado = new Cliente();
                ClienteNegocio negocio = new ClienteNegocio();
                string dni = textBoxDni.Text;
                listaClientes = negocio.listar(dni);
                if (listaClientes.Count != 0)
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
        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!(textBoxApellido.Text == "" || textBoxCiudad.Text == "" || textBoxCodigoPostal.Text == "" || textBoxDireccion.Text == "" || textBoxDni.Text == "" || textBoxEmail.Text == "" || textBoxNombre.Text == ""))
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
                }
                else
                {
                    negocio.Agregar(nuevo);
                }

                //buscamos el id del cliente
                listaClientes = negocio.listar(nuevo.Documento);
                idCliente = listaClientes[0].Id;

                //Modificamos el registro del voucher
                voucherRegistro.Usar(codigo, idCliente, idArticulo);
                Response.Redirect("exito.aspx");
                //Ver si cambia el texto de textBoxDni y ahi en base al ingresado, buscarlo en la base de datos
                //Si existe, rellenar los demas campos con los valores ya cargado
            }
            else
            {
                lblAnuncio.Text = "(TODOS LOS CAMPOS EN ROJO SON OBLIGATORIOS)";
                lblAnuncio.ForeColor = Color.Red;
                lblDni.ForeColor = Color.Red;
                lblApellido.ForeColor = Color.Red;
                lblCiudad.ForeColor = Color.Red;
                lblCP.ForeColor = Color.Red;
                lblDireccion.ForeColor = Color.Red;
                lblDni.ForeColor = Color.Red;
                lblEmail.ForeColor = Color.Red;
                lblNombre.ForeColor = Color.Red;
                lblDni.ForeColor = Color.Red;
                lblTermsCond.ForeColor = Color.Red;
            }
        }

        public bool soloNumeros(string cadena)
        {
            foreach(char caracter in cadena)
            {
                if (!(char.IsNumber(caracter)))
                    return true;
            }
            return false;
        }
        public bool formatoEmail(string cadena)
        {
            if(!(cadena.Contains("@")))
                return true;
            else
                return false;
        }


        protected void textBoxCodigoPostal_TextChanged(object sender, EventArgs e)
        {
            if (soloNumeros((string)textBoxCodigoPostal.Text))
            {
                lblSoloNumerosCP.Text = "El campo solo admite numeros";
                lblSoloNumerosCP.ForeColor = Color.Red;
            }
            else
            {
                lblSoloNumerosCP.Text = "";
                lblSoloNumerosCP.ForeColor = Color.White;
            }
        }

        protected void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            if(formatoEmail((string)textBoxEmail.Text))
            {
                lblFormatoMail.Text = "El campo requiere el ingreso de mail";
                lblFormatoMail.ForeColor = Color.Red;
            }
            else
            {
                lblFormatoMail.Text = "";
                lblFormatoMail.ForeColor = Color.White;
            }

        }
    }
}