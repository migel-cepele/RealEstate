using FastEndpoints;
using RealEstate.API.Application.Services;
using RealEstate.API.Domain;

namespace RealEstate.API.Endpoints.ItemStatistics
{
    public class GetItemsWithMaxPrice : Endpoint<ItemMaxPriceRequest, List<Item>>
    {
        private readonly ItemStatisticsService _itemStatisticsService;

        public GetItemsWithMaxPrice(ItemStatisticsService itemStatisticsService)
        {
            _itemStatisticsService = itemStatisticsService;
        }
        public override void Configure()
        {
            Get("api/item/statistics/price/max");
            AllowAnonymous();
        }
        public override async Task HandleAsync(ItemMaxPriceRequest req, CancellationToken ct)
        {
            var response = _itemStatisticsService.GetItemsWithMaxPrice(req.SaleType, req.IsActive);
            await SendAsync(response, cancellation: ct);
        }
    }
    public class ItemMaxPriceRequest
    {
        [QueryParam]
        public string? SaleType { get; set; }

        [QueryParam]
        public bool IsActive { get; set; } = true;
    }
}
