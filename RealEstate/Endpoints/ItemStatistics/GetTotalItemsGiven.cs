using FastEndpoints;
using RealEstate.API.Application.Services;

namespace RealEstate.API.Endpoints.ItemStatistics
{
    public class GetTotalItemsGiven : Endpoint<GetTotaltemsGivenRequest, int>
    {
        private readonly ItemStatisticsService _itemStatisticsService;

        public GetTotalItemsGiven(ItemStatisticsService itemStatisticsService)
        {
            _itemStatisticsService = itemStatisticsService;
        }
        public override void Configure()
        {
            Get("api/item/statistics/total/given");
            AllowAnonymous();
        }
        public override async Task HandleAsync(GetTotaltemsGivenRequest req, CancellationToken ct)
        {
            var response = _itemStatisticsService.GetTotalItemsGivenNo(req.ItemStatus, req.TimeInterval);
            await SendAsync(response, cancellation: ct);
        }     
    }
    public class GetTotaltemsGivenRequest
    {
        [QueryParam]
        public string? ItemStatus { get; set; }

        [QueryParam]
        public string TimeInterval { get; set; }
    }
}
