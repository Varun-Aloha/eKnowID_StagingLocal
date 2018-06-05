using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eknowID.AppCode;
using EknowIDLib;

namespace eknowID.Pages
{
    public partial class GetStarted_ProtectID : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            // Set page title,Meta Description, Meta Keywords
           Page.Title = "eKnowID | Protect your Identity | Identity Theft Fraud is the Highest in the Country. Are you a Victim? Find out with eKnowID.";
           Page.MetaKeywords = "eKnowID, background check, background checks, self check, criminal records, stolen identity, identity theft fraud, record check";
            Page.MetaDescription = "Do you think you are a victim of identity theft fraud? Order one of our packages and find out now what you may only doubt.";
        }
    }
}