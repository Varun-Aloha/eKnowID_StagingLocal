namespace eknowID.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Company")]
    public partial class Company
    {
        public Company()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string CompanyPhone { get; set; }

        [StringLength(50)]
        public string CompanyTaxId { get; set; }

        public string Description { get; set; }

        [StringLength(100)]
        public string JobTitle { get; set; }

        public DateTime? CreatedOn { get; set; }

        public bool IsCreditReportAuditingChargesPaid { get; set; }

        public bool IsEligibleForCreditReportScreening { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
