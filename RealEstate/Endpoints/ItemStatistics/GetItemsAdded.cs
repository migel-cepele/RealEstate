using FastEndpoints;
using RealEstate.API.Application.Services;

namespace RealEstate.API.Endpoints.ItemStatistics
{
    public class GetItemsAdded : Endpoint<GetItemsAddedRequest, Dictionary<DateTime,int>>
    {
        private readonly ItemStatisticsService _itemStatisticsService;

        public GetItemsAdded(ItemStatisticsService itemStatisticsService)
        {
            _itemStatisticsService = itemStatisticsService;
        }
        public override void Configure()
        {
            Get("api/item/statistics/added");
            AllowAnonymous();
        }
        public override async Task HandleAsync(GetItemsAddedRequest req, CancellationToken ct)
        {
            var response = _itemStatisticsService.GetItemsAdded(req.SaleType, req.TimeInterval);
            await SendAsync(response, cancellation: ct);
        }
        
    }
    public class GetItemsAddedRequest
    {
        [QueryParam]
        public string? SaleType { get; set; }

        [QueryParam]
        public string TimeInterval { get; set; }
    }
}
