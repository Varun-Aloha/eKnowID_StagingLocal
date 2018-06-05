using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eknowID.Controls
{
    public partial class year : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {           
            FillYear();             
        }

        public void FillYear()
        {
            if (ddlYear.Items.Count == 0)
            {
                int currentYear = DateTime.Now.Year;
                int goBackwardsYears = 100; // or 15 as per your need
                ddlYear.Items.Add(new ListItem("Year", "0"));
                for (int i = 0; i <= goBackwardsYears; i++)
                {
                    ddlYear.Items.Add(new ListItem(currentYear.ToString(), currentYear.ToString()));
                    currentYear--;
                }
            }
        }      
    }
}