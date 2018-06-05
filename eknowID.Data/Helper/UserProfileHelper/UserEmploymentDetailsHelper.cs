using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EknowIDModel;
using EknowIDModel.UserProfile;
using EknowIDData.Implementations;
using EknowIDData.Interfaces;
using EknowIDData.Helper.UserProfileHelper;

namespace EknowIDData.Helper
{
    public class UserEmploymentDetailsHelper
    {
        public static bool DeleteEmpDetailsById(int EmpDetailsId)
        {
            bool isDeleted = false;
            try
            {

                Repository<UserEmploymentDetail> repository = new Repository<UserEmploymentDetail>("UserEmploymentDetailId");
                UserEmploymentDetail empDetails = repository.SelectByKey(EmpDetailsId.ToString());

                if (empDetails != null)
                {
                    repository.Delete(empDetails);
                    repository.Save();
                    isDeleted = true;
                }
            }
            catch { }
            return isDeleted;
        }

        public static List<UserEmploymentDetail> GetEmploymentDetailsListByUserId(int UserId)
        {
            ISpecification<UserEmploymentDetail> specification = new Specification<UserEmploymentDetail>(u => u.UserId == UserId);
            Repository<UserEmploymentDetail> repository = new Repository<UserEmploymentDetail>();
            IList<UserEmploymentDetail> empDetailsList = repository.SelectAll(specification);
            return (List<UserEmploymentDetail>)empDetailsList;

        }

        public static UserProfileInfo SaveUserEmpDetails(List<UserEmploymentDetail> UserEmpDetail)
        {
            //bool isSaved = false;
            Repository<UserEmploymentDetail> EmpDetailNewRepository = new Repository<UserEmploymentDetail>();
            UserEmploymentDetail userEmpdetails;

            int userId = UserEmpDetail[0].UserId;
            ISpecification<UserEmploymentDetail> specification = new Specification<UserEmploymentDetail>(u => u.UserId == userId);
            Repository<UserEmploymentDetail> repository = new Repository<UserEmploymentDetail>();
            IList<UserEmploymentDetail> empDetailList = repository.SelectAll(specification);
            UserProfileInfo userProfileInfo = new UserProfileInfo();

            if (empDetailList.Count == 0)          
                userProfileInfo.IsFirstRecord = true;
            else
                userProfileInfo.IsFirstRecord = false;

            try
            {
                int count = 0;
                while (count < UserEmpDetail.Count)
                {
                    if (count < empDetailList.Count)
                    {
                        empDetailList[count].OrgName = UserEmpDetail[count].OrgName;
                        empDetailList[count].City = UserEmpDetail[count].City;
                        empDetailList[count].StateId = UserEmpDetail[count].StateId;
                        empDetailList[count].Telephone = UserEmpDetail[count].Telephone;
                        empDetailList[count].PositionTitle = UserEmpDetail[count].PositionTitle;                     

                        empDetailList[count].StartMonth = UserEmpDetail[count].StartMonth;
                        empDetailList[count].StartYear = UserEmpDetail[count].StartYear;
                        empDetailList[count].EndMonth = UserEmpDetail[count].EndMonth;
                        empDetailList[count].EndYear = UserEmpDetail[count].EndYear;

                        
                        empDetailList[count].Description = UserEmpDetail[count].Description;
                        empDetailList[count].IsAttending = UserEmpDetail[count].IsAttending;

                        repository.Save();
                        count++;
                    }
                    else
                    {
                        userEmpdetails = new UserEmploymentDetail();

                        userEmpdetails.OrgName = UserEmpDetail[count].OrgName;
                        userEmpdetails.City = UserEmpDetail[count].City;
                        userEmpdetails.StateId = UserEmpDetail[count].StateId;
                        userEmpdetails.Telephone = UserEmpDetail[count].Telephone;
                        userEmpdetails.PositionTitle = UserEmpDetail[count].PositionTitle;                     

                        userEmpdetails.StartMonth = UserEmpDetail[count].StartMonth;
                        userEmpdetails.StartYear = UserEmpDetail[count].StartYear;
                        userEmpdetails.EndMonth = UserEmpDetail[count].EndMonth;
                        userEmpdetails.EndYear = UserEmpDetail[count].EndYear;                       

                        userEmpdetails.Description = UserEmpDetail[count].Description;
                        userEmpdetails.IsAttending = UserEmpDetail[count].IsAttending;
                        userEmpdetails.UserId = UserEmpDetail[count].UserId;

                        EmpDetailNewRepository.Add(userEmpdetails);
                        EmpDetailNewRepository.Save();
                        count++;
                    }
                }

                //isSaved = true;
            }
            catch { }

            return userProfileInfo;
        }


        public static List<int> GetProfessionalIdList(int UserId)
        {
            List<int> empIds = new List<int>(); ;
            ISpecification<UserEmploymentDetail> specification = new Specification<UserEmploymentDetail>(u => u.UserId == UserId);
            Repository<UserEmploymentDetail> repository = new Repository<UserEmploymentDetail>();
            IList<UserEmploymentDetail> list = repository.SelectAll(specification);

            if (list != null)
            {
                foreach (UserEmploymentDetail empdetail in list)
                {
                    empIds.Add(empdetail.UserEmploymentDetailId);
                }
            }

            return empIds;
        }
    }
}
