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
    public partial class Page3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente nuevo = new Cliente();
                ClienteNegocio negocio = new ClienteNegocio();

                nuevo.DNI = (string)txtDNI.Text;
                nuevo.Nombre = (string)txtNombre.Text;
                nuevo.Apellido = (string)txtApellido.Text;
                nuevo.Email = (string)txtEmail.Text;
                nuevo.Direccion = (string)txtDireccion.Text;
                nuevo.Ciudad = (string)txtCiudad.Text;
                nuevo.CP = (string)txtCP.Text;

                negocio.agregar(nuevo);


                Response.Redirect("Page1.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("Page2.aspx");
        }
    }
}