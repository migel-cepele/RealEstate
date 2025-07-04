namespace RealEstate.API.Application.DTO
{
    public class ClientItemsHistoryDto
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Address { get; set; }
        public string PropertyType { get; set; }
        public string Status { get; set; } // Status of the item (e.g., Sold, Available, Under Offer)
        public DateTime UpdatedAt { get; set; }
        public string SaleType { get; set; } // me poshte jane fushat e relacionet midis client dhe item. Rent or Sold
        public DateTime AcquiredDate { get; set; } // Date when the item was sold or rented
        public decimal AcquiredPrice { get; set; } // Price at which the item was acquired by the client
        public decimal Discount { get; set; } // Discount applied to the item
        public decimal Commission { get; set; } // Commission for the item
        public string PaymentMethod { get; set; } // Payment method used for the item

    }
}
