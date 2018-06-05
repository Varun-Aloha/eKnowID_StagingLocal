using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eknowID.Pages
{
    public partial class Contactus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            // Set page title,Meta Description, Meta Keywords
            Page.Title = "eKnowID | Contact Us | Need Clarification? Call or Email us today.";
            Page.MetaDescription = "Doubts about our services? Call or email us and we'd be happy to help.";
        }
    }
}