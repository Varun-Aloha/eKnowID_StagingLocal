namespace eknowID.Repositories
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("UserSkill")]
    public partial class UserSkill
    {
        public UserSkill()
        {
            UserAdditionalSkills = new HashSet<UserAdditionalSkill>();
            UserLanuagesKnowns = new HashSet<UserLanuagesKnown>();
        }

        public int UserSkillId { get; set; }

        public int? UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<UserAdditionalSkill> UserAdditionalSkills { get; set; }

        public virtual ICollection<UserLanuagesKnown> UserLanuagesKnowns { get; set; }
    }
}
