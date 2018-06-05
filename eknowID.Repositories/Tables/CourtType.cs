namespace eknowID.Repositories
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CourtType")]
    public partial class CourtType
    {
        public CourtType()
        {
            CourtLocations = new HashSet<CourtLocation>();
        }

        public int CourtTypeId { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        public virtual ICollection<CourtLocation> CourtLocations { get; set; }
    }
}
