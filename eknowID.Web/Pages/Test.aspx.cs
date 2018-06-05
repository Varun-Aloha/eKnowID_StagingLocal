using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eknowID.AppCode;
using System.IO;
using TazWorksCom.HelperClasses;
using TazWorksCom.XMLClasses;
using TazWorksCom;
using EknowIDModel;
using EknowIDData.Implementations;
using EknowIDData.Interfaces;
using EknowIDData.Helper;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using EknowIDModel.UserProfile;
using EknowIDData.Helper.ResumeParser;
using Brickred.SocialAuth.NET.Core.BusinessObjects;
using System.Web.Services;
using System.Threading;
using EknowIDLib;

namespace eknowID.Pages
{
    public partial class SingUpTemp : BasePage
    {
        public bool isReferenceInfo = true;
        public bool isEmploymentDetails = true;
        public bool isLicenseDetails = true;
        public bool isEducationDetails = true;
        public bool isUserloggedIIn = false;
        string serviceUrl = ConfigurationManager.AppSettings["ServiceUrl"];
        string userKey = ConfigurationManager.AppSettings["UserKey"];
        string version = ConfigurationManager.AppSettings["Version"];
        string subUserKey = ConfigurationManager.AppSettings["subUserKey"];
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Td_Click(object sender, EventArgs e)
        {

            string xml2 = File.ReadAllText("D:\\Suraj\\Suraj\\Code\\TazWorksCom\\Tazzwork_request.xml");

            //string xmlEnquiry = File.ReadAllText("D:\\EknowID\\Code\\TazWorksCom\\Res.xml");

            //string[] Titles = { "first-name", "last-name", "relation-to-viewer", "num-recommenders", "current-status", "current-status-timestamp", "start-date", "is-current", "school-name", "end-date", "member-url-resources", "member-url", "api-standard-profile-request", "http-header", "site-standard-profile-request", "picture-url", "field-of-study", "phone-numbers","phone-type", "main-address" };
            //string[] Titles1 = { "FirstName", "LastName", "RelationToViewer", "NumRecommenders", "CurrentStatus", "CurrentStatusTimestamp", "StartDate", "IsCurrent", "SchoolName", "EndDate", "MemberUrlResources", "MemberUrl", "ApiStandardProfileRequest", "HttpHeader", "SiteStandardProfileRequest", "PictureUrl", "FieldOfStudy", "phonenumbers","phonetype", "MainAddress" };
            //for (int loopCount = 0; loopCount < Titles.Count(); loopCount++)
            //{
            //    xmlEnquiry = xmlEnquiry.Replace(Titles[loopCount], Titles1[loopCount]);
            //}

            //var regex = new Regex("phone-number");
            //xmlEnquiry = regex.Replace(xmlEnquiry, "phonenumber", 1);
            //xmlEnquiry = regex.Replace(xmlEnquiry, "phoneNumber", 2);
            //xmlEnquiry = regex.Replace(xmlEnquiry, "phonenumber", 1);



            //ResumeParserData person = (ResumeParserData)SerializationHelper.XmlDeserializeFromString(xmlEnquiry, typeof(ResumeParserData));


            //FillSessionValues(person);

            //if (SessionWrapper.LinkedinData.EmploymentDetailes.Count != 0)
            //{
            //    for (int i = 0; i < SessionWrapper.LinkedinData.EmploymentDetailes.Count; i++)
            //    {
            //        SessionWrapper.LinkedinData.EmploymentDetailes[i].UserId = SessionWrapper.LoggedUser.UserId;
            //    }
            //    UserEmploymentDetailsHelper.SaveUserEmpDetails(SessionWrapper.LinkedinData.EmploymentDetailes);
            //}
            //if (SessionWrapper.LinkedinData.EducationalDetail != null)
            //{
            //    SessionWrapper.LinkedinData.EducationalDetail.UserId = SessionWrapper.LoggedUser.UserId;
            //    UserEducationalDetailHelper.SaveUserEducationDetail(SessionWrapper.LinkedinData.EducationalDetail);
            //}

            ProcessRequest proRequest = new ProcessRequest();

            string response = proRequest.HttpPost(xml2);

            ConstructRequest req = new ConstructRequest();
            req.GetResponse(37, 3);
        }

