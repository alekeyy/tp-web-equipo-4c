using accesoDatos;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class VoucherNegocio
    {
        private List<Voucher> listaVouchers;
        public void cargardo()
        {
            AccesoDatos datos = new AccesoDatos();
            listaVouchers = new List<Voucher>();
            try
            {
                datos.setearConsulta("SELECT CodigoVoucher, IdCliente, FechaCanje, IdArticulo FROM Vouchers");
                datos.ejecutarLectura();


                while (datos.Lector.Read())
                {
                    Voucher aux = new Voucher();
                    aux.CodVoucher = (string)datos.Lector["CodigoVoucher"];
                    if (Convert.IsDBNull(datos.Lector["IdCliente"]))
                        aux.IdCliente = 0;
                    else
                        aux.IdCliente = (int)datos.Lector["IdCliente"];
                    if (Convert.IsDBNull(datos.Lector["FechaCanje"]))
                        aux.FechaCanje = DateTime.Parse("1900-1-1");
                    else
                        aux.FechaCanje = (DateTime)datos.Lector["FechaCanje"];
                    if (Convert.IsDBNull(datos.Lector["IdArticulo"]))
                        aux.IdArticulo = 0;
                    else
                        aux.IdArticulo = (int)datos.Lector["IdArticulo"];

                    listaVouchers.Add(aux);
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

        public bool verificarValidez(string codVoucher)
        {
            if (listaVouchers == null)
            {
                cargardo();
            }
            foreach (Voucher aux in listaVouchers)
            {
                if ((aux.CodVoucher == codVoucher) && (aux.FechaCanje == DateTime.Parse("1900-1-1")))
                    return true;
            }
            return false;
        }

        public void Usar(string cod, int idCliente, int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE VOUCHERS SET IdCliente = @IdCliente, FechaCanje = @FechaHoy, IdArticulo = @IdArticulo WHERE CodigoVoucher = @CodigoVoucher");
                datos.setearParametro("@IdCliente", idCliente);
                datos.setearParametro("@FechaHoy", DateTime.Now);
                datos.setearParametro("@IdArticulo", idArticulo);
                datos.setearParametro("@CodigoVoucher", cod);
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
    }
}
