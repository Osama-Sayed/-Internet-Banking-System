﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IBS_Website
{
    public partial class ClientProfilenavbar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx"); 
        }
    }
}