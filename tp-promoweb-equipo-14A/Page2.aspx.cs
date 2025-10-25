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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindArticulosConImagenes();
        }

        private void BindArticulosConImagenes()
        {
            var negocio = new ArticulosNegocio();
            var lista = negocio.ListarART(); 

            var agrupado = lista 
                .GroupBy(a => a.Id)
                .Select(g => new ArticuloConImagenes
                {
                    Articulo = g.First(),
                    Imagenes = g
                        .Select(x => x.ImagenUrl)
                        .Where(u => !string.IsNullOrEmpty(u))
                        .Distinct()
                        .ToList()
                })
                .ToList();

            Repetidor.DataSource = agrupado;
            Repetidor.DataBind();
        }

        protected void Repetidor_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;

            var modelo = (ArticuloConImagenes)e.Item.DataItem;
            var rpt = (Repeater)e.Item.FindControl("rptImagenes");
            if (rpt != null)
            {
                rpt.DataSource = modelo.Imagenes;
                rpt.DataBind();
            }
        }

        public class ArticuloConImagenes
        {
            public Articulos Articulo { get; set; }
            public List<string> Imagenes { get; set; } = new List<string>();
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