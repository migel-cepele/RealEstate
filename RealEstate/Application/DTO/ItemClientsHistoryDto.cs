namespace RealEstate.API.Application.DTO
{
    public class ItemClientsHistoryDto
    {
        //fushat e klientit
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; } //do te shfaqe vetem njera email ose nr tel
        public bool IsActive { get; set; }
        public DateTime UpdatedAt { get; set; } //data e fundit qe klienti ka ndryshuar dicka(psh nese eshte bere inaktiv, do jete data qe eshte bere inaktiv)
        public int PriorityNo { get; set; } //prioriteti i klientit, 1 me i larte, 2 me i ulet, etj
        public string SaleType { get; set; } //fushat ne lidhje me veprimin e pronen, eshte blere apo marre me qera, cmimi dhe komisioni.
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal Commission { get; set; }
        public string PaymentMethod { get; set; } //metoda e pageses, psh cash, bank transfer, etj
        public string Currency { get; set; } //valuta e pageses, psh EUR, USD, etj
    }
}
