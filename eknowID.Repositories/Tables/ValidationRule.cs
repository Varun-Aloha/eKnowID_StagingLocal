namespace eknowID.Repositories
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ValidationRule")]
    public partial class ValidationRule
    {
        public ValidationRule()
        {
            States = new HashSet<State>();
        }

        public int ValidationRuleId { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [StringLength(100)]
        public string RegularExpression { get; set; }

        public bool? IsSSN { get; set; }

        public bool? IsLastCharcter { get; set; }

        public virtual ICollection<State> States { get; set; }
    }
}
