
namespace eknowID.Repositories.ViewModels
{
    public class TazworkOrderStatusModal
    {
        public Company Company { get; set; }
        public Candidate Candidate { get; set; }
        public User User { get; set; }
        public Plan Plan { get; set; }
        public Order Order { get; set; }
        public string OrderStatusText { get; set; }
        public bool IsIncompleteOrder { get; set; }
    }
}
