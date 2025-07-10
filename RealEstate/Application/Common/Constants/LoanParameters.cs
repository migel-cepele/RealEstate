namespace RealEstate.API.Application.Common.Constants
{
    public static class LoanParameters
    {
        public const decimal InterestRateALL = 0.05m; // 5% default interest rate
        public const decimal InterestRateEUR = 0.06m; // 6% default interest rate
        public const decimal MaxLoanFinancingALL = 0.85m; // the amount that the bank can lend in ALL, in max is 85% of the property value
        public const decimal MaxLoanFinancingEUR = 0.75m; // the amount that the bank can lend in EUR, in max is 75% of the property value

    }
}
