using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using EknowIDData.Helper;
using EknowIDModel;
using System.Text;
using eknowID.AppCode;


public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static string[] GetCourtAddress(int StateID)
    {
        string[] arr = new string[2];
        arr[0] = "At Place 0" + StateID.ToString();
        arr[1] = "At place 1" + StateID.ToString();

        return arr;
    }
    [WebMethod]
    public static string GetCourtList(int StateId, int CourtTypeId)
    {        
        string row = "<tr class='gradeA'><td>[OfficeName]</td><td>[City]</td><td>[State]</td><td class='center'>[Zip]</td></tr>";

        List<Court> courts = new List<Court>();
        Court court = new Court();
        string rows = string.Empty;
        string temp = string.Empty;

        //List<CourtLocation> courtts = CourtLocaterHelper.GetCourtList(StateId, CourtTypeId);

        //foreach (CourtLocation courtLocation in courtts)
        //{
        //    temp = row.Replace("[OfficeName]", courtLocation.OfficeName).Replace("[City]", courtLocation.CityId.ToString()).Replace("[State]", courtLocation.StateId.ToString()).Replace("[Zip]", courtLocation.CityId.ToString());
        //    rows = rows + temp;
        //}

        List<State> stateList = new List<State>();

        stateList = StateHelper.GetStateList();

        foreach (State state in stateList)
        {
            temp = row.Replace("[OfficeName]", state.StateId.ToString()).Replace("[City]", state.Name).Replace("[State]", state.AlphaCode).Replace("[Zip]", state.ValidationRuleId.ToString());
            rows = rows + temp;
        }

        return rows;
       
    }
}