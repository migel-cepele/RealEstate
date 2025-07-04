namespace RealEstate.API.Domain
{
    public class Item
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public int? Bedrooms { get; set; }
        public int? Bathrooms { get; set; }
        public decimal AreaM2 { get; set; }
        public decimal? LotSize { get; set; }
        public int? YearBuilt { get; set; }
        public string PropertyType { get; set; }
        public string SaleType { get; set; }
        public bool? Furnished { get; set; }
        public bool? HasGarage { get; set; }
        public int? GarageSpaces { get; set; }
        public bool? HasGarden { get; set; }
        public bool? HasPool { get; set; }
        public DateTime ListingDate { get; set; }
        public string Status { get; set; }
        public long UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? Floor { get; set; }
        public int? TotalFloors { get; set; }
        public string HeatingType { get; set; }
        public string CoolingType { get; set; }
        public decimal? PropertyTax { get; set; }
        public decimal? HOAFees { get; set; }
        public bool? UtilitiesIncluded { get; set; }
        public decimal? WalkScore { get; set; }
        public string EnergyRating { get; set; }
    }
}