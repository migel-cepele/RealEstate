namespace RealEstate.API.Domain
{
    public class ClientItem
    {
        public long Id { get; set; }
        public Client Client { get; set; }
        public long ClientId { get; set; }
        public Item Item { get; set; }
        public long ItemId { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal Commission { get; set; }
        public string PaymentMethod { get; set; }
        public string Currency { get; set; }
    }
}