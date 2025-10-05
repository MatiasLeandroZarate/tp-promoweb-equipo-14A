using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization.Configuration;
using Dominio;

namespace Negocio
{
    public class VoucherNegocio
    {

        public void ListarVOU(Voucher voucher)
        {
            List<Voucher> lista = new List<Voucher>();

            AccesoBD datos = new AccesoBD();
            try
            {
                datos.setearStoreProcedure("storeListarVOU");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Voucher aux = new Voucher();

                    aux.CodigoVoucher = (string)datos.Lector["CodigoVoucher"];
                    aux.IdCliente = (int)datos.Lector["IdCliente"];
                    aux.FechaCanje = (DateTime)datos.Lector["FechaCanje"];
                    aux.IdArticulo = (int)datos.Lector["IdArticulo"];

                    lista.Add(aux);
                }
                datos.cerrarLector();
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
