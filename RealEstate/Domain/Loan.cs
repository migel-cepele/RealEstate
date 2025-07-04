namespace RealEstate.API.Domain
{
    public class Loan
    {
        public decimal Amount { get; set; }
        public decimal InterestRate { get; set; }
        public int TermMonths { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal MonthlyPayment { get; set; }
        public string Currency { get; set; }
        // Navigation properties
        public ICollection<LoanInstallment> Installments { get; set; } = new List<LoanInstallment>();
    }
}
