using negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp4
{
    public partial class VerificacionVoucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnContinuar.CssClass = "btn btn-secondary";
            btnContinuar.Enabled = false;
        }

        protected void txtVoucher_TextChanged(object sender, EventArgs e)
        {
            VoucherNegocio negocio = new VoucherNegocio();
            try
            {
                if (negocio.verificarValidez(txtVoucher.Text))
                {
                    lblVerificacion.ForeColor = Color.Green;
                    lblVerificacion.Text = "Felicidades, prosiga a elegir su premio!";
                    btnContinuar.Text = "Continuar";
                    btnContinuar.CssClass = "btn btn-primary";
                    btnContinuar.Enabled = true;
                }
                else
                {
                    lblVerificacion.ForeColor = Color.Red;
                    lblVerificacion.Text = "Lo sentimos, el cupon no exite o ya fue usado!";
                    btnContinuar.Text = "volver al inicio";
                    btnContinuar.CssClass = "btn btn-danger";
                    btnContinuar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            string codigo;
            if (btnContinuar.Text == "Continuar") { 
                codigo = txtVoucher.Text;
                Response.Redirect("EleccionPremio.aspx?cod=" + codigo, false);
            }
            else
                Response.Redirect("Default.aspx", false);
        }
    }
}