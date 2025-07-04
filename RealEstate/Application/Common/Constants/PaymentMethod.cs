namespace RealEstate.API.Application.Common.Constants
{
    public static class PaymentMethod
    {
        public static readonly string Cash = nameof(Cash);
        public static readonly string BankTransfer = nameof(BankTransfer);
        public static readonly string CreditCard = nameof(CreditCard);
        public static readonly string PayPal = nameof(PayPal);
        public static readonly string Cryptocurrency = nameof(Cryptocurrency);
        public static readonly string Check = nameof(Check);
        public static readonly string MobilePayment = nameof(MobilePayment);
        public static readonly string Escrow = nameof(Escrow);
        public static readonly string Other = nameof(Other);
    }
}
