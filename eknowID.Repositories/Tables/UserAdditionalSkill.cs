namespace eknowID.Repositories
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("UserAdditionalSkill")]
    public partial class UserAdditionalSkill
    {
        [Key]
        public int AdditionalSkillId { get; set; }

        public int? UserSkillId { get; set; }

        [StringLength(100)]
        public string Skill { get; set; }

        public virtual UserSkill UserSkill { get; set; }
    }
}
