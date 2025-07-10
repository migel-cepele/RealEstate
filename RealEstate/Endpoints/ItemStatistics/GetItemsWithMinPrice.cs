using FastEndpoints;
using RealEstate.API.Application.Services;
using RealEstate.API.Domain;

namespace RealEstate.API.Endpoints.ItemStatistics
{
    public class GetItemsWithMinPrice : Endpoint<ItemMinPriceRequest, List<Item>>
    {
        private readonly ItemStatisticsService _itemStatisticsService;

        public GetItemsWithMinPrice(ItemStatisticsService itemStatisticsService)
        {
            _itemStatisticsService = itemStatisticsService;
        }
        public override void Configure()
        {
            Get("api/item/statistics/price/min");
            AllowAnonymous();
        }
        public override async Task HandleAsync(ItemMinPriceRequest req, CancellationToken ct)
        {
            var response = _itemStatisticsService.GetItemsWithMaxPrice(req.SaleType, req.IsActive);
            await SendAsync(response, cancellation: ct);
        }       
    }
    public class ItemMinPriceRequest
    {
        [QueryParam]
        public string? SaleType { get; set; }

        [QueryParam]
        public bool IsActive { get; set; } = true;
    }
}
