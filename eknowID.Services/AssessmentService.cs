using eknowID.Repositories.Contracts;
using eknowID.Repositories.Repositories;
using eknowID.Repositories.ViewModels;
using System;
using System.Collections.Generic;

namespace eknowID.Services
{
    public class AssessmentService
    {
        IAssessmentRepository _IAssessmentRepository;

        public AssessmentService()
        {
            _IAssessmentRepository = new AssessmentRepository();
        }

        public List<AssessmentViewModel> GetAssessmentByStatus(int status)
        {
            try
            {
                return _IAssessmentRepository.GetAssessmentByStatus(status);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Content GetRequesterDetail(int userId, int orderId)
        {
            try
            {
                return _IAssessmentRepository.GetRequesterDetail(userId, orderId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
