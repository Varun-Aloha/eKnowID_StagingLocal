using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EknowIDModel
{
    public class UserAdditionalSkill
    {
        public int AdditionalSkillId
        {
            get;
            set;
        }
        public int UserSkillId
        {
            get;
            set;
        }
        public string Skill
        {
            get;
            set;
        }
        public virtual UserSkill UserSkill
        {
            get;
            set;
        }

    }
}
