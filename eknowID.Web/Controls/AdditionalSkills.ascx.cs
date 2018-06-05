using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eknowID.AppCode;
using EknowIDModel;
using EknowIDData.Helper;
using System.Text;

namespace eknowID.Controls
{
    public partial class AdditionalSkills : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {      
                if (SessionWrapper.LoggedUser != null)
                {
                    SetAdditionalSkill();
                }         
        }

        private void SetAdditionalSkill()
        {
            UserSkill userSkill = UserSkillHelper.GetUserSkillByUserId(SessionWrapper.LoggedUser.UserId);
            if (userSkill != null)
            {
                List<UserAdditionalSkill> userAdditionalSkillList = UserSkillHelper.GetAdditionalSkillListBySkillId(userSkill.UserSkillId);
                if (userAdditionalSkillList.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "AddSkillControl(" + userAdditionalSkillList.Count + ");", true);
                    FillInformation(userAdditionalSkillList);
                }         
            }

        }

        private void FillInformation(List<UserAdditionalSkill> List)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type=text/javascript>");
            for (int i = 0; i < List.Count; i++)
            {
                sb.Append("Skills.push('" + List[i].Skill + "');");
                sb.Append("additionalSkillid.push('" + List[i].AdditionalSkillId + "');");
             
            }
            sb.Append("setSkillData();");
            sb.Append("</script>");

            Page.ClientScript.RegisterStartupScript(this.GetType(), "TestArrayScript", sb.ToString());
        }
    }
}