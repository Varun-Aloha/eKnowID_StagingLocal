namespace eknowID.Repositories
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ReferenceType")]
    public partial class ReferenceType
    {
        public ReferenceType()
        {
            ReferenceInfoes = new HashSet<ReferenceInfo>();
            UserReferenceInfoes = new HashSet<UserReferenceInfo>();
        }

        public int ReferenceTypeId { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public virtual ICollection<ReferenceInfo> ReferenceInfoes { get; set; }

        public virtual ICollection<UserReferenceInfo> UserReferenceInfoes { get; set; }
    }
}
