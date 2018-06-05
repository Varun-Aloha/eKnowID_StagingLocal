using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EknowIDData.Helper.ResumeParser
{
    public class Error {
        public int errorcode { get; set; }
        public string errormsg { get; set; }
    }
    public class ErrorClass {
        public Error error { get; set; }
    }
    public class WebSite {
        public string Type { get; set; }
        public string Url { get; set; }
    }

    public class WebSites {
        public List<WebSite> WebSite { get; set; }
    }

    public class Institution {
        public string Name { get; set; }
        public string Type { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }

    public class SubInstitution {
        public string Name { get; set; }
        public string Type { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }

    public class Aggregate {
        public string Value { get; set; }
        public string MeasureType { get; set; }
    }

    public class EducationSplit {
        public Institution Institution { get; set; }
        public SubInstitution SubInstitution { get; set; }
        public string Degree { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public Aggregate Aggregate { get; set; }
    }

    public class SegregatedQualification {
        public List<EducationSplit> EducationSplit { get; set; }
    }

    public class SkillSet {
        public string Skill { get; set; }
        public string Type { get; set; }
        public string Alias { get; set; }
        public string FormattedName { get; set; }
        public string Evidence { get; set; }
        public string LastUsed { get; set; }
        public string ExperienceInMonths { get; set; }
    }

    public class SkillKeywords {
        public List<SkillSet> SkillSet { get; set; }
    }

    public class JobProfile {
        public string Title { get; set; }
        public object FormattedName { get; set; }
        public object Alias { get; set; }
        public string RelatedSkills { get; set; }
    }

    public class JobLocation {
        public string EmployerCity { get; set; }
        public string EmployerState { get; set; }
        public string EmployerCountry { get; set; }
        public string IsoCountry { get; set; }
    }

    public class Project {
        public string UsedSkills { get; set; }
        public string ProjectName { get; set; }
        public string TeamSize { get; set; }
    }

    public class WorkHistory {
        public string Employer { get; set; }
        public JobProfile JobProfile { get; set; }
        public JobLocation JobLocation { get; set; }
        public string JobPeriod { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string JobDescription { get; set; }
        public List<Project> Projects { get; set; }
    }

    public class SegregatedExperience {
        public List<WorkHistory> WorkHistory { get; set; }
    }

    public class WorkedPeriod {
        public string TotalExperienceInMonths { get; set; }
        public string TotalExperienceInYear { get; set; }
        public string TotalExperienceRange { get; set; }
    }

    public class EmailInfo {
        public string EmailTo { get; set; }
        public string EmailBody { get; set; }
        public string EmailReplyTo { get; set; }
        public string EmailSignature { get; set; }
        public string EmailFrom { get; set; }
        public string EmailSubject { get; set; }
        public string EmailCC { get; set; }
    }

    public class Recomendation {
        public string CompanyName { get; set; }
        public string PersonName { get; set; }
        public string Relation { get; set; }
        public string PositionTitle { get; set; }
        public string Description { get; set; }
    }

    public class Recommendations {
        public Recomendation Recomendation { get; set; }
    }

    public class CandidateImage {
        public string CandidateImageData { get; set; }
        public string CandidateImageFormat { get; set; }
    }

    public class TemplateOutput {
        public string TemplateOutputFileName { get; set; }
        public string TemplateOutputData { get; set; }
    }

    public class ResumeParserData {
        public string ResumeFileName { get; set; }
        public string ResumeLanguage { get; set; }
        public string ParsingDate { get; set; }
        public string FullName { get; set; }
        public string TitleName { get; set; }
        public string FirstName { get; set; }
        public string Middlename { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string MaritalStatus { get; set; }
        public string Nationality { get; set; }
        public string LanguageKnown { get; set; }
        public string UniqueID { get; set; }
        public string LicenseNo { get; set; }
        public string PassportNo { get; set; }
        public string PanNo { get; set; }
        public string VisaStatus { get; set; }
        public string Email { get; set; }
        public string AlternateEmail { get; set; }
        public string Phone { get; set; }
        public string FormattedPhone { get; set; }
        public string Mobile { get; set; }
        public string FormattedMobile { get; set; }
        public string FaxNo { get; set; }
        public WebSites WebSites { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string FormattedAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string PermanentCity { get; set; }
        public string PermanentState { get; set; }
        public string PermanentCountry { get; set; }
        public string PermanentZipCode { get; set; }
        public string FormattedPermanentAddress { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string CurrentSalary { get; set; }
        public string ExpectedSalary { get; set; }
        public string Qualification { get; set; }
        public SegregatedQualification SegregatedQualification { get; set; }
        public string Skills { get; set; }
        public SkillKeywords SkillKeywords { get; set; }
        public string Experience { get; set; }
        public SegregatedExperience SegregatedExperience { get; set; }
        public string CurrentEmployer { get; set; }
        public string JobProfile { get; set; }
        public WorkedPeriod WorkedPeriod { get; set; }
        public string GapPeriod { get; set; }
        public string AverageStay { get; set; }
        public string LongestStay { get; set; }
        public string Summary { get; set; }
        public string ExecutiveSummary { get; set; }
        public string ManagementSummary { get; set; }
        public string Coverletter { get; set; }
        public string Certification { get; set; }
        public string Publication { get; set; }
        public string CurrentLocation { get; set; }
        public string PreferredLocation { get; set; }
        public string Availability { get; set; }
        public string Hobbies { get; set; }
        public string Objectives { get; set; }
        public string Achievements { get; set; }
        public string References { get; set; }
        public string CustomFields { get; set; }
        public EmailInfo EmailInfo { get; set; }
        public Recommendations Recommendations { get; set; }
        public string DetailResume { get; set; }
        public string HtmlResume { get; set; }
        public CandidateImage CandidateImage { get; set; }
        public TemplateOutput TemplateOutput { get; set; }
        public string Platform { get; set; }
    }

    public class ResumeParserMapFields {
        public ResumeParserData ResumeParserData { get; set; }
    }




    //[System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    //public class ResumeParserData
    //{

    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string ResumeFileName { get; set; }
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string ParsingDate { get; set; }
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string TitleName { get; set; }
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string FirstName { get; set; }
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string Middlename { get; set; }
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string LastName { get; set; }
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string Email { get; set; }
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string Phone { get; set; }
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string Mobile { get; set; }
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string FaxNo { get; set; }
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string LicenseNo { get; set; }
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string PassportNo { get; set; }
    //    //<!--Visa Status will be provided in future release-->
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string VisaStatus { get; set; }
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string Address { get; set; }
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string City { get; set; }
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string State { get; set; }
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string ZipCode { get; set; }
    //    //<!--PermanentAddress  will be provided in future release-->
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string PermanentAddress { get; set; }
    //    //<!--PermanentCity  will be provided in future release-->
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string PermanentCity { get; set; }
    //    //<!--PermanentState  will be provided in future release-->
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string PermanentState { get; set; }
    //    //<!--PermanentZipCode  will be provided in future release-->
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string PermanentZipCode { get; set; }
    //    //<!--CorrespondenceAddress  will be provided in future release-->
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string CorrespondenceAddress { get; set; }
    //    //<!--CorrespondenceCity  will be provided in future release-->
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string CorrespondenceCity { get; set; }
    //    //<!--CorrespondenceState  will be provided in future release-->
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string CorrespondenceState { get; set; }
    //    //<!--CorrespondenceZipCode  will be provided in future release-->
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string CorrespondenceZipCode { get; set; }
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string Category { get; set; }
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string SubCategory { get; set; }
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string DateOfBirth { get; set; }
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string Gender { get; set; }
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string FatherName { get; set; }
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string MotherName { get; set; }
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string MaritalStatus { get; set; }
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string Nationality { get; set; }
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string CurrentSalary { get; set; }
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string ExpectedSalary { get; set; }
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string Qualification { get; set; }

    //    [System.Xml.Serialization.XmlElementAttribute("SegrigatedQualification", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public SegrigatedQualification SegrigatedQualification
    //    {
    //        get;
    //        set;
    //    }


    //    //<SegrigatedQualification>
    //    //  <EducationSplit>
    //    //    <University><![CDATA[Kellstadt Graduate School of Business  to be expected]]></University>
    //    //    <Degree><![CDATA[Master of Science in Marketing Analysis]]></Degree>
    //    //    <Year><![CDATA[2013]]></Year>
    //    //  </EducationSplit>
    //    //  <EducationSplit>
    //    //    <University><![CDATA[Shanghai Finance University]]></University>
    //    //    <Degree><![CDATA[Bachelor Degree in Finance]]></Degree>
    //    //    <Year><![CDATA[2007]]></Year>
    //    //  </EducationSplit>
    //    //</SegrigatedQualification>
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string Skills { get; set; }
    //    //<SkillsKeywords>
    //    //  <BehaviorSkills><![CDATA[]]></BehaviorSkills>
    //    //  <SoftSkills><![CDATA[]]></SoftSkills>
    //    //  <OperationalSkills>
    //    //    <SkillSet>
    //    //      <Skill />
    //    //      <ExperienceInMonths />
    //    //    </SkillSet>
    //    //  </OperationalSkills>
    //    //</SkillsKeywords>
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string LanguageKnown { get; set; }
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string Experience { get; set; }

    //    [System.Xml.Serialization.XmlElementAttribute("SegrigatedExperience", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public SegrigatedExperience SegrigatedExperience
    //    {
    //        get;
    //        set;
    //    }
    //    //<SegrigatedExperience>
    //    //  <WorkHistory>
    //    //    <Employer><![CDATA[]]></Employer>
    //    //    <JobProfile><![CDATA[Account Executive]]></JobProfile>
    //    //    <JobLocation><![CDATA[Shanghai]]></JobLocation>
    //    //    <JobPeriod><![CDATA[07/2011-08/2011]]></JobPeriod>
    //    //    <StartDate><![CDATA[1/07/2011]]></StartDate>
    //    //    <EndDate><![CDATA[31/8/2011]]></EndDate>
    //    //    <JobDescription><![CDATA[  T3 Group-Public Relationship company 07/2011-08/2011, Shanghai, China Account Executive assistant  ]]></JobDescription>
    //    //    <Projects>
    //    //      <ProjectName><![CDATA[]]></ProjectName>
    //    //      <UsedSkills><![CDATA[]]></UsedSkills>
    //    //      <TeamSize><![CDATA[]]></TeamSize>
    //    //    </Projects>
    //    //  </WorkHistory>
    //    //  <WorkHistory>
    //    //    <Employer><![CDATA[]]></Employer>
    //    //    <JobProfile><![CDATA[Brand manager assistant]]></JobProfile>
    //    //    <JobLocation><![CDATA[Shanghai]]></JobLocation>
    //    //    <JobPeriod><![CDATA[07/2010-09/2010]]></JobPeriod>
    //    //    <StartDate><![CDATA[1/07/2010]]></StartDate>
    //    //    <EndDate><![CDATA[30/9/2010]]></EndDate>
    //    //    <JobDescription><![CDATA[ Media communication, production supervision, maintenance of media lists and editorial calendars   Danaifa-traveling products company 07/2010-09/2010, Shanghai, China Brand manager assistant ]]></JobDescription>
    //    //    <Projects>
    //    //      <ProjectName><![CDATA[]]></ProjectName>
    //    //      <UsedSkills><![CDATA[]]></UsedSkills>
    //    //      <TeamSize><![CDATA[]]></TeamSize>
    //    //    </Projects>
    //    //  </WorkHistory>
    //    //  <WorkHistory>
    //    //    <Employer><![CDATA[]]></Employer>
    //    //    <JobProfile><![CDATA[Supply chain assistant]]></JobProfile>
    //    //    <JobLocation><![CDATA[Shanghai]]></JobLocation>
    //    //    <JobPeriod><![CDATA[07/2008-09/2008]]></JobPeriod>
    //    //    <StartDate><![CDATA[1/07/2008]]></StartDate>
    //    //    <EndDate><![CDATA[30/9/2008]]></EndDate>
    //    //    <JobDescription><![CDATA[ data collection and analysis, marketing research, new product development  Decathlon Group- sporting  goods chain  store  07/2008-09/2008, Shanghai, China Supply chain assistant  interdepartmental coordination, data process, and office assistance    ]]></JobDescription>
    //    //    <Projects>
    //    //      <ProjectName><![CDATA[]]></ProjectName>
    //    //      <UsedSkills><![CDATA[]]></UsedSkills>
    //    //      <TeamSize><![CDATA[]]></TeamSize>
    //    //    </Projects>
    //    //  </WorkHistory>
    //    //</SegrigatedExperience>
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string CurrentEmployer { get; set; }
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string JobProfile { get; set; }
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string WorkedPeriod { get; set; }
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string GapPeriod { get; set; }
    //    //<!--Number of Job Changed will be provided in future release-->
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string NumberofJobChanged { get; set; }
    //    //<!--Average Stay will be provided in future release-->
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string AverageStay { get; set; }
    //    //<!--Availability will be provided in future release-->
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string Availability { get; set; }
    //    //<!--Competency Related fields will be provided in future release-->
    //    //<Competency>
    //    //  <CompetencyName><![CDATA[]]></CompetencyName>
    //    //  <Evidence><![CDATA[]]></Evidence>
    //    //  <LastUsed><![CDATA[]]></LastUsed>
    //    //  <Description><![CDATA[]]></Description>
    //    //</Competency>
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string Hobbies { get; set; }
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string Objectives { get; set; }
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string Achievements { get; set; }
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string References { get; set; }
    //    //<!--Preferred Location will be provided in future release-->
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string PreferredLocation { get; set; }
    //    //<!--Certification will be provided in future release-->
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string Certification { get; set; }
    //    //<!--UniqueID will be provided in future release-->
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string UniqueID { get; set; }
    //    //<!--CustomFields will be provided in future release-->
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string CustomFields { get; set; }
    //    //<!--Email Info Related Fields will be provided in future release-->
    //    //<EmailInfo>
    //    //  <EmailFrom><![CDATA[]]></EmailFrom>
    //    //  <EmailTo><![CDATA[]]></EmailTo>
    //    //  <EmailSubject><![CDATA[]]></EmailSubject>
    //    //  <EmailBody><![CDATA[]]></EmailBody>
    //    //  <EmailCC><![CDATA[]]></EmailCC>
    //    //  <EmailReplyTo><![CDATA[]]></EmailReplyTo>
    //    //  <EmailSignature><![CDATA[]]></EmailSignature>
    //    //</EmailInfo>
    //    //<!--WebSites Info Related Fields will be provided in future release-->
    //    //<WebSites>
    //    //  <Website><![CDATA[]]></Website>
    //    //</WebSites>
    //    //<!--Recommendation Field Provide values for Linkedin Resumes-->
    //    //<Recommendations>
    //    //  <Recomendation>
    //    //    <PersonName />
    //    //    <PositionTitle />
    //    //    <CompanyName />
    //    //    <Relation />
    //    //    <Description />
    //    //  </Recomendation>
    //    //</Recommendations>
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string DetailResume { get; set; }
    //    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    //    public string htmlresume { get; set; }

    //}
}
