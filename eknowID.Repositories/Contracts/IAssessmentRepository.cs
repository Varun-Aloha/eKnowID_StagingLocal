using eknowID.Repositories.ViewModels;
using System;
using System.Collections.Generic;
using Wrapper.Model;

namespace eknowID.Repositories.Contracts
{
    public interface IAssessmentRepository
    {
        List<AssessmentViewModel> GetAssessmentByStatus(int status);

        Content GetRequesterDetail(int userId, int orderId);

        bool UpdateAssessmentStatus(Guid assessmentId,int status);
    }
}
