using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EknowIDModel
{
    public class UserSkill
    {
        public int UserSkillId
        {
            get;
            set;
        }
        public int UserId
        {
            get;
            set;
        }
        public User User
        {
            get;
            set;
        }

        public virtual List<UserAdditionalSkill> UserAdditionalSkills
        {
            get;
            set;
        }

        public virtual List<UserLanuagesKnown> UserLanuagesKnowns
        {
            get;
            set;
        }     
    }
}
