using FastEndpoints;
using RealEstate.API.Application.Services;

namespace RealEstate.API.Endpoints.ItemStatistics
{
    public class GetTotalItemsGivenInterval : Endpoint<GetTotalItemsGivenIntervalRequest, int>
    {
        private readonly ItemStatisticsService _itemStatisticsService;

        public GetTotalItemsGivenInterval(ItemStatisticsService itemStatisticsService)
        {
            _itemStatisticsService = itemStatisticsService;
        }
        public override void Configure()
        {
            Get("api/item/statistics/total/given/interval");
            AllowAnonymous();
        }
        public override async Task HandleAsync(GetTotalItemsGivenIntervalRequest req, CancellationToken ct)
        {
            var response = _itemStatisticsService.GetTotalItemsGivenNo(req.ItemStatus, req.StartDate, req.EndDate);
            await SendAsync(response, cancellation: ct);
        }      
    }
    public class GetTotalItemsGivenIntervalRequest
    {
        [QueryParam]
        public string? ItemStatus { get; set; }
        [QueryParam]
        public DateTime StartDate { get; set; }
        [QueryParam]
        public DateTime EndDate { get; set; }
    }
}
