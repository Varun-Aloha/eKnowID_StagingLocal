﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eknowID.AppCode;


namespace eknowID.Pages
{
    public partial class SearchByProf_Login : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionWrapper.LoggedUser != null)
            {
               Response.Redirect("SearchByProf_PaymentInfo.aspx");                
            }
        }
    }
}