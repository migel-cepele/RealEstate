using FastEndpoints;
using RealEstate.API.Application.Services;

namespace RealEstate.API.Endpoints.ItemStatistics
{
    public class GetItemsGivenInterval : Endpoint<GetItemsGivenIntervalRequest, Dictionary<DateTime, int>>
    {
        private readonly ItemStatisticsService _itemStatisticsService;

        public GetItemsGivenInterval(ItemStatisticsService itemStatisticsService)
        {
            _itemStatisticsService = itemStatisticsService;
        }
        public override void Configure()
        {
            Get("api/item/statistics/given/interval");
            AllowAnonymous();
        }
        public override async Task HandleAsync(GetItemsGivenIntervalRequest req, CancellationToken ct)
        {
            var response = _itemStatisticsService.GetItemsGiven(req.ItemStatus, req.StartDate, req.EndDate);
            await SendAsync(response, cancellation: ct);
        }      
    }
    public class GetItemsGivenIntervalRequest
    {
        [QueryParam]
        public string? ItemStatus { get; set; }
        [QueryParam]
        public DateTime StartDate { get; set; }
        [QueryParam]
        public DateTime EndDate { get; set; }
    }
}
