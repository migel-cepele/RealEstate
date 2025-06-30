namespace RealEstate.Domain
{
    public class UserApplication
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public decimal OfferAmount { get; set; }
        public string Description { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsRejected { get; set; }
        public int HouseId { get; set; }
    }
}
