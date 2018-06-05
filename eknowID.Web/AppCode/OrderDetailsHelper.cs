using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EknowIDModel;
using EknowIDModel.UserProfile;
using eknowID.AppCode;
using EknowIDData.Helper;
using EknowIDData.Helper.UserProfileHelper;
using EknowIDLib;
using eknowID.Services;


namespace eknowID.AppCode
{
    public class OrderDetailsHelper
    {
        public static int SaveOrderDetails(OrderDetails orderDetails)
        {
            Order order = new Order();

            //add report data
            order.UserId = SessionWrapper.LoggedUser.UserId;
            if (SessionWrapper.ModuleName != Constant.UNCOVER_BACKGROUND)
            {
                order.PlanId = orderDetails.PlanId;
                order.ProfessionId = orderDetails.ProfessionId;
            }
            else
            {
                //set dummy plan & profession for uncover your background
                order.PlanId = 19;
                order.ProfessionId = 34;
            }
            
            //add order reference info
            if (orderDetails.ReferenceInfoes != null)
            {
                order.ReferenceInfoes = new List<ReferenceInfo>();
                foreach (ReferenceInfo re in orderDetails.ReferenceInfoes)
                {
                    order.ReferenceInfoes.Add(re);
                }
            }

            //add order educational info
            if (orderDetails.EducationalDetail != null)
            {
                order.EducationalDetails = new List<EducationalDetail>();
                order.EducationalDetails.Add(orderDetails.EducationalDetail);
            }

            //add order licence info
            if (orderDetails.LicenseInfo != null)
            {
                order.LicenseInfoes = new List<LicenseInfo>();
                order.LicenseInfoes.Add(orderDetails.LicenseInfo);
            }

            //add order Employment Details 
            if (orderDetails.EmploymentDetailes != null)
            {
                order.EmploymentDetails = new List<EmploymentDetail>();
                foreach (EmploymentDetail emp in orderDetails.EmploymentDetailes)
                {
                    order.EmploymentDetails.Add(emp);
                }
            }

            if (orderDetails.DrugVerificationDetail != null)
            {
                order.DrugVerificationDetails = new List<DrugVerificationDetail>();
                orderDetails.DrugVerificationDetail.SpecimenId = Guid.NewGuid().ToString();
                order.DrugVerificationDetails.Add(orderDetails.DrugVerificationDetail);
            }


            //Add optional report to report object
            List<OrderOptReport> orderOptReports = new List<OrderOptReport>();
            if (orderDetails.OptionalReportIds != null && orderDetails.OptionalReportIds.Count > 0)
            {
                foreach (int reportId in orderDetails.OptionalReportIds)
                {
                    OrderOptReport orderOptReport = new OrderOptReport();
                    orderOptReport.ReportId = reportId;
                }
            }
            if (orderOptReports != null && orderOptReports.Count > 0)
                order.OrderOptReports.AddRange(orderOptReports);

            order.PurchasedDate = DateTime.Now;

            //add order reference info
            if (orderDetails.ReportList != null)
            {
                using (eknowID.Repositories.eknowIDContext _dbContext = new eknowID.Repositories.eknowIDContext()) {
                order.AlacartReports = new List<AlacartReport>();
                    order.OrderAdditionalCharges = new List<OrderAdditionalCharge>();
                Dictionary<int,int> AlacartReportListWithQty = SessionWrapper.AlacartReportListWithQty;           
                    
                    var statesSelected = "";
                    var county_DistrictsSelected = "";
                    foreach (Report report in orderDetails.ReportList) {
                    var qty = (null != AlacartReportListWithQty && AlacartReportListWithQty.Any(p => p.Key.Equals(report.ReportId))) ? AlacartReportListWithQty[report.ReportId] : 1;
                       
                        if (report.Name == "State Criminal Records") {

                            if (!string.IsNullOrEmpty(SessionWrapper.SelectedStates)) {
                                statesSelected = SessionWrapper.SelectedStates;
                                county_DistrictsSelected = "";
                                PackageService packageService = new PackageService();
                                string[] splitter = new string[] { "," };
                                string[] statesSelectedLst = statesSelected.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
                                foreach (var state in statesSelectedLst) {
                                    var stateCriminalRecord = packageService.GetStateCriminalFeesByStateAlphaCode(state);
                                    if (null != stateCriminalRecord) {
                                        var additionalCharge = new OrderAdditionalCharge() {
                                            OrderId = order.OrderId,
                                            Amount = stateCriminalRecord.Fee ?? 0,
                                            Description = "State criminal access Fee for state :" + stateCriminalRecord.Name
                                        };
                                        order.OrderAdditionalCharges.Add(additionalCharge);
                                    }
                                }
                    }
                            
                        } else if (report.Name == "County Criminal Courthouse Search") {

                            if (!string.IsNullOrEmpty(SessionWrapper.SelectedCounties)) {

                                string[] splitter = new string[] { "," };
                                var countiesSelected = SessionWrapper.SelectedCounties.Split(splitter, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToList();

                                var counties = _dbContext.StateCountyCourtFees.Where(p => countiesSelected.Contains(p.Id)).OrderBy(p => p.Id);

                                statesSelected = string.Join(",", counties.Select(p => p.State.AlphaCode));
                                county_DistrictsSelected = string.Join(",", counties.Select(p => p.County));
                                foreach (var county in counties) {
                                    var additionalCharge = new OrderAdditionalCharge() {
                                        OrderId = order.OrderId,
                                        Amount = county.DistrictCourtFees ?? 0,
                                        Description = "County Criminal Court aceess Fee:" + county.County
                                    };
                                    order.OrderAdditionalCharges.Add(additionalCharge);
                                }
                            }

                        } else if (report.Name == "County Civil Courthouse Search") {
                            if (!string.IsNullOrEmpty(SessionWrapper.SelectedCivilCounties)) {

                                string[] splitter = new string[] { "," };
                                var countiesSelected = SessionWrapper.SelectedCivilCounties.Split(splitter, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToList();

                                var counties = _dbContext.StateCountyCourtFees.Where(p => countiesSelected.Contains(p.Id)).OrderBy(p => p.Id);

                                statesSelected = string.Join(",", counties.Select(p => p.State.AlphaCode));
                                county_DistrictsSelected = string.Join(",", counties.Select(p => p.County));
                                foreach (var county in counties) {
                                    var additionalCharge = new OrderAdditionalCharge() {
                                        OrderId = order.OrderId,
                                        Amount = county.DistrictCourtFees ?? 0,
                                        Description = "County Civil Court aceess Fee:" + county.County
                                    };
                                    order.OrderAdditionalCharges.Add(additionalCharge);
                                }
                            }
                        } else if (report.Name == "Federal Criminal Courthouse Search") {
                            if (!string.IsNullOrEmpty(SessionWrapper.SelectedDistricts)) {

                                string[] splitter = new string[] { "," };
                                var districtsSelected = SessionWrapper.SelectedDistricts.Split(splitter, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToList();

                                var districts = _dbContext.StateDistrictCourtFees.Where(p => districtsSelected.Contains(p.Id)).OrderBy(p => p.Id);

                                statesSelected = string.Join(",", districts.Select(p => p.State.AlphaCode));
                                county_DistrictsSelected = string.Join(",", districts.Select(p => p.DistrictCourt ?? ""));
                            }
                        }
                        if ("Education Verification" == report.Name || "Employment Verification" == report.Name) {
                            var additionalCharge = new OrderAdditionalCharge() {
                                OrderId = order.OrderId,
                                Amount = 25 * qty,
                                Description = report.Name + " Holding Fee ($25 * Qty):"
                            };
                            order.OrderAdditionalCharges.Add(additionalCharge);
                        }

                        var alacartReport = new AlacartReport() {
                            OrderId = order.OrderId,
                            ReportId = report.ReportId,
                            Qty = qty,
                            StatesSelected = statesSelected,
                            Couty_DistrictsSelected = county_DistrictsSelected
                        };
                    order.AlacartReports.Add(alacartReport);
                }
            }
            }

            //Set OrderTypeID=1 for show By Prof Order
            if(SessionWrapper.ModuleName==Constant.SECURE_JOB)
            order.OrderTypeID = 1;
            if (SessionWrapper.ModuleName == Constant.IDENTITY_THEFT)
                order.OrderTypeID = 4;
            if (SessionWrapper.ModuleName == Constant.UNCOVER_BACKGROUND)
                order.OrderTypeID = 5;
            //Call helper objec to save it into database


            OrderHelper.SaveOrder(order);
           

            //if (orderDetails.updatedUserDetails)
            //{
            //    SaveUserProfileDetails(orderDetails);
            //}

            return order.OrderId;
        }

        //private static void SaveUserProfileDetails(OrderDetails orderDetails)
        //{
        //    UserEducationalDetail userEdu = new UserEducationalDetail();
        //    UserLicenseInfo userLicenseInfo = new UserLicenseInfo();
        //    List<UserEmploymentDetail> empDetailsList = new List<UserEmploymentDetail>();
        //    UserEmploymentDetail empDetails;
        //    UserPostGraduation postGraduation = new UserPostGraduation();
        //    List<UserReferenceInfo> userRefrences = new List<UserReferenceInfo>();
        //    UserReferenceInfo userReference;


        //    if (orderDetails.EducationalDetail != null)
        //    {
        //        userEdu.Basic = orderDetails.EducationalDetail.Basic;
        //        userEdu.Specialization = orderDetails.EducationalDetail.Specialization;
        //        userEdu.University = orderDetails.EducationalDetail.University;
        //        userEdu.Municipality = orderDetails.EducationalDetail.Municipality;
        //        userEdu.StartDate = orderDetails.EducationalDetail.StartDate;
        //        userEdu.EndDate = orderDetails.EducationalDetail.EndDate;
        //        userEdu.UserId = SessionWrapper.LoggedUser.UserId;
        //        userEdu.StateId = orderDetails.EducationalDetail.StateId;

        //        if (orderDetails.EducationalDetail.PostGraduationDetails != null)
        //        {
        //            postGraduation.PostGraduation = orderDetails.EducationalDetail.PostGraduationDetails[0].PostGraduation;
        //            postGraduation.Specialization = orderDetails.EducationalDetail.PostGraduationDetails[0].Specialization;
        //            postGraduation.University = orderDetails.EducationalDetail.PostGraduationDetails[0].University;
        //            postGraduation.Municipality = orderDetails.EducationalDetail.PostGraduationDetails[0].Municipality;
        //            postGraduation.StateId = orderDetails.EducationalDetail.PostGraduationDetails[0].StateId;
        //            postGraduation.StartDate = orderDetails.EducationalDetail.PostGraduationDetails[0].StartDate;
        //            postGraduation.EndDate = orderDetails.EducationalDetail.PostGraduationDetails[0].EndDate;
        //            postGraduation.UserId = SessionWrapper.LoggedUser.UserId;
        //        }
        //        else
        //        {
        //            postGraduation = null;
        //        }
        //    }
        //    else
        //    {
        //        userEdu = null;
        //    }

        //    if (orderDetails.LicenseInfo != null)
        //    {
        //        userLicenseInfo.LicenseName = orderDetails.LicenseInfo.LicenseName;
        //        userLicenseInfo.LicenseNumber = orderDetails.LicenseInfo.LicenseNumber;
        //        userLicenseInfo.LicensingAgency = orderDetails.LicenseInfo.LicensingAgency;
        //        userLicenseInfo.StateId = orderDetails.LicenseInfo.StateId;
        //        userLicenseInfo.UserId = SessionWrapper.LoggedUser.UserId;
        //    }
        //    else
        //    {
        //        userLicenseInfo = null;
        //    }

        //    if (orderDetails.EmploymentDetailes != null)
        //    {
        //        foreach (EmploymentDetail emp in orderDetails.EmploymentDetailes)
        //        {
        //            empDetails = new UserEmploymentDetail();
        //            empDetails.OrgName = emp.OrgName;
        //            empDetails.City = emp.City;
        //            empDetails.StateId = emp.StateId;
        //            empDetails.Telephone = emp.Telephone;

        //            empDetails.PositionTitle = emp.PositionTitle;
        //            empDetails.StartDate = emp.StartDate;
        //            empDetails.EndDate = emp.EndDate;
        //            empDetails.Description = emp.Description;
        //            empDetails.UserId = SessionWrapper.LoggedUser.UserId;

        //            empDetailsList.Add(empDetails);
        //        }
        //    }
        //    else
        //    {
        //        empDetailsList = null;
        //    }

        //    if (orderDetails.ReferenceInfoes != null)
        //    {
        //        foreach (ReferenceInfo refrence in orderDetails.ReferenceInfoes)
        //        {
        //            userReference = new UserReferenceInfo();

        //            userReference.Name = refrence.Name;
        //            userReference.Relationship = refrence.Relationship;
        //            userReference.MobileNumber = refrence.MobileNumber;
        //            userReference.YearsKnown = refrence.YearsKnown;
        //            userReference.ReferenceTypeId = refrence.ReferenceTypeId;
        //            userReference.UserId = SessionWrapper.LoggedUser.UserId;

        //            userRefrences.Add(userReference);
        //        }
        //    }
        //    else
        //    {
        //        userRefrences = null;
        //    }
        // UserHelper.SaveUserProfileDetails(userEdu, userLicenseInfo, empDetailsList, postGraduation, userRefrences);
        //}
    }
}