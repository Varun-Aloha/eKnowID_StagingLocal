namespace eknowID.Repositories
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("UserLanuagesKnown")]
    public partial class UserLanuagesKnown
    {
        public int UserLanuagesKnownId { get; set; }

        public int? UserSkillId { get; set; }

        [StringLength(50)]
        public string Lanuage { get; set; }

        public virtual UserSkill UserSkill { get; set; }
    }
}
