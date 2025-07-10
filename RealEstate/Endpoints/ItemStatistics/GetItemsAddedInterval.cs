using FastEndpoints;
using RealEstate.API.Application.Services;

namespace RealEstate.API.Endpoints.ItemStatistics
{
    public class GetItemsAddedInterval : Endpoint<GetItemsAddedIntervalRequest, Dictionary<DateTime, int>>
    {
        private readonly ItemStatisticsService _itemStatisticsService;

        public GetItemsAddedInterval(ItemStatisticsService itemStatisticsService)
        {
            _itemStatisticsService = itemStatisticsService;
        }
        public override void Configure()
        {
            Get("api/item/statistics/added/interval");
            AllowAnonymous();
        }
        public override async Task HandleAsync(GetItemsAddedIntervalRequest req, CancellationToken ct)
        {
            var response = _itemStatisticsService.GetItemsAdded(req.SaleType, req.StartDate, req.EndDate);
            await SendAsync(response, cancellation: ct);
        }       
    }

    public class GetItemsAddedIntervalRequest
    {
        [QueryParam]
        public string? SaleType { get; set; }
        [QueryParam]
        public DateTime StartDate { get; set; }
        [QueryParam]
        public DateTime EndDate { get; set; }
    }
}