        //public static void FillSessionValues(person person)
        //{
        //    SessionWrapper.LinkedinData = new LinkedinData();
        //    SessionWrapper.LinkedinData.EducationalDetail = new EknowIDModel.UserEducationalDetail();
        //    SessionWrapper.LinkedinData.EmploymentDetailes = new List<UserEmploymentDetail>();
        //    UserEducationalDetail educationdetail = new UserEducationalDetail();
        //    UserEmploymentDetail empDetails;
        //    educationdetail.Basic = person.educations.education[0].degree;
        //    educationdetail.Specialization = person.educations.education[0].FieldOfStudy;
        //    string startDate = string.Empty;
        //    string endDate = string.Empty;
        //    if (person.educations.education[0].StartDate != null)
        //    {
        //        startDate = "01/01/" + person.educations.education[0].StartDate.year;
        //        educationdetail.StartDate = Convert.ToDateTime(startDate);
        //    }
        //    if (person.educations.education[0].StartDate != null)
        //    {
        //        endDate = "01/01/" + person.educations.education[0].EndDate.year;
        //        educationdetail.EndDate = Convert.ToDateTime(endDate);
        //    }

        //    SessionWrapper.LinkedinData.EducationalDetail = educationdetail;

        //    for (int i = 0; i < Convert.ToInt32(person.Positions.total); i++)
        //    {
        //        empDetails = new UserEmploymentDetail();
        //        empDetails.OrgName = person.Positions.position[i].company.name;
        //        empDetails.PositionTitle = person.Positions.position[i].title;
        //        empDetails.Description = person.Positions.position[i].summary;
        //        empDetails.Telephone = person.phonenumbers.phonenumber.phoneNumber;
        //        startDate = string.Empty;
        //        endDate = string.Empty;
        //        if (person.Positions.position[i].StartDate != null)
        //        {
        //            startDate = "01/" + person.Positions.position[i].StartDate.month + "/" + person.Positions.position[i].StartDate.year;
        //            empDetails.StartDate = Convert.ToDateTime(startDate);
        //        }
        //        if (person.Positions.position[i].EndDate != null)
        //        {
        //            endDate = "01/" + person.Positions.position[i].EndDate.month + "/" + person.Positions.position[i].EndDate.year;
        //            empDetails.EndDate = Convert.ToDateTime(endDate);
        //        }

        //        SessionWrapper.LinkedinData.EmploymentDetailes.Add(empDetails);
        //    }
        //}

        protected void btnEncr_Click(object sender, EventArgs e)
        {
            string En = EncryptionHelper.Encryptdata(txtpwd.Text.Trim());

            string pwd = EncryptionHelper.Decryptdata(txtpwd.Text.Trim());
        }

        public void updateXmlFile(string strFileName)
        {
            XDocument xDoc = XDocument.Load(strFileName);

            var nameAttributes = from el in xDoc.Root.Elements()
                                 from attr in el.Attributes()
                                 where attr.Name.ToString().ToLower().Contains("-")
                                 select attr;

            foreach (var attribute in nameAttributes)
            {
                string ss = attribute.Name.ToString().Replace("-", "_");
            }

            xDoc.Save(strFileName);
        }

        protected void btnTe_Click(object sender, EventArgs e)
        {
            string extention = Path.GetExtension(Server.MapPath(fileuploadResumeParser.FileName));
            string fileName = Server.MapPath(fileuploadResumeParser.FileName).Replace(extention, DateTime.Now.ToString("yyyyMMddHHmmssfff")) + extention;
            fileName = fileName.Replace("Pages", "UploadResume");
            fileuploadResumeParser.PostedFile.SaveAs(fileName);

            ResumeParserHelper resumeParser = new ResumeParserHelper();
            resumeParser.ServiceUrl = serviceUrl;
            ResumeParserMapFields resume = resumeParser.ParseResume(fileName, userKey, version, subUserKey);
        }

        protected void btnmail_Click(object sender, EventArgs e)
        {
            SendMail.Sendmail("shyam.shinde2@gmail.com", "test", "test");

        }








    }


}