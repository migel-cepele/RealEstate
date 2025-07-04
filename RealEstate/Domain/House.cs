namespace RealEstate.API.Domain
{
    public class House
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Photo { get; set; } // URL or null
        public byte[]? PhotoLocal { get; set; } // Local image or null
        public int AvailableUnits { get; set; }
        public bool Wifi { get; set; }
        public bool Laundry { get; set; }
    }
}
