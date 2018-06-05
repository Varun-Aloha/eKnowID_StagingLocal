using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eknowID.Repositories {
   
    [Table("StateCountyCourtFee")]
    public partial class StateCountyCourtFee {
        public StateCountyCourtFee() {
        }
        [Key]
        public int Id { get; set; }
        public int StateId { get; set; }

        public string County { get; set; }

        public Decimal? DistrictCourtFees { get; set; }

        public Decimal? CircuitCourtFees { get; set; }

        public Decimal? PerRecordFees { get; set; }

        public bool IsYearly { get; set; }

        public bool Deleted { get; set; }

        public virtual State State { get; set; }
    }
}
