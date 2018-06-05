using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EknowIDModel
{
    public class UserLanuagesKnown
    {
        public int UserLanuagesKnownId
        {
            get;
            set;
        }
        public int UserSkillId
        {
            get;
            set;
        }
        public string Lanuage
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
