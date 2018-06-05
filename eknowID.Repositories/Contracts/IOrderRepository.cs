using eknowID.Repositories.ViewModels;
using System.Collections.Generic;
using Wrapper.Model;

namespace eknowID.Repositories
{
    public interface IOrderRepository
    {
        bool UpdateTazworkOrderStatus(string assessmentId, string actionType, AssessmentViewModel AssessmentViewModel);

        AssessmentList GetAllNewAssessment();

        AssessmentList GetAllResentAssessments();

        bool UpdateEknowIDResendAssessmnet(string id);

        void UpdateRefundDetails(int orderId, decimal refundAmount);
    }
}
