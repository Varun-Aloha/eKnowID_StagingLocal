using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EknowIDModel;
using TazWorksCom.XMLClasses;
using EknowIDData.Interfaces;
using EknowIDData.Implementations;
using EknowIDData.Helper;

namespace TazWorksCom.WrapperClasses
{
    public class EducationScreeningWrapper
    {
        private EducationalDetail _educationalDetails;
        public EducationScreeningWrapper(EducationalDetail educationalDetail)
        {
            _educationalDetails = educationalDetail;            
        }

        public EducationScreening GetXMLNode()
        {
            EducationScreening educationalScreening = new EducationScreening();

            string region = StateHelper.GetStateById(_educationalDetails.StateId).AlphaCode;
            

            educationalScreening.Region = region;
            educationalScreening.EducationHistory = new EducationHistory();
            educationalScreening.EducationHistory.SchoolOrInstitution = new SchoolOrInstitution();            
            educationalScreening.EducationHistory.SchoolOrInstitution.SchoolName = _educationalDetails.University;
            educationalScreening.EducationHistory.SchoolOrInstitution.LocationSummary = new LocationSummary();
            educationalScreening.EducationHistory.SchoolOrInstitution.LocationSummary.Municipality = _educationalDetails.Municipality;                        
            educationalScreening.EducationHistory.SchoolOrInstitution.LocationSummary.Region = region;
            educationalScreening.EducationHistory.SchoolOrInstitution.Degree = new Degree();
            educationalScreening.EducationHistory.SchoolOrInstitution.Degree.degreeType = _educationalDetails.Basic; 
            educationalScreening.EducationHistory.SchoolOrInstitution.Degree.DegreeName = _educationalDetails.Specialization;
            educationalScreening.EducationHistory.SchoolOrInstitution.DatesOfAttendance = new DatesOfAttendance();
            educationalScreening.EducationHistory.SchoolOrInstitution.DatesOfAttendance.StartDate = new StartDate();
            //educationalScreening.EducationHistory.SchoolOrInstitution.DatesOfAttendance.StartDate.StringDate = _educationalDetails.StartDate.ToShortDateString();
            string date = _educationalDetails.StartYear + "-" + _educationalDetails.StartMonth + "TO" + _educationalDetails.EndYear + "-" + _educationalDetails.EndMonth;
            educationalScreening.EducationHistory.SchoolOrInstitution.DatesOfAttendance.StartDate.StringDate = date;
            

            return educationalScreening;

        }
    }
}
