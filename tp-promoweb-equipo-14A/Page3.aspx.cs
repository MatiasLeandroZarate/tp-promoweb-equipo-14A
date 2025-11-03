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
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void txtDNI_TextChanged(object sender, EventArgs e)
        {
            Cliente c = Clienteencontrado(txtDNI.Text);

            if (c != null)
            {
                if (string.IsNullOrEmpty(txtNombre.Text)) txtNombre.Text = c.Nombre;
                if (string.IsNullOrEmpty(txtApellido.Text)) txtApellido.Text = c.Apellido;
                if (string.IsNullOrEmpty(txtEmail.Text)) txtEmail.Text = c.Email;
                if (string.IsNullOrEmpty(txtDireccion.Text)) txtDireccion.Text = c.Direccion;
                if (string.IsNullOrEmpty(txtCiudad.Text)) txtCiudad.Text = c.Ciudad;
                if (string.IsNullOrEmpty(txtCP.Text)) txtCP.Text = c.CP;

                hfClienteId.Value = c.Id.ToString();
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            Cliente nuevo = new Cliente();
            ClienteNegocio negocio = new ClienteNegocio();
            
            try
            {
                if (!Validacion.ValidarTxtVacio(txtDNI) && !Validacion.ValidarTxtVacio(txtNombre) && !Validacion.ValidarTxtVacio(txtApellido) && !Validacion.ValidarTxtVacio(txtEmail) && !Validacion.ValidarTxtVacio(txtDireccion) && !Validacion.ValidarTxtVacio(txtCiudad) && !Validacion.ValidarTxtVacio(txtCP))
                {
                    if (chkTerminos.Checked == true)
                    {
                        Cliente existente = Clienteencontrado(txtDNI.Text);

                        if (existente != null)
                        {
                            existente.DNI = txtDNI.Text;
                            existente.Nombre = txtNombre.Text;
                            existente.Apellido = txtApellido.Text;
                            existente.Email = txtEmail.Text;
                            existente.Direccion = txtDireccion.Text;
                            existente.Ciudad = txtCiudad.Text;
                            existente.CP = txtCP.Text;

                            negocio.modificar(existente);
                        }
                        else
                        {
                            nuevo.DNI = txtDNI.Text;
                            nuevo.Nombre = txtNombre.Text;
                            nuevo.Apellido = txtApellido.Text;
                            nuevo.Email = txtEmail.Text;
                            nuevo.Direccion = txtDireccion.Text;
                            nuevo.Ciudad = txtCiudad.Text;
                            nuevo.CP = txtCP.Text;

                            negocio.agregar(nuevo);
                        }
                        agregarVou();

                        Response.Redirect("Participando.aspx", false);
                        Context.ApplicationInstance.CompleteRequest();
                    }
                    else
                    {
                        Session.Add("Error", "Acepte los Terminos y Condiciones.");
                        Session["prevPage"] = Request.Url.ToString(); // guarda la URL actual
                        Response.Redirect("Error.aspx", false);
                        Context.ApplicationInstance.CompleteRequest();                        
                    }
                }
                else
                {
                    Session.Add("Error", "Por favor, complete todos los campos.");
                    Session["prevPage"] = Request.Url.ToString(); // guarda la URL actual
                    Response.Redirect("Error.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
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
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Page2.aspx");
        }

        public Cliente Clienteencontrado(string Dni)
        {
            AccesoBD datos = new AccesoBD();
            try
            {
                datos.setearQuery("SELECT Id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP FROM Clientes WHERE Documento = @DNI");
                datos.setearParametro("@DNI", Dni);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    Cliente c = new Cliente();
                    c.Id = Convert.ToInt32(datos.Lector["Id"]);
                    c.DNI = datos.Lector["Documento"].ToString();
                    c.Nombre = datos.Lector["Nombre"].ToString();
                    c.Apellido = datos.Lector["Apellido"].ToString();
                    c.Email = datos.Lector["Email"].ToString();
                    c.Direccion = datos.Lector["Direccion"].ToString();
                    c.Ciudad = datos.Lector["Ciudad"].ToString();
                    c.CP = datos.Lector["CP"].ToString();

                    return c;
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

        public void agregarVou()
        {
            AccesoBD datos = new AccesoBD();
            try
            {
                string DNI = txtDNI.Text;
                string codVoucher = Session["CodigoVoucher"].ToString();
                int IdArticulo = (int)Session["IdArticulo"];
                DateTime fechaCanje = DateTime.Now;

                int IdCliente = 0;
                datos.setearQuery("SELECT Id FROM Clientes WHERE Documento = @Documento");
                datos.setearParametro("@Documento", DNI);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    IdCliente = (int)datos.Lector["Id"];
                }
                datos.cerrarConexion();

                datos.setearQuery("UPDATE Vouchers SET IdCliente = @IdCliente, FechaCanje = @FechaCanje, IdArticulo = @IdArticulo WHERE CodigoVoucher = @CodigoVoucher");
                datos.setearParametro("@CodigoVoucher", codVoucher);
                datos.setearParametro("@FechaCanje", fechaCanje);
                datos.setearParametro("@IdCliente", IdCliente);
                datos.setearParametro("@IdArticulo", IdArticulo);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { datos.cerrarConexion(); }
        }
    }
}
