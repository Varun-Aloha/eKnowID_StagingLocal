using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EknowIDModel;
using EknowIDData.Implementations;
using EknowIDData.Interfaces;
using EknowIDData.Helper.UserProfileHelper;

namespace EknowIDData.Helper
{
    public class UserReferenceInfoHelper
    {     
            

        //public static UserReferenceInfo GetReferenceInfoById(int UserSkillId)
        //{
        //    Repository<UserReferenceInfo> userSkillRepo = new Repository<UserReferenceInfo>("UserSkillId");
        //    return userSkillRepo.SelectByKey(UserSkillId.ToString());
        //}
       
        public static List<UserReferenceInfo> GetReferenceInfoListBySkillId(int UserId)
        {
            ISpecification<UserReferenceInfo> userReferenceInfoSpc = new Specification<UserReferenceInfo>(u => u.UserId == UserId);
            Repository<UserReferenceInfo> userReferenceInfoRep = new Repository<UserReferenceInfo>();
            IList<UserReferenceInfo> userReferenceInfoList = userReferenceInfoRep.SelectAll(userReferenceInfoSpc);
            return (List<UserReferenceInfo>)userReferenceInfoList;
        }

        public static UserProfileInfo SaveUserReferenceInfo(List<UserReferenceInfo> UserReferences)
        {
            //bool isAdded = false;
            UserProfileInfo userProfileInfo = new UserProfileInfo();
            try
            {      
                int count = 0;                
                
                if (UserReferences != null)
                    {
                        int userId = UserReferences[0].UserId;
                        UserReferenceInfo ReferenceInfo;
                        Repository<UserReferenceInfo> ReferenceInfoRepository = new Repository<UserReferenceInfo>();
                        ISpecification<UserReferenceInfo> userReferenceSpc = new Specification<UserReferenceInfo>(u => u.UserId == userId);
                        Repository<UserReferenceInfo> userReferenceRep = new Repository<UserReferenceInfo>();
                        IList<UserReferenceInfo> userReferenceList = userReferenceRep.SelectAll(userReferenceSpc);

                        if (userReferenceList.Count == 0)
                            userProfileInfo.IsFirstRecord = true;
                        else
                            userProfileInfo.IsFirstRecord = false;

                        while (count < UserReferences.Count)
                        {
                            if (count < userReferenceList.Count)
                            {
                                if (userReferenceList[count] != null)
                                {
                                    userReferenceList[count].Name = UserReferences[count].Name;
                                    userReferenceList[count].MobileNumber = UserReferences[count].MobileNumber;
                                    userReferenceList[count].YearsKnown = UserReferences[count].YearsKnown;
                                    userReferenceList[count].Relationship = UserReferences[count].Relationship;
                                    userReferenceList[count].ReferenceTypeId = UserReferences[count].ReferenceTypeId;
                                    userReferenceRep.Save();
                                    count++;
                                }
                            }
                            else
                            {
                                ReferenceInfo = new UserReferenceInfo();
                                ReferenceInfo.Name = UserReferences[count].Name;
                                ReferenceInfo.MobileNumber = UserReferences[count].MobileNumber;
                                ReferenceInfo.YearsKnown = UserReferences[count].YearsKnown;
                                ReferenceInfo.Relationship = UserReferences[count].Relationship;
                                ReferenceInfo.ReferenceTypeId = UserReferences[count].ReferenceTypeId;
                                ReferenceInfo.UserId = UserReferences[count].UserId;
                                ReferenceInfoRepository.Add(ReferenceInfo);
                                ReferenceInfoRepository.Save();
                                count++;
                            }
                        }
                    }
                    //isAdded = true;
                }          
            catch { }
            return userProfileInfo;
        }

        public static bool DeleteUserReference(int ReferenceId)
        {
            bool isDeleted = false;
            try
            {
                Repository<UserReferenceInfo> repository = new Repository<UserReferenceInfo>("UserReferenceInfoId");
                UserReferenceInfo userRef = repository.SelectByKey(ReferenceId.ToString());
                if (userRef != null)
                {
                    repository.Delete(userRef);
                    repository.Save();
                    isDeleted = true;
                }
            }
            catch { }
            return isDeleted;
        }

        public static List<int> GetReferenceIdList(int UserId)
        {
            List<int> referenceIds = new List<int>();;
            ISpecification<UserReferenceInfo> userReferenceInfoSpc = new Specification<UserReferenceInfo>(u => u.UserId == UserId);
            Repository<UserReferenceInfo> userReferenceInfoRep = new Repository<UserReferenceInfo>();
            IList<UserReferenceInfo> userReferenceInfoList = userReferenceInfoRep.SelectAll(userReferenceInfoSpc);

            if (userReferenceInfoList != null)
            {              
                foreach (UserReferenceInfo userRef in userReferenceInfoList)
                {
                    referenceIds.Add(userRef.UserReferenceInfoId);
                }
            }

            return referenceIds;
        }
    }
}
