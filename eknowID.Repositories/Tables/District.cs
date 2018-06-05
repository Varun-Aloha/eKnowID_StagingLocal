namespace eknowID.Repositories
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("District")]
    public partial class District
    {
        public int DistrictId { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        public int? StateId { get; set; }

        public virtual State State { get; set; }
    }
}
