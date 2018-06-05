using System.Collections.Generic;

namespace eknowID.Model
{
    public class PaymentModel
    {
        public string Name { set; get; }
        public string CardType { set; get; }
        public string CardNumber { set; get; }
        public string ExpMonth { set; get; }
        public string ExpYear { set; get; }
        public string SecurityCode { set; get; }
        public string OrderTotal { set; get; }

        public List<string> ReportList { set; get; }
    }
}
