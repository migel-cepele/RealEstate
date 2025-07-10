using FastEndpoints;
using RealEstate.API.Application.Services;

namespace RealEstate.API.Endpoints.ItemStatistics
{
    public class GetAverageItemPrice : Endpoint<ItemAvgPriceRequest, decimal>
    {
        private readonly ItemStatisticsService _itemStatisticsService;

        public GetAverageItemPrice(ItemStatisticsService itemStatisticsService)
        {
            _itemStatisticsService = itemStatisticsService;
        }
        public override void Configure()
        {
            Get("api/item/statistics/price/avg");
            AllowAnonymous();
        }
        public override async Task HandleAsync(ItemAvgPriceRequest req, CancellationToken ct)
        {
            var response = _itemStatisticsService.GetAverageItemPrice(req.SaleType, req.IsActive);
            await SendAsync(response, cancellation: ct);
        }
    }
    public class ItemAvgPriceRequest
    {
        [QueryParam]
        public string? SaleType { get; set; }

        [QueryParam]
        public bool IsActive { get; set; } = true;
    }
}
