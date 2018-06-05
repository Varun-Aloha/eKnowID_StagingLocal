using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eknowID.Model.Requester
{    
    public class RequesterProfileViewModel
    {
        //public CandidateViewModel CandidateViewModel { get; set; }
        //public RequesterViewModel RequesterViewModel { get; set; }
        //public CompayViewModel CompayViewModel { get; set; }
    }

    //public class CandidateViewModel
    //{
    //    public string CandidateFirstName { get; set; }
    //    public string CandidateLastName { get; set; }
    //    public string CandidateEmail { get; set; }
    //    public string CandidateDescription { get; set; }
    //    public bool IsEmailSendFlag { get; set; }
    //}

    public class RequesterViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string JobTitle { get; set; }
        public string SecurityPIN { get; set; }
        public bool IsCustomer { get; set; }               
    }
    //public class CompayViewModel
    //{
    //    public string CompanyName { get; set; }
    //    public string CompanyPhone { get; set; }
    //    public string CompanyTaxId { get; set; }
    //    public string State { get; set; }
    //    public string Description { get; set; }
    //}
}
