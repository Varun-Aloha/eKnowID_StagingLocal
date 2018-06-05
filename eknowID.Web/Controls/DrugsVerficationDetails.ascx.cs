using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EknowIDData.Interfaces;
using EknowIDModel;
using EknowIDData.Implementations;

namespace eknowID.Controls
{
    public partial class DrugsVerficationDetails : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillCombos();
            }
        }

        private void FillCombos()
        {
            //IRepository<DrugVerification> repository = new Repository<DrugVerification>();
            //IList<DrugVerification> drugs = repository.SelectAll();
            //ddlDrugVerification.DataTextField = "Name";
            //ddlDrugVerification.DataValueField = "DrugVerificationId";
            //ddlDrugVerification.DataSource = drugs;
            //ddlDrugVerification.DataBind();

            //ddlDrugVerification.Items.Insert(0, new ListItem("Select", "0"));
            //ddlDrugVerification.SelectedIndex = 0;
            ddlDrugVerification.Items.Add(new ListItem("Pre-Employment","1"));
            ddlDrugVerification.Items.Add(new ListItem("Random", "2"));
        }
    }
}