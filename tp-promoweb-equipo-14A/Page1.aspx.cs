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
            if(!IsPostBack)
            {
                txtCodigo.Text = "XXXXXXXXXX";
            }
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            string Codigo = txtCodigo.Text;
            // Validar la promo ingresada.
        }
    }
}