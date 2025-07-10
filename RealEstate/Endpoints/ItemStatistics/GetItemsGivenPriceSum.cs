using FastEndpoints;
using RealEstate.API.Application.Services;

namespace RealEstate.API.Endpoints.ItemStatistics
{
    public class GetItemsGivenPriceSum : Endpoint<GetItemsGivenPriceSumRequest, Dictionary<DateTime, decimal>>
    {
        private readonly ItemStatisticsService _itemStatisticsService;

        public GetItemsGivenPriceSum(ItemStatisticsService itemStatisticsService)
        {
            _itemStatisticsService = itemStatisticsService;
        }
        public override void Configure()
        {
            Get("api/item/statistics/given/sum");
            AllowAnonymous();
        }
        public override async Task HandleAsync(GetItemsGivenPriceSumRequest req, CancellationToken ct)
        {
            var response = _itemStatisticsService.GetItemsGivenPriceSum(req.ItemStatus, req.TimeInterval);
            await SendAsync(response, cancellation: ct);
        }     
    }
    public class GetItemsGivenPriceSumRequest
    {
        [QueryParam]
        public string? ItemStatus { get; set; }

        [QueryParam]
        public string TimeInterval { get; set; }
    }
}
