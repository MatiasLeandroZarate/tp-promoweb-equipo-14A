using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_promoweb_equipo_14A
{
    public partial class Page11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            string Codigo = txtCodigo.Text.ToUpper();
            bool codigoExiste = CompararCodigo(Codigo);
            if (codigoExiste == true)
            {
                Response.Redirect("Page2.aspx");
            }
            else
            {
                string mensaje = "El codigo no existe";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", $"alert('{mensaje}');", true);
              
            }
           
        }


        public bool CompararCodigo(string codigo)
        {
            AccesoBD acceso = new AccesoBD();
            try
            {   

                acceso.setearQuery("SELECT CodigoVoucher FROM Vouchers WHERE CodigoVoucher = @CodigoVoucher");
                acceso.setearParametro("@CodigoVoucher", codigo);
                acceso.ejecutarLectura();
                if (acceso.Lector.Read())
                {
                    // El código ya existe en la base de datos
                    return true;
                }
                else
                {
                    // El código no existe en la base de datos
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                acceso.cerrarConexion();
            }
        }
        }
}