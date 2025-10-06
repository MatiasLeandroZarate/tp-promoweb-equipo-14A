using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace tp_promoweb_equipo_14A
{
    public partial class Page2 : System.Web.UI.Page
    {
        public List<Articulos>ListaArticulo {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticulosNegocio negocio = new ArticulosNegocio();
            ListaArticulo = negocio.ListarART();
            if(!IsPostBack)
            { 
            Repetidor.DataSource = ListaArticulo;
            Repetidor.DataBind();
            }

          
        }
        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument;
         //   Session.Add("IdArticulo", valor);
            Response.Redirect("Page3.aspx");
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("Page1.aspx");
        }
    }
}