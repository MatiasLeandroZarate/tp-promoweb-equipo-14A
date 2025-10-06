using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace tp_promoweb_equipo_14A
{
    public partial class Page3 : System.Web.UI.Page
    {
        string dnicliente;
        protected void Page_Load(object sender, EventArgs e)
        {

            dnicliente = (string)txtDNI.Text.ToString();
            Clienteencontrado(dnicliente);

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            Cliente nuevo = new Cliente();
            ClienteNegocio negocio = new ClienteNegocio();
            VoucherNegocio voucher = new VoucherNegocio();
            try
            {
                

                if (txtDNI.Text != "" && txtNombre.Text != "" && txtApellido.Text != "" && txtEmail.Text != "" && txtDireccion.Text != "" && txtCiudad.Text != "" && txtCP.Text != "")
                {
                    if (chkTerminos.Checked == true)
                    {
                        nuevo.DNI = (string)txtDNI.Text;
                        nuevo.Nombre = (string)txtNombre.Text;
                        nuevo.Apellido = (string)txtApellido.Text;
                        nuevo.Email = (string)txtEmail.Text;
                        nuevo.Direccion = (string)txtDireccion.Text;
                        nuevo.Ciudad = (string)txtCiudad.Text;
                        nuevo.CP = (string)txtCP.Text;

                        negocio.agregar(nuevo);

                        string OKA = "Cliente Ingresado";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", $"alert('{OKA}');", true);

                        Response.Redirect("Page1.aspx", false);
                    }
                    else
                    {
                        string mensaje = "Acepte los Terminos y Condiciones.";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", $"alert('{mensaje}');", true);

                    }


                }
                else
                {
                    string mensaje = "Por favor, complete todos los campos.";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", $"alert('{mensaje}');", true);

                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
            string OK = "Cliente Ingresado";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alerta", $"alert('{OK}');", true);
            //agregarVou();
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {

            Response.Redirect("Page2.aspx");
        }

        public void Clienteencontrado(string Dni)
        {
            AccesoBD datos = new AccesoBD();
            try
            {
                datos.setearQuery("SELECT Id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP FROM Clientes WHERE Documento = @DNI");
                datos.setearParametro("@DNI", Dni);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    txtDNI.Text = (string)datos.Lector["Documento"].ToString();
                    txtNombre.Text = (string)datos.Lector["Nombre"];
                    txtApellido.Text = (string)datos.Lector["Apellido"];
                    txtEmail.Text = (string)datos.Lector["Email"];
                    txtDireccion.Text = (string)datos.Lector["Direccion"];
                    txtCiudad.Text = (string)datos.Lector["Ciudad"];
                    txtCP.Text = (string)datos.Lector["CP"].ToString();

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
        //public void agregarVou()
        //{
        //    AccesoBD datos = new AccesoBD();
        //    DateTime fechaActual;
        //    int IdCliente, IdArticulo;
        //    string dni = (string)txtDNI.Text;

        //        string codigovoucher = Session["CodigoVoucher"].ToString();
        //        fechaActual = DateTime.Now;
        //        IdArticulo = (int)Session["IdArticulo"];
        //            //Falta Corregir la toma de IdARTICULO.
        //    try
        //    {

        //        datos.setearQuery("SELECT id from Clientes where Documento = @Documento");
        //        datos.setearParametro("@Documento", dni);
        //        if (datos.Lector.Read())
        //        {
        //            IdCliente = (int)datos.Lector["id"];
        //        }

        //        datos.setearStoreProcedure("storeAltaVoucher");
        //        datos.setearParametro("@CodigoVoucher", codigovoucher);
        //        datos.setearParametro("@FechaCanje", fechaActual);
        //        datos.setearParametro("@IdArticulo", IdArticulo);
                
        //        datos.ejecutarAccion();


        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //    finally
        //    { datos.cerrarConexion(); }

        //}
    }


}
