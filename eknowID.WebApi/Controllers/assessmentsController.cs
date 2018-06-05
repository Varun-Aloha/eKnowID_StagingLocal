using eknowID.Repositories.ViewModels;
using eknowID.Services;
using System;
using System.Web.Http;
using Wrapper.Model;

namespace eknowID.WebApi.Controllers
{
    public class assessmentsController : ApiController
    {
        #region Data Member
        AssessmentOrderService assessmentOrderService;
        #endregion

        #region Constructor
        public assessmentsController()
        {
            assessmentOrderService = new AssessmentOrderService();
        }
        #endregion

        #region API-Controllers
        [Route("api/assessments/{assessmentId}/{actionType}")]
        public AssessmentError UpdateAssessmentStatus(string assessmentId, string actionType, AssessmentViewModel AssessmentViewModel)
        {
            try
            {
                assessmentOrderService.UpdateTazworkOrderStatus(assessmentId, actionType, AssessmentViewModel);

                return new AssessmentError(assessmentId, DateTime.Now.ToString(), "200", string.Empty, "Assessment is submitted successfully.");
            }
            catch (Exception ex)
            {
                return new AssessmentError(assessmentId, DateTime.Now.ToString(), "400", string.Empty, "Assessment is not submitted successfully.");
            }
        }

        [Route("api/assessments")]
        public AssessmentList GetNewAssessments()
        {
            try
            {                
                return assessmentOrderService.GetAllNewAssessment();
            }
            catch (Exception ex)
            {
                return new AssessmentList()
                {
                    TotalFound = 0,
                    Offset = 10
                };
            }
        }

        [Route("api/getallresentAssessments")]
        public AssessmentList GetAllResentAssessments()
        {
            try
            {
                return assessmentOrderService.GetAllResentAssessments();

            }
            catch (Exception)
            {
                return new AssessmentList()
                {
                    TotalFound = 0,
                    Offset = 10
                };
            }

        }

        [Route("api/assessments/{id}")]
        public bool UpdatResentEmailAssessments(string id)
        {
            try
            {
                return assessmentOrderService.UpdateEknowIDResendAssessmnet(id);
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion
    }
}