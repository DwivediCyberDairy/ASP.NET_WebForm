﻿using pramodSourceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pramodSourceSystem
{
    public partial class Masterpage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
              
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            GlobalSession.LogOut();
            Response.Redirect("Owl_Login1.aspx", false);
 
        }
    }
}