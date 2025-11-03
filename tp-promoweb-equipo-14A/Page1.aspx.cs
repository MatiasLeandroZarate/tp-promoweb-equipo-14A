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
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text.ToUpper();
            bool codigoExiste = CompararCodigo(codigo);
            
            try
            {
                if (codigoExiste == true)
                {
                    Voucher codUtilizado = VoucherUtilizado(codigo);

                    if (codUtilizado != null && codUtilizado.IdCliente != null)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", "alert('El código ya fue utilizado.');", true);
                        return;
                    }

                    Session.Add("CodigoVoucher", codigo);
                    Response.Redirect("Page2.aspx", false);
                }

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
                Session["error"] = ex.ToString(); 
                Session["prevPage"] = Request.Url.ToString();
                Response.Redirect("Error.aspx", false);
                Context.ApplicationInstance.CompleteRequest();

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
                Session["error"] = ex.ToString(); 
                Session["prevPage"] = Request.Url.ToString();
                Response.Redirect("Error.aspx", false);
                Context.ApplicationInstance.CompleteRequest();

                throw;
            }
            finally
            {
                acceso.cerrarConexion();
            }
        }

        public Voucher VoucherUtilizado(string CodigoVoucher)
        {
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearQuery("SELECT CodigoVoucher, IdCliente, FechaCanje, IdArticulo FROM Vouchers WHERE CodigoVoucher = @CodigoVoucher");
                datos.setearParametro("@CodigoVoucher", CodigoVoucher);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Voucher v = new Voucher();
                    v.CodigoVoucher = datos.Lector["CodigoVoucher"].ToString();
                    v.IdCliente = datos.Lector["IdCliente"] != DBNull.Value ? Convert.ToInt32(datos.Lector["IdCliente"]) : (int?)null;
                    v.FechaCanje = datos.Lector["FechaCanje"] != DBNull.Value ? (DateTime?)datos.Lector["FechaCanje"] : null;
                    v.IdArticulo = datos.Lector["IdArticulo"] != DBNull.Value ? Convert.ToInt32(datos.Lector["IdArticulo"]) : (int?)null;

                    return v;
                }
                else
                {
                    return null;
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
    }
}