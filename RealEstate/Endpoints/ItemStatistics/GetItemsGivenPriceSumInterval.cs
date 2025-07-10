using FastEndpoints;
using RealEstate.API.Application.Services;

namespace RealEstate.API.Endpoints.ItemStatistics
{
    public class GetItemsGivenPriceSumInterval : Endpoint<GetItemsGivenPriceSumIntervalRequest, Dictionary<DateTime, decimal>>
    {
        private readonly ItemStatisticsService _itemStatisticsService;

        public GetItemsGivenPriceSumInterval(ItemStatisticsService itemStatisticsService)
        {
            _itemStatisticsService = itemStatisticsService;
        }
        public override void Configure()
        {
            Get("api/item/statistics/given/sum/interval");
            AllowAnonymous();
        }
        public override async Task HandleAsync(GetItemsGivenPriceSumIntervalRequest req, CancellationToken ct)
        {
            var response = _itemStatisticsService.GetItemsGivenPriceSum(req.ItemStatus, req.StartDate, req.EndDate);
            await SendAsync(response, cancellation: ct);
        }      
    }
    public class GetItemsGivenPriceSumIntervalRequest
    {
        [QueryParam]
        public string? ItemStatus { get; set; }
        [QueryParam]
        public DateTime StartDate { get; set; }
        [QueryParam]
        public DateTime EndDate { get; set; }
    }
}
