using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace eknowID.Controls
{
    public partial class SampleReport1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("Report");
            dt.Columns.Add("Sno");
            dt.Columns.Add("Name");
            dt.Columns.Add("DateofBirth");
            dt.Columns.Add("Age");
            dt.Columns.Add("Alias");
            dt.Columns.Add("SSN");
            dt.Rows.Add("1", " John,Doe", "XXXX-04", "XX", "John Doe", "XXX-XX-XXXX");
            dt.Rows.Add("2", " John,Doe", "XXXX-04", "XX", "John Doe", "XXX-XX-XXXX");
            dt.Rows.Add("3", " John,Doe", "XXXX-04", "XX", "John Doe", "XXX-XX-XXXX");
            dt.Rows.Add("4", " John,Doe", "XXXX-04", "XX", "John Doe", "XXX-XX-XXXX");
            dt.Rows.Add("5", " John,Doe", "XXXX-04", "XX", "John Doe", "XXX-XX-XXXX");
            grvIdentity.DataSource = dt;
            grvIdentity.DataBind();

        }
    }
}