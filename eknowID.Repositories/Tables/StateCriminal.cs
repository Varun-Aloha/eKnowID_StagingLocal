namespace eknowID.Repositories {
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("StateCriminalCourtFee")]
    public partial class StateCriminalCourtFee {
        public StateCriminalCourtFee() {            
        }

        public int StateId { get; set; }
        public string Name { get; set; }
        public string Availability { get; set; }
        public decimal? Fee { get; set; }
        public string TurnAroundTime { get; set; }
        public string AlphaCode { get; set; }

        public bool Deleted { get; set; }
    }
}
