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
    public class UserSkillHelper
    {
        public static UserSkill GetUserSkillByUserId(int UserId)
        {
            Repository<UserSkill> userSkillRepo = new Repository<UserSkill>("UserId");
            return userSkillRepo.SelectByKey(UserId.ToString());
        }

        public static UserAdditionalSkill GetAdditionalSkillById(int UserSkillId)
        {
            Repository<UserAdditionalSkill> userSkillRepo = new Repository<UserAdditionalSkill>("UserSkillId");
            return userSkillRepo.SelectByKey(UserSkillId.ToString());
        }

        public static List<UserAdditionalSkill> GetAdditionalSkillListBySkillId(int UserSkillId)
        {
            ISpecification<UserAdditionalSkill> userAdditionalSkillSpc = new Specification<UserAdditionalSkill>(u => u.UserSkillId == UserSkillId);
            Repository<UserAdditionalSkill> userAdditionalSkillRep = new Repository<UserAdditionalSkill>();
            IList<UserAdditionalSkill> userAdditionalSkillList = userAdditionalSkillRep.SelectAll(userAdditionalSkillSpc);
            return (List<UserAdditionalSkill>)userAdditionalSkillList;
        }

        public static UserLanuagesKnown GetLanguagesKnownById(int UserSkillId)
        {
            Repository<UserLanuagesKnown> userSkillRepo = new Repository<UserLanuagesKnown>("UserSkillId");
            return userSkillRepo.SelectByKey(UserSkillId.ToString());
        }

        public static List<UserLanuagesKnown> GetLanguagesKnownListBySkillId(int UserSkillId)
        {
            ISpecification<UserLanuagesKnown> userLanuagesKnownSpc = new Specification<UserLanuagesKnown>(u => u.UserSkillId == UserSkillId);
            Repository<UserLanuagesKnown> userLanuagesKnownRep = new Repository<UserLanuagesKnown>();
            IList<UserLanuagesKnown> userLanuagesKnownList = userLanuagesKnownRep.SelectAll(userLanuagesKnownSpc);
            return (List<UserLanuagesKnown>)userLanuagesKnownList;
        }

        public static UserProfileInfo SaveUserSkill(UserSkill userSkill)
        {
            //bool isAdded = false;
            UserProfileInfo userProfileInfo = new UserProfileInfo();
            try
            {
                Repository<UserSkill> userSkillRepo = new Repository<UserSkill>("UserId");
                UserSkill userSkillInfo = userSkillRepo.SelectByKey(userSkill.UserId.ToString());
                if (userSkillInfo == null)
                {
                    userSkillRepo.Add(userSkill);
                    userSkillRepo.Save();
                    userProfileInfo.IsFirstRecord = true;
                }
                else
                {
                    int count = 0;
                    userProfileInfo.IsFirstRecord = false;
                    if (userSkill.UserAdditionalSkills != null)
                    {
                        UserAdditionalSkill AdditionalSkill;
                        Repository<UserAdditionalSkill> AdditionalSkillRepository = new Repository<UserAdditionalSkill>();
                        ISpecification<UserAdditionalSkill> userAdditionalSkillSpc = new Specification<UserAdditionalSkill>(u => u.UserSkillId == userSkillInfo.UserSkillId);
                        Repository<UserAdditionalSkill> userAdditionalSkillRep = new Repository<UserAdditionalSkill>();
                        IList<UserAdditionalSkill> userAdditionalSkillList = userAdditionalSkillRep.SelectAll(userAdditionalSkillSpc);
                                             
                        while (count < userSkill.UserAdditionalSkills.Count)
                        {
                            if (count < userAdditionalSkillList.Count)
                            {
                                if (userAdditionalSkillList[count] != null)
                                {
                                    userAdditionalSkillList[count].Skill = userSkill.UserAdditionalSkills[count].Skill;
                                    userAdditionalSkillRep.Save();
                                    count++;
                                }
                            }
                            else
                            {
                                AdditionalSkill = new UserAdditionalSkill();
                                AdditionalSkill.Skill = userSkill.UserAdditionalSkills[count].Skill;
                                AdditionalSkill.UserSkillId = userSkillInfo.UserSkillId;
                                AdditionalSkillRepository.Add(AdditionalSkill);
                                AdditionalSkillRepository.Save();
                                count++;
                            }
                        }
                    }

                    if (userSkill.UserLanuagesKnowns != null)
                    {
                        UserLanuagesKnown Lanuages;
                        Repository<UserLanuagesKnown> LanuagesRepository = new Repository<UserLanuagesKnown>();
                        ISpecification<UserLanuagesKnown> userLanuagesKnownSpc = new Specification<UserLanuagesKnown>(u => u.UserSkillId == userSkillInfo.UserSkillId);
                        Repository<UserLanuagesKnown> userLanuagesKnownRep = new Repository<UserLanuagesKnown>();
                        IList<UserLanuagesKnown> userLanuagesKnownList = userLanuagesKnownRep.SelectAll(userLanuagesKnownSpc);

                        count = 0;

                        while (count < userSkill.UserLanuagesKnowns.Count)
                        {
                            if (count < userLanuagesKnownList.Count)
                            {
                                if (userLanuagesKnownList[count] != null)
                                {
                                    userLanuagesKnownList[count].Lanuage = userSkill.UserLanuagesKnowns[count].Lanuage;
                                    userLanuagesKnownRep.Save();
                                    count++;
                                }
                            }
                            else
                            {
                                Lanuages = new UserLanuagesKnown();
                                Lanuages.Lanuage = userSkill.UserLanuagesKnowns[count].Lanuage;
                                Lanuages.UserSkillId = userSkillInfo.UserSkillId;
                                LanuagesRepository.Add(Lanuages);
                                LanuagesRepository.Save();
                                count++;
                            }
                        }
                    }                   
                    //isAdded = true;
                }
            }
            catch { }
            return userProfileInfo;
        }     

        public static bool DeleteUserSkill(int AdditionalSkillId)
        {
            bool isDeleted = false;
            try
            {
                Repository<UserAdditionalSkill> repository = new Repository<UserAdditionalSkill>("AdditionalSkillId");
                UserAdditionalSkill additionalSkill = repository.SelectByKey(AdditionalSkillId.ToString());
                if (additionalSkill != null)
                {
                    repository.Delete(additionalSkill);
                    repository.Save();
                    isDeleted = true;
                }
            }
            catch { }
            return isDeleted;
        }

        public static bool DeleteUserLanuages(int UserLanuagesKnownId)
        {
            bool isDeleted = false;
            try
            {
                Repository<UserLanuagesKnown> repository = new Repository<UserLanuagesKnown>("UserLanuagesKnownId");
                UserLanuagesKnown lanuagesKnown = repository.SelectByKey(UserLanuagesKnownId.ToString());
                if (lanuagesKnown != null)
                {
                    repository.Delete(lanuagesKnown);
                    repository.Save();
                    isDeleted = true;
                }
            }
            catch { }
            return isDeleted;
        }

        public static List<int>[] GetSkillIdList(int UserId)
        {
            List<int>[] ids = new List<int>[2];
            Repository<UserSkill> repository = new Repository<UserSkill>("UserId");
            int userskillid = repository.SelectByKey(UserId.ToString()).UserSkillId;

            List<int> skillid = new List<int>(); ;
            ISpecification<UserAdditionalSkill> specification = new Specification<UserAdditionalSkill>(u => u.UserSkillId == userskillid);
            Repository<UserAdditionalSkill> repositoryskill = new Repository<UserAdditionalSkill>();
            IList<UserAdditionalSkill> list = repositoryskill.SelectAll(specification);

            if (list != null)
            {
                foreach (UserAdditionalSkill additionalSkill in list)
                {
                    skillid.Add(additionalSkill.AdditionalSkillId);
                }
            }

            List<int> languagesKnownId = new List<int>(); ;
            ISpecification<UserLanuagesKnown> specificationLanguage = new Specification<UserLanuagesKnown>(u => u.UserSkillId == userskillid);
            Repository<UserLanuagesKnown> repositoryLanguage = new Repository<UserLanuagesKnown>();
            IList<UserLanuagesKnown> listLanguages = repositoryLanguage.SelectAll(specificationLanguage);

            if (listLanguages != null)
            {
                foreach (UserLanuagesKnown languagesKnown in listLanguages)
                {
                    languagesKnownId.Add(languagesKnown.UserLanuagesKnownId);
                }
            }

            ids[0] = skillid;
            ids[1] = languagesKnownId;

            return ids;
        }
    }
}
