using EknowIDModel;
using System;
using System.Collections.Generic;

namespace eknowID.Model
{
    public class Company
    {
        public Company()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string CompanyPhone { get; set; }

        public string CompanyTaxId { get; set; }

        public string State { get; set; }

        public string JobTitle { get; set; }

        public string Description { get; set; }

        public DateTime? CreatedOn { get; set; }

        public bool IsCreditReportAuditingChargesPaid { get; set; }

        public bool IsEligibleForCreditReportScreening { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
