using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using Brickred.SocialAuth.NET.Core.BusinessObjects;
using System.IO;
using TazWorksCom.XMLClasses;
using System.Text.RegularExpressions;
using EknowIDModel;
using EknowIDModel.UserProfile;
using System.Threading;
using EknowIDData.Helper;

namespace eknowID.AppCode
{
    public class BasePage : System.Web.UI.Page
    {

        [WebMethod]
        public static void Login(string providername)
        {
            PROVIDER_TYPE providerType = (PROVIDER_TYPE)Enum.Parse(typeof(PROVIDER_TYPE), providername);
            SocialAuthUser.GetCurrentUser().Login(providerType);
        }

        [WebMethod]
        public static string IsUserLoggedIn()
        {
            try
            {
                return SocialAuthUser.IsLoggedIn().ToString();
            }
            catch
            {
                return "error";
            }
        }

        [WebMethod]
        public static ProfileData Getprofile()
        {
            UserProfile profile = SocialAuthUser.GetCurrentUser().GetProfile();

            SessionWrapper.LinkedinData = null;
            SessionWrapper.ResumeParserData = null;

            ProfileData userProfile = new ProfileData();
            userProfile.Country = profile.Country;
            // userProfile.DateOfBirth = profile.DateOfBirth;
            userProfile.DisplayName = profile.DisplayName;
            userProfile.Email = profile.Email;
            userProfile.FirstName = profile.FirstName;
            userProfile.LastName = profile.LastName;
            userProfile.ProfilePictureURL = profile.ProfilePictureURL;
            userProfile.ProfileURL = profile.ProfileURL;
            userProfile.Provider = profile.Provider;
            userProfile.Username = profile.Username;


            string format = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
            string[] formats = { "MM/dd/yyyy", "dd/MM/yyyy", "dd/M/yyyy", format };
            DateTime dt;

            bool success = DateTime.TryParseExact(profile.DateOfBirth, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt);
            if (success)
            {
                userProfile.DateOfBirth = dt.ToString("MM/dd/yyyy");
            }

            try
            {

                if (SocialAuthUser.CurrentProvider == PROVIDER_TYPE.LINKEDIN)
                {                    
                    var result = SocialAuthUser.GetCurrentUser().ExecuteFeed(
                        "https://api.linkedin.com/v1/people/~:(headline,first-name,last-name,educations,positions,phone-numbers,main-address)",
                        TRANSPORT_METHOD.GET, PROVIDER_TYPE.LINKEDIN);

                    string xml = new StreamReader(result.GetResponseStream()).ReadToEnd();

                    string[] Titles = { "first-name", "last-name", "relation-to-viewer", "num-recommenders", "current-status", "current-status-timestamp", "start-date", "is-current", "school-name", "end-date", "member-url-resources", "member-url", "api-standard-profile-request", "http-header", "site-standard-profile-request", "picture-url", "field-of-study", "phone-numbers", "phone-type", "main-address" };
                    string[] Titles1 = { "FirstName", "LastName", "RelationToViewer", "NumRecommenders", "CurrentStatus", "CurrentStatusTimestamp", "StartDate", "IsCurrent", "SchoolName", "EndDate", "MemberUrlResources", "MemberUrl", "ApiStandardProfileRequest", "HttpHeader", "SiteStandardProfileRequest", "PictureUrl", "FieldOfStudy", "phonenumbers", "phonetype", "MainAddress" };
                    for (int loopCount = 0; loopCount < Titles.Count(); loopCount++)
                    {
                        xml = xml.Replace(Titles[loopCount], Titles1[loopCount]);
                    }

                    int index = xml.IndexOf("<phonenumbers total=");

                    string xmlsubstring = xml.Substring(index + 20);

                    index = xmlsubstring.IndexOf(">");
                    string total = xmlsubstring.Substring(0, index).Replace("\"", "");

                    if (total.Contains("/"))
                        total = total.Replace("/", "");

                    try
                    {

                        for (int i = 0; i < Convert.ToInt32(total.Trim()); i++)
                        {
                            var regex = new Regex("phone-number");
                            xml = regex.Replace(xml, "phonenumber", i + 1);
                            xml = regex.Replace(xml, "phoneNumber", i + 2);
                            xml = regex.Replace(xml, "phonenumber", i + 1);
                            break;
                        }
                    }
                    catch (Exception ex)
                    {

                    }

                    person person = (person)SerializationHelper.XmlDeserializeFromString(xml, typeof(person));

                    if (person.MainAddress != null)
                        userProfile.Address = person.MainAddress;

                    if (person.phonenumbers != null)
                    {
                        if (person.phonenumbers.phonenumber != null)
                        {
                            userProfile.PhoneNumber = person.phonenumbers.phonenumber.phoneNumber;
                        }
                    }
                    FillSessionValues(person);
                }
            }
            catch (Exception e)
            {
            }
            return userProfile;

        }

