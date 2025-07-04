namespace RealEstate.API.Domain
{
    public class LoanInstallment
    {
        public int InstallmentNumber { get; set; }
        public decimal Principal { get; set; }
        public decimal Interest { get; set; }
        public decimal TotalPayment { get; set; }
        public DateTime DueDate { get; set; }
    }
}
