using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eknowID.Repositories {
        
    [Table("StateDistrictCourtFee")]
    public partial class StateDistrictCourtFee {
        public StateDistrictCourtFee() {
        }
        [Key]
        public int Id { get; set; }
        public int StateId { get; set; }

        public string DistrictCourt { get; set; }

        public bool Deleted { get; set; }

        public Decimal? DistrictCourtFees { get; set; }

        public virtual State State { get; set; }
    }
}
