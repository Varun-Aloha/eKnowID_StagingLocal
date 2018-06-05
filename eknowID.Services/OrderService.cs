using eknowID.Repositories;
using eknowID.Repositories.Repositories;
using eknowID.Repositories.ViewModels;
using System;
using Wrapper.Model;

namespace eknowID.Services
{
    public class AssessmentOrderService
    {
        IOrderRepository _orderRepository;

        public AssessmentOrderService()
        {
            _orderRepository = new OrderRepository();
        }

        public bool UpdateTazworkOrderStatus(string assessmentId, string actionType, AssessmentViewModel assessmentViewModel)
        {
            try
            {
                return _orderRepository.UpdateTazworkOrderStatus(assessmentId, actionType, assessmentViewModel);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public AssessmentList GetAllNewAssessment()
        {
            try
            {
                return _orderRepository.GetAllNewAssessment();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public AssessmentList GetAllResentAssessments()
        {
            try
            {
                return _orderRepository.GetAllResentAssessments();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool UpdateEknowIDResendAssessmnet(string id)
        {
            try
            {
                return _orderRepository.UpdateEknowIDResendAssessmnet(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void UpdateRefundDetails(int orderId, decimal refundAmount) {
            try {
                _orderRepository.UpdateRefundDetails(orderId, refundAmount);
            } catch (Exception ex) {
                return;
            }
        }
    }
}
