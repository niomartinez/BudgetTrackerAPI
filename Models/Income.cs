namespace BudgetTracker.API.Models
{
    public class Income
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public Source Source { get; set; }
    }
}