        public static void FillSessionValues(person person)
        {
            SessionWrapper.LinkedinData = new LinkedinData();
            SessionWrapper.LinkedinData.EducationalDetail = new EknowIDModel.UserEducationalDetail();
            SessionWrapper.LinkedinData.EmploymentDetailes = new List<UserEmploymentDetail>();
            UserEducationalDetail educationdetail = new UserEducationalDetail();
            UserPostGraduation postGraduation = new UserPostGraduation();
            UserEmploymentDetail empDetails;
            string startDate = string.Empty;
            string endDate = string.Empty;
            int educations = 0, positions = 0;

            if (person.educations != null)
            {
                educations = Convert.ToInt32(person.educations.total);
            }

            if (person.Positions != null)
            {
                positions = Convert.ToInt32(person.Positions.total);
            }

            if (educations != 0)
            {
                educationdetail.Basic = person.educations.education[0].degree;
                educationdetail.Specialization = person.educations.education[0].FieldOfStudy;

                if (person.educations.education[0].StartDate != null)
                {
                    educationdetail.StartYear = Convert.ToInt32(person.educations.education[0].StartDate.year);
                    educationdetail.StartMonth = 1;
                }
                if (person.educations.education[0].StartDate != null)
                {
                    educationdetail.EndYear = Convert.ToInt32(person.educations.education[0].EndDate.year);
                    educationdetail.EndMonth = 1;

                }

                SessionWrapper.LinkedinData.EducationalDetail = educationdetail;

                if (educations >= 2)
                {
                    postGraduation.PostGraduation = person.educations.education[1].degree;
                    postGraduation.Specialization = person.educations.education[1].FieldOfStudy;

                    if (person.educations.education[1].StartDate != null)
                    {
                        postGraduation.StartYear = Convert.ToInt32(person.educations.education[1].StartDate.year);
                        postGraduation.StartMonth = 1;
                    }
                    if (person.educations.education[1].StartDate != null)
                    {
                        postGraduation.EndYear = Convert.ToInt32(person.educations.education[1].EndDate.year);
                        postGraduation.EndMonth = 1;
                    }
                    SessionWrapper.LinkedinData.Postgraduation = postGraduation;
                }


            }
            if (positions != 0)
            {
                for (int i = 0; i < Convert.ToInt32(person.Positions.total); i++)
                {
                    empDetails = new UserEmploymentDetail();
                    startDate = string.Empty;
                    endDate = string.Empty;

                    empDetails.OrgName = person.Positions.position[i].company.name;
                    empDetails.PositionTitle = person.Positions.position[i].title;
                    empDetails.Description = person.Positions.position[i].summary;
                    if (person.phonenumbers != null && person.phonenumbers.phonenumber != null)
                    {
                        empDetails.Telephone = person.phonenumbers.phonenumber.phoneNumber;
                    }
                    if (person.Positions.position[i].StartDate != null)
                    {
                        empDetails.StartYear = Convert.ToInt32(person.Positions.position[i].StartDate.year);
                        empDetails.StartMonth = Convert.ToInt32(person.Positions.position[i].StartDate.month);
                    }
                    if (person.Positions.position[i].EndDate != null)
                    {
                        empDetails.EndYear = Convert.ToInt32(person.Positions.position[i].EndDate.year);
                        empDetails.EndMonth = Convert.ToInt32(person.Positions.position[i].EndDate.month);
                    }

                    SessionWrapper.LinkedinData.EmploymentDetailes.Add(empDetails);
                }
            }
        }
    }

    public class ProfileData
    {
        public string Country { get; set; }
        public string DateOfBirth { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public GENDER GenderType { get; set; }
        public string ID { get; set; }
        public string Language { get; set; }
        public string LastName { get; set; }
        public string ProfilePictureURL { get; set; }
        public string ProfileURL { get; set; }
        public PROVIDER_TYPE Provider { get; set; }
        public string Username { get; set; }

        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}