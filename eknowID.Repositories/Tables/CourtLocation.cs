namespace eknowID.Repositories
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CourtLocation")]
    public partial class CourtLocation
    {
        public int CourtLocationId { get; set; }

        [StringLength(50)]
        public string OfficeName { get; set; }

        public int? CityId { get; set; }

        public int? CourtTypeId { get; set; }

        public int? StateId { get; set; }

        public virtual City City { get; set; }

        public virtual CourtType CourtType { get; set; }

        public virtual State State { get; set; }
    }
}
