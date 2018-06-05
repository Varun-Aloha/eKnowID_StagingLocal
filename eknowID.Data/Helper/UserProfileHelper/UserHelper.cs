using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EknowIDModel;
using EknowIDModel.UserProfile;
using EknowIDData.Implementations;
using eknowID.Model;
using EknowIDData.Interfaces;

namespace EknowIDData.Helper.UserProfileHelper
{
    public class UserHelper
    {
        public static User GetUserById(int UserId)
        {
            Repository<User> UserRepository = new Repository<User>("UserId");
            return UserRepository.SelectByKey(UserId.ToString());
        }       


        public static User GetUserByOrderId(int OrderId)
        {
            Repository<Order> orderRepo = new Repository<Order>("OrderId");
            Order order = orderRepo.SelectByKey(OrderId.ToString());
            User user = GetUserById(order.UserId);

            return user;
        }

        public static Candidate GetCandidateByOrderId(int orderid) {
            ISpecification<Candidate> candidateStSpc = new Specification<Candidate>(c => c.OrderId == orderid);
            IRepository<Candidate> candidateState = new Repository<Candidate>();
            Candidate candidate = candidateState.SelectAll(candidateStSpc).FirstOrDefault();
            return candidate;
        }


        //public static void SaveUserProfileDetails(UserEducationalDetail UserEducation, UserLicenseInfo UserLicense, List<UserEmploymentDetail> UserEmpDetails,UserPostGraduation UserPostGraduation, List<UserReferenceInfo> UserReferences)
        //{
        //    if (UserEducation != null)
        //    {
        //        UserEducationalDetailHelper.SaveUserEducationDetail(UserEducation);
        //    }

        //    if (UserEmpDetails != null)
        //    {
        //        UserEmploymentDetailsHelper.SaveUserEmpDetails(UserEmpDetails);
        //    }

        //    if (UserLicense != null)
        //    {
        //        UserLicenseInfoHelper.SaveUserLicenseInfo(UserLicense);
        //    }

        //    if (UserReferences != null)
        //    {
        //        UserReferenceInfoHelper.SaveUserReferenceInfo(UserReferences);
        //    }          
        //    if (UserPostGraduation != null)
        //    {
        //        UserEducationalDetailHelper.SaveUserPostGraduation(UserPostGraduation);
        //    }
        //}

        public static bool UpdateUserDetails(User user)
        {
            bool isUpdated = false;
            try
            {
                Repository<User> UserRepository = new Repository<User>("UserId");
                User userobj = UserRepository.SelectByKey(user.UserId.ToString());
                if (userobj != null)
                {
                    userobj.FirstName = user.FirstName;
                    userobj.MiddleName = user.MiddleName;
                    userobj.LastName = user.LastName;
                    userobj.Email = user.Email;
                    userobj.CellPhone = user.CellPhone;
                    userobj.IdentificationValue = user.IdentificationValue;
                    userobj.Gender = user.Gender;
                    userobj.Birthday = user.Birthday;

                    if (!string.IsNullOrEmpty(user.Password))
                    {
                        userobj.Password = user.Password;
                    }

                    userobj.Address1 = user.Address1;
                    userobj.Address2 = user.Address2;
                    userobj.City = user.City;
                    userobj.StateId = user.StateId;
                    userobj.Zip = user.Zip;

                    UserRepository.Save();
                    isUpdated = true;
                }
            }
            catch { }
            return isUpdated;
        }
    }
}
