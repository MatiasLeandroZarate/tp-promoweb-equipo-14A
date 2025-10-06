using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Negocio
{
    public class ClienteNegocio
    {
        List<Cliente> lista = new List<Cliente>();

        public void agregar(Cliente nuevo)
        {
            AccesoBD datos = new AccesoBD();
            try
            {
 
                datos.setearStoreProcedure("storeAltaCliente");
                datos.setearParametro("@Documento",nuevo.DNI);
                datos.setearParametro("@Nombre ", nuevo.Nombre);
                datos.setearParametro("@Apellido" ,nuevo.Apellido);
                datos.setearParametro("@Email",nuevo.Email);
                datos.setearParametro("@Direccion",nuevo.Direccion);
                datos.setearParametro("@Ciudad",nuevo.Ciudad);
                datos.setearParametro("@CP" ,nuevo.CP);
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

        public void CompararDNI()
        {

        }

       

    }
}
