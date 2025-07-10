using FastEndpoints;
using RealEstate.API.Application.DTO;
using RealEstate.API.Application.Services;

namespace RealEstate.API.Endpoints.Loan
{
    public class LoanGenerateScheduleWithTermMonths : Endpoint<TermMonthsRequest, LoanDto>
    {
        private readonly LoanService _loanService;

        public LoanGenerateScheduleWithTermMonths(LoanService loanService)
        {
            _loanService = loanService;
        }
        public override void Configure()
        {
            Post("api/loan/month/terms");
            AllowAnonymous();
        }
        public override async Task HandleAsync(TermMonthsRequest req, CancellationToken ct)
        {
            var response = _loanService.GenerateSchedule(req.InterestRate, req.Currency, req.LoanAmount, req.TermMonths);
            await SendAsync(response, cancellation: ct);
        }
    }

    public class TermMonthsRequest 
    {
        public decimal InterestRate {  get; set; } 
        public string Currency {  get; set; }
        public decimal LoanAmount {  get; set; } 
        public int TermMonths {  get; set; }
    }
}
