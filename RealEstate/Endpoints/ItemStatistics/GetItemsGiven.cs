using FastEndpoints;
using RealEstate.API.Application.Services;

namespace RealEstate.API.Endpoints.ItemStatistics
{
    public class GetItemsGiven : Endpoint<GetItemsGivenRequest, Dictionary<DateTime, int>>
    {
        private readonly ItemStatisticsService _itemStatisticsService;

        public GetItemsGiven(ItemStatisticsService itemStatisticsService)
        {
            _itemStatisticsService = itemStatisticsService;
        }
        public override void Configure()
        {
            Get("api/item/statistics/given");
            AllowAnonymous();
        }
        public override async Task HandleAsync(GetItemsGivenRequest req, CancellationToken ct)
        {
            var response = _itemStatisticsService.GetItemsGiven(req.ItemStatus, req.TimeInterval);
            await SendAsync(response, cancellation: ct);
        }     
    }
    public class GetItemsGivenRequest
    {
        [QueryParam]
        public string? ItemStatus { get; set; }

        [QueryParam]
        public string TimeInterval { get; set; }
    }
}
