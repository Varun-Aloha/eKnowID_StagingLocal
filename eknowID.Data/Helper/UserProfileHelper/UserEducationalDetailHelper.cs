using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EknowIDModel;
using EknowIDModel.UserProfile;
using EknowIDData.Implementations;
using EknowIDData.Helper.UserProfileHelper;

namespace EknowIDData.Helper
{
    public class UserEducationalDetailHelper
    {
        public static UserEducationalDetail GetUserEducationalDetailByUserId(int UserId)
        {
            Repository<UserEducationalDetail> educationRepository = new Repository<UserEducationalDetail>("UserId");
            return educationRepository.SelectByKey(UserId.ToString());
        }

        public static UserPostGraduation GetUserPostGraduationDetailByUserId(int UserId)
        {
            Repository<UserPostGraduation> repository = new Repository<UserPostGraduation>("UserId");
            return repository.SelectByKey(UserId.ToString());
        }

        //Save or Update UserEducationDetail
        public static UserProfileInfo SaveUserEducationDetail(UserEducationalDetail userEducationDetails)
        {
            //bool isAdded = false;
            UserProfileInfo userProfileInfo = new UserProfileInfo();
            try
            {
                Repository<UserEducationalDetail> userEducation = new Repository<UserEducationalDetail>("UserId");
                UserEducationalDetail educationalDetail = userEducation.SelectByKey(userEducationDetails.UserId.ToString());
                if (educationalDetail == null)
                {
                    userEducation.Add(userEducationDetails);
                    userProfileInfo.IsFirstRecord = true;
                }
                else
                {
                    educationalDetail.Basic = userEducationDetails.Basic;
                    educationalDetail.Specialization = userEducationDetails.Specialization;                   
                    educationalDetail.University = userEducationDetails.University;

                    educationalDetail.StartMonth = userEducationDetails.StartMonth;
                    educationalDetail.StartYear = userEducationDetails.StartYear; ;
                    educationalDetail.EndMonth = userEducationDetails.EndMonth;
                    educationalDetail.EndYear = userEducationDetails.EndYear;
                    educationalDetail.StateId = userEducationDetails.StateId;
                    educationalDetail.Municipality = userEducationDetails.Municipality;
                    educationalDetail.IsAttending = userEducationDetails.IsAttending;
                    userProfileInfo.IsFirstRecord = false;
                }
                userEducation.Save();
                
                //isAdded = true;
            }
            catch { }
            return userProfileInfo;
        }

        public static UserProfileInfo SaveUserPostGraduation(UserPostGraduation UserPostGraduation)
        {            
            UserProfileInfo userProfileInfo = new UserProfileInfo();
            try
            {
                Repository<UserPostGraduation> repository = new Repository<UserPostGraduation>("UserId");
                UserPostGraduation userPost = repository.SelectByKey(UserPostGraduation.UserId.ToString());
                if (userPost == null)
                {
                    repository.Add(UserPostGraduation);
                    userProfileInfo.IsFirstRecord = true;
                }
                else
                {
                    userPost.PostGraduation = UserPostGraduation.PostGraduation;
                    userPost.Specialization = UserPostGraduation.Specialization;
                    userPost.University = UserPostGraduation.University;
                    userPost.Municipality = UserPostGraduation.Municipality;
                    userPost.StateId = UserPostGraduation.StateId;

                    userPost.StartMonth = UserPostGraduation.StartMonth;
                    userPost.StartYear = UserPostGraduation.StartYear; ;
                    userPost.EndMonth = UserPostGraduation.EndMonth;
                    userPost.EndYear = UserPostGraduation.EndYear;

                    userPost.IsAttending = UserPostGraduation.IsAttending;
                    userPost.UserId = UserPostGraduation.UserId;
                    userProfileInfo.IsFirstRecord = false;
                 
                }
                repository.Save();                
            }
            catch { }
            return userProfileInfo;
        }

        public static bool DeletePostGradById(int PostGraduationId)
        {
            bool isDeleted = false;
            try
            {
                Repository<UserPostGraduation> repository = new Repository<UserPostGraduation>("UserPostGraduationId");
                UserPostGraduation postGraduation = repository.SelectByKey(PostGraduationId.ToString());

                if (postGraduation != null)
                {
                    repository.Delete(postGraduation);
                    repository.Save();
                    isDeleted = true;
                }
            }
            catch { }
            return isDeleted;
        }

        public static int GetPostGraduationId(int UserId)
        {
            Repository<UserPostGraduation> repository = new Repository<UserPostGraduation>("UserId");
            return  repository.SelectByKey(UserId.ToString()).UserPostGraduationId;
        }
    }
}
