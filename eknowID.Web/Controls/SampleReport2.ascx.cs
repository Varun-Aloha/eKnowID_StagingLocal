using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace eknowID.Controls
{
    public partial class SampleReport2 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Sno");
            dt.Columns.Add("Address");
            dt.Columns.Add("Phone");
            dt.Columns.Add("Dates");
            dt.Rows.Add("1", "911 N DEADEND PLACE MAPLEWOOD, NJ 07040 , ESSEX", "(555)254-6011", "19/01/2011-26/12/2012");
            dt.Rows.Add("2", "611 S LOSER ST NEW YORK, NY 10031,NEWYORK  ", "N/A", "19/01/2011-26/12/2012");
            dt.Rows.Add("3", "911 N DEADEND PLACE MAPLEWOOD, NJ 07040 , ESSEX", "(555)254-6011", "19/01/2011-26/12/2012");
            dt.Rows.Add("4", "611 S LOSER ST NEW YORK, NY 10031,NEWYORK  ", "N/A", "19/01/2011-26/12/2012");
            dt.Rows.Add("5", "911 N DEADEND PLACE MAPLEWOOD, NJ 07040 , ESSEX", "(555)254-6011", "19/01/2011-26/12/2012");
            grvAddressHistory.DataSource = dt;
            grvAddressHistory.DataBind();
        }
    }
}