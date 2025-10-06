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
    {   public string codigo {  get; set; }
        public DateTime fechaActual {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            codigo = Request.QueryString["CodigoVoucher"] != null ? Request.QueryString["CodigoVoucher"].ToString() : "Ingrese Código.";
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
             codigo = txtCodigo.Text.ToUpper();
            bool codigoExiste = CompararCodigo(codigo);
            if (codigoExiste == true)
            {
                

                Session.Add("CodigoVoucher", codigo);
               
                Response.Redirect("Page2.aspx",false);
                
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
                    
                    return true;
                }
                else
                {
                    
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