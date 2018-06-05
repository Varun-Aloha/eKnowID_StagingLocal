using System.Collections.Generic;

namespace eknowID.Repositories
{
    public class PaymentModel
    {
        public bool IsFullWalletPayment { get; set; }
        public bool IsPartialWalletPayment { get; set; }
        public bool IsFullCreditCardPayment { get; set; }
        public bool IsPaymentError { get; set; }
        public CreditCardModel CreditCardModel { get; set; }
        public OrderDetailModel OrderDetailModel { get; set; }
        public PaymentResponseModal PaymentResponseModal { get; set; }
        public List<int> AlacartReportList { get; set; }
        public Dictionary<int, int> AlacartReportListWithQty { get; set; }
        public string SelectedStates { get; set; }
        public string SelectedCounties { get; set; }
        public string SelectedCivilCounties { get; set; }
        public string SelectedDistricts { get; set; }
        public bool IsCreditReportAuditingChargesPaid { get; set; }
    }

    public class CreditCardModel
    {
        public string CardType { set; get; }
        public string CardNumber { set; get; }
        public string ExpMonth { set; get; }
        public string ExpYear { set; get; }
        public string SecurityCode { set; get; }
    }

    public class PaymentResponseModal
    {
        public string TransactionId { get; set; }
        public string CorrelationId { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class OrderDetailModel
    {
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public int PlanType { get; set; }
        public int OrderTypeId { get; set; }
        public decimal OrderTotal { set; get; }
        public decimal WalletPrice { get; set; }
        public decimal TotalOrder { get; set; }
    }

    public class ResponseModel
    {
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }

        public ResponseModel(bool IsError, string ErrorMessage)
        {
            this.IsError = IsError;
            this.ErrorMessage = ErrorMessage;
        }
    }
}
