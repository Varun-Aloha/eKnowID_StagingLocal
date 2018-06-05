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
    public partial class LanguageKnown : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if (SessionWrapper.LoggedUser != null)
            {
                SetLanguagesKnown();
           }
        }

        private void SetLanguagesKnown()
        {
            UserSkill userSkill = UserSkillHelper.GetUserSkillByUserId(SessionWrapper.LoggedUser.UserId);
            if (userSkill != null)
            {
                List<UserLanuagesKnown> userLanuagesKnownList = UserSkillHelper.GetLanguagesKnownListBySkillId(userSkill.UserSkillId);
                if (userLanuagesKnownList.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "AddLangControl(" + userLanuagesKnownList.Count + ");", true);
                    FillInformation(userLanuagesKnownList);
                }
            }
        }

        private void FillInformation(List<UserLanuagesKnown> List)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type=text/javascript>");
            for (int i = 0; i < List.Count; i++)
            {
                sb.Append("languagesKnown.push('" + List[i].Lanuage + "');");
                sb.Append("languagesKnownId.push('" + List[i].UserLanuagesKnownId + "');");

            }
            sb.Append("setLangData();");
            sb.Append("</script>");

            Page.ClientScript.RegisterStartupScript(this.GetType(), "TestArrayScript", sb.ToString());
        }
    }
}