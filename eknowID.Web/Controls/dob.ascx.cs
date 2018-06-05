using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EknowIDLib;

namespace eknowID.Controls
{
    public partial class dob : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillYear();
        }

        public void FillYear()
        {
            if (year.Items.Count == 0)
            {
                int currentYear = DateTime.Now.Year - Constant.VALIDAGE;
                int goBackwardsYears = 100; // or 15 as per your need
                year.Items.Add(new ListItem("Year", "0"));
                for (int i = 0; i <= goBackwardsYears; i++)
                {
                    year.Items.Add(new ListItem(currentYear.ToString(), currentYear.ToString()));
                    currentYear--;
                }
            }
        }
    }
}