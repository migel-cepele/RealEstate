using RealEstate.API.Domain;

namespace RealEstate.API.Application.DTO
{
    public class LoanDto
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

    public class LoanInstallment
    {
        public int InstallmentNumber { get; set; }
        public decimal Principal { get; set; }
        public decimal Interest { get; set; }
        public decimal TotalPayment { get; set; }
        public DateTime DueDate { get; set; }
    }
}
