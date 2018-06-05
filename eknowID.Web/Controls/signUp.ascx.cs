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
    public partial class SignUp : System.Web.UI.UserControl
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
            IRepository<SecQuestion> seqQuestion = new Repository<SecQuestion>();
            IList<SecQuestion> question = seqQuestion.SelectAll();
            ddlSecretQuestion.DataTextField = "Question";
            ddlSecretQuestion.DataValueField = "SecQuestionId";
            ddlSecretQuestion.DataSource = question;
            ddlSecretQuestion.DataBind();

            ddlSecretQuestion.Items.Insert(0, new ListItem("Select", "0"));
            ddlSecretQuestion.SelectedIndex = 0;

            //IRepository<County> county = new Repository<County>();
            //IList<County> counties = county.SelectAll();
            //ddlCounty.DataTextField = "Name";
            //ddlCounty.DataValueField = "CountyId";
            //ddlCounty.DataSource = counties;
            //ddlCounty.DataBind();

            //ddlCounty.Items.Insert(0, new ListItem("Select", "0"));
            //ddlCounty.SelectedIndex = 0;

            //IRepository<District> district = new Repository<District>();
            //IList<District> districts = district.SelectAll();
            //ddlDistrict.DataTextField = "Name";
            //ddlDistrict.DataValueField = "DistrictId";
            //ddlDistrict.DataSource = districts;
            //ddlDistrict.DataBind();

            //ddlDistrict.Items.Insert(0, new ListItem("Select", "0"));
            //ddlDistrict.SelectedIndex = 0;
        }

        protected void btnSingupFacebook_Click(object sender, ImageClickEventArgs e)
        {
           
        }       
    }
}