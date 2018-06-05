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
using EknowIDLib;

namespace eknowID.Controls
{
    public partial class ReferenceDetails : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (SessionWrapper.LoggedUser != null)
            {
                SetReferenceInfo();
            }
            else
            {
                rdbProfessional_1.Checked = true;
            }
        }

        private void SetReferenceInfo()
        {
            List<UserReferenceInfo> userreferenceinfolist = UserReferenceInfoHelper.GetReferenceInfoListBySkillId(SessionWrapper.LoggedUser.UserId);
            if (userreferenceinfolist.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "AddRefControl(" + userreferenceinfolist.Count + ");", true);
                FillInformation(userreferenceinfolist);
                if (null != SessionWrapper.AlacartReportListWithQty && SessionWrapper.AlacartReportListWithQty.Any(p => p.Key.Equals(Constant.REFERENCE_REPORT_ID))) {
                    var qty = SessionWrapper.AlacartReportListWithQty[Constant.REFERENCE_REPORT_ID];
                    referenceDetailsCount.Value = (userreferenceinfolist.Count < qty) ? ((qty - userreferenceinfolist.Count) + 1).ToString() : "1";
                }
            }
            else
            {
                rdbProfessional_1.Checked = true;
            }
        }
      
        private void FillInformation(List<UserReferenceInfo> List)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type=text/javascript>");
            for (int i = 0; i < List.Count; i++)
            {
                sb.Append("RefName.push('" + List[i].Name + "');");
                sb.Append("Relationship.push('" + List[i].Relationship + "');");
                sb.Append("MobileNo.push('" + List[i].MobileNumber + "');");
                sb.Append("YearsKnown.push('" + List[i].YearsKnown + "');");
                sb.Append("RefType.push('" + List[i].ReferenceTypeId + "');");
                sb.Append("ReferenceInfoId.push('" + List[i].UserReferenceInfoId + "');");
            }
            sb.Append("SetReferenceData();");
            sb.Append("</script>");

            Page.ClientScript.RegisterStartupScript(this.GetType(), "TestArrayScript", sb.ToString());
        }
    }
}