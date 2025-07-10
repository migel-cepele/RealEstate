using FastEndpoints;
using RealEstate.API.Application.DTO;
using RealEstate.API.Application.Services;

namespace RealEstate.API.Endpoints.Loan
{
    public class LoanGenerateScheduleWithMonthlyPayment : Endpoint<MonthlyPaymentRequest, LoanDto>
    {
        private readonly LoanService _loanService;

        public LoanGenerateScheduleWithMonthlyPayment(LoanService loanService)
        {
            _loanService = loanService;
        }
        public override void Configure()
        {
            Post("api/loan/month/payment");
            AllowAnonymous();
        }
        public override async Task HandleAsync(MonthlyPaymentRequest req, CancellationToken ct)
        {
            var response = _loanService.GenerateSchedule(req.InterestRate, req.Currency, req.LoanAmount, req.MonthlyPayment);
            await SendAsync(response, cancellation: ct);
        }
    }

    public class MonthlyPaymentRequest 
    {
        public decimal InterestRate {  get; set; } 
        public string Currency {  get; set; }
        public decimal LoanAmount {  get; set; } 
        public decimal MonthlyPayment {  get; set; }
    }
}
