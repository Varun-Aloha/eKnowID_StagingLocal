namespace eknowID.Repositories
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("City")]
    public partial class City
    {
        public City()
        {
            CourtLocations = new HashSet<CourtLocation>();
        }

        public int CityId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Zip { get; set; }

        public virtual ICollection<CourtLocation> CourtLocations { get; set; }
    }
}
