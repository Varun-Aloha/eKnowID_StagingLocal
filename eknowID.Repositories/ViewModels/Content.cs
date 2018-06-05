using System;
using System.Collections.Generic;

namespace Wrapper.Model
{
    public class AssessmentRequester
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class AssessmentCandidate
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AddressLine { get; set; }
    }

    public class Industry
    {
        public string Id { get; set; }
        public string Label { get; set; }
    }

    public class Function
    {
        public string Id { get; set; }
        public string Label { get; set; }
    }

    public class ExperienceLevel
    {
        public string Id { get; set; }
        public string Label { get; set; }
    }

    public class Location
    {
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
    }

    public class Job
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Industry Industry { get; set; }
        public Function Function { get; set; }
        public ExperienceLevel ExperienceLevel { get; set; }
        public Location Location { get; set; }
    }

    public class AssessmentCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Offer
    {
        public string CatalogId { get; set; }
        public string Name { get; set; }
    }

    public class AlacarteReport
    {
        public List<AlacarteReportDetails> ReportDetails { get; set; }
    }

    public class AlacarteReportDetails {
        public string ReportName { get; set; }
        public int Qty { get; set; }

        public string StatesSelected { get; set; }
        public string Counties_DistrictsSelected { get; set; }
    }

    public class Content
    {
        public Guid Id { get; set; }
        public string Status { get; set; }

        public AlacarteReport alacarteReport { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public AssessmentRequester Requestor { get; set; }
        public AssessmentCandidate Candidate { get; set; }
        public Job Job { get; set; }
        public AssessmentCompany Company { get; set; }
        public Offer Offer { get; set; }
        public string WrapperPartnerId { get; set; }
    }

    public class AssessmentList
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
        public int TotalFound { get; set; }
        public IList<Content> Content { get; set; }
    }
}