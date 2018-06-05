
namespace eknowID.Repositories.ViewModels
{
    public class AssessmentViewModel
    {
        public string title { get; set; }
        public string description { get; set; }
        public bool passed { get; set; }
        public string score { get; set; }
        public string resultType { get; set; }
        public string result { get; set; }
        public author author { get; set; }

        public string message { get; set; }
        public string assessmentURL { get; set; }
        public string messageToCandidate { get; set; }
    }

    public class author
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }

    public class AssessmentError
    {
        public string Id { set; get; }
        public string createdAt { set; get; }
        public string httpCode { set; get; }
        public string code { set; get; }
        public string message { set; get; }

        public AssessmentError(string Id, string createdAt, string httpCode, string code, string message)
        {
            this.Id = Id;
            this.createdAt = createdAt;
            this.httpCode = httpCode;
            this.code = code;
            this.message = message;
        }
    }
}
