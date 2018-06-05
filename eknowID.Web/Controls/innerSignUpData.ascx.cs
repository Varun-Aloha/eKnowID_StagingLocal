using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EknowIDData.Interfaces;
using EknowIDData.Implementations;
using EknowIDModel;

namespace eknowID.Controls
{
    public partial class innerSignUpData : System.Web.UI.UserControl
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
            //IRepository<State> stateRep = new Repository<State>();
            //IList<State> states = stateRep.SelectAll();            
            //ddlStateInner.DataTextField = "Name";
            //ddlStateInner.DataValueField = "StateId";
            //ddlStateInner.DataSource = states;
            //ddlStateInner.DataBind();

            //ddlStateInner.Items.Insert(0, new ListItem("Select", "0"));
            //ddlStateInner.SelectedIndex = 0;

            IRepository<SecQuestion> seqQuestion = new Repository<SecQuestion>();
            IList<SecQuestion> question = seqQuestion.SelectAll();
            ddlSecretQuestionInner.DataTextField = "Question";
            ddlSecretQuestionInner.DataValueField = "SecQuestionId";
            ddlSecretQuestionInner.DataSource = question;
            ddlSecretQuestionInner.DataBind();

            ddlSecretQuestionInner.Items.Insert(0, new ListItem("Select", "0"));
            ddlSecretQuestionInner.SelectedIndex = 0;
        }
    }
}