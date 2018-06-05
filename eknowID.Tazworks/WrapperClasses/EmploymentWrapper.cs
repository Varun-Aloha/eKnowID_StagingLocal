using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EknowIDModel;
using TazWorksCom.XMLClasses;
using EknowIDData.Implementations;
using EknowIDData.Helper;

namespace TazWorksCom.WrapperClasses
{
    public class EmploymentWrapper
    {
        private EmploymentDetail _employmentDetail;
        public EmploymentWrapper(EmploymentDetail empDetail)
        {
            _employmentDetail = empDetail;            
        }

        public EmploymentScreening GetXMLNode()
        {
            EmploymentScreening employmentScreening = new EmploymentScreening();

            string region = StateHelper.GetStateById(_employmentDetail.StateId).AlphaCode;

            employmentScreening.OrganizationName = _employmentDetail.OrgName;
            employmentScreening.ContactInfo = new ContactInfo();
            employmentScreening.ContactInfo.Telephone = _employmentDetail.Telephone;
            employmentScreening.ContactInfo.PersonName = new ReferencePersonName();
            employmentScreening.ContactInfo.PostalAddress = new PostalAddress();
            employmentScreening.ContactInfo.PostalAddress.Region = region;
            employmentScreening.Title = _employmentDetail.PositionTitle;
            //employmentScreening.StartDate = _employmentDetail.StartDate.ToShortDateString();

            employmentScreening.StartDate = _employmentDetail.StartYear + "-" + _employmentDetail.StartMonth + "01";

            if (_employmentDetail.EndMonth != 0)
            {
                employmentScreening.EndDate = _employmentDetail.EndYear + "-" + _employmentDetail.EndMonth + "01";

                // employmentScreening.EndDate = _employmentDetail.EndDate.HasValue ? _employmentDetail.EndDate.Value.ToString("MM/dd/yyyy") : "";
            }           
            return employmentScreening;
        }
    }
}
