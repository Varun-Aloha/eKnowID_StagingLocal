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
    public partial class stateDropdown : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetStateList();
            }
        }

        private void GetStateList()
        {
            if (ddlState_1.Items.Count == 0)
            {
                IRepository<State> state = new Repository<State>();
                IList<State> stateList = state.SelectAll();
                ddlState_1.DataTextField = "Name";
                ddlState_1.DataValueField = "StateId";
                ddlState_1.DataSource = stateList;
                ddlState_1.DataBind();

                ddlState_1.Items.Insert(0, new ListItem("Select", "0"));
                ddlState_1.SelectedIndex = 0;
            }
        }

        public int Index
        {
            set
            {
                GetStateList();
                ddlState_1.SelectedIndex = value;
            }
        }


    }
}