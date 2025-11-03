using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_promoweb_equipo_14A
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["error"] != null)
            {
                lblError.Text = Server.HtmlEncode(Session["error"].ToString());
            }

        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            if (Session["prevPage"] != null)
            {
                Response.Redirect(Session["prevPage"].ToString(), false);
                Context.ApplicationInstance.CompleteRequest();
            }
            else
            {

                Response.Redirect("Page1.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }
    }
}