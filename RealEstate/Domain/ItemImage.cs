namespace RealEstate.API.Domain
{
    public class ItemImage
    {
        public int Id { get; set; }
        public long ItemId { get; set; }
        public byte[] Image { get; set; }
    }
}