using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IBS_Website
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginH_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginFrame.html");
        }

        protected void RegisterH_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterFrame.html");
        }
    }
}