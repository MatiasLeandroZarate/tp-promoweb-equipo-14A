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
    public partial class Page1 : System.Web.UI.Page
    {
        Voucher codigov = new Voucher();
        public DateTime fechaActual { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //codigov.CodigoVoucher = Request.QueryString["CodigoVoucher"] != null ? Request.QueryString["CodigoVoucher"].ToString() : "Ingrese Código.";
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validacion.ValidarTxtVacio(txtCodigo))
                {
                    Session.Add("Error", "Debe ingresar un código.");
                    Response.Redirect("Error.aspx");

                }

                codigov.CodigoVoucher = txtCodigo.Text.ToUpper();
                if (CompararCodigo(codigov.CodigoVoucher))
                {

                    Session.Add("CodigoVoucher", codigov.CodigoVoucher);

                    Response.Redirect("Page2.aspx", false);

                }
                else
                {
                    Session.Add("error", "Voucher inválido");
                    Response.Redirect("Error.aspx", false);

                }
            }
            catch (System.Threading.ThreadAbortException ex)
            { }
            catch (Exception ex)
            {
                Session["error"] = ex.ToString(); // o ex.Message si preferís solo el texto
                Session["prevPage"] = Request.Url.ToString(); // guarda la URL actual
                Response.Redirect("Error.aspx", false);
                Context.ApplicationInstance.CompleteRequest();

                //Session.Add("error", ex.ToString());
                //Response.Redirect("Error.aspx");
            }
        }


        public bool CompararCodigo(string codigo)
        {
            string auxCodigo = codigo.ToUpper();
            AccesoBD acceso = new AccesoBD();

            try
            {

                acceso.setearQuery("SELECT CodigoVoucher , IdCliente FROM Vouchers WHERE CodigoVoucher = @CodigoVoucher");
                acceso.setearParametro("@CodigoVoucher", codigo);
                acceso.ejecutarLectura();

                if (acceso.Lector.Read())
                {

                    codigov.CodigoVoucher = (string)acceso.Lector["CodigoVoucher"].ToString().ToUpper();

                    if (auxCodigo == codigov.CodigoVoucher)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {

                    return false;
                }
            }
            catch (Exception ex)
            {
                Session["error"] = ex.ToString(); // o ex.Message si preferís solo el texto
                Session["prevPage"] = Request.Url.ToString(); // guarda la URL actual
                Response.Redirect("Error.aspx", false);
                Context.ApplicationInstance.CompleteRequest();

                throw;
            }
            finally
            {
                acceso.cerrarConexion();
            }
        }
    }
}