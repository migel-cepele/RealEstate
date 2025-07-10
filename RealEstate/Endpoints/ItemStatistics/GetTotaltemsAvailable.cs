using FastEndpoints;
using RealEstate.API.Application.Services;

namespace RealEstate.API.Endpoints.ItemStatistics
{
    public class GetTotaltemsAvailable : Endpoint<GetTotaltemsAvailableRequest, int>
    {
        private readonly ItemStatisticsService _itemStatisticsService;

        public GetTotaltemsAvailable(ItemStatisticsService itemStatisticsService)
        {
            _itemStatisticsService = itemStatisticsService;
        }
        public override void Configure()
        {
            Get("api/item/statistics/total/available");
            AllowAnonymous();
        }
        public override async Task HandleAsync(GetTotaltemsAvailableRequest req, CancellationToken ct)
        {
            var response = _itemStatisticsService.GetTotalItemsAvailableNo(req.SaleType, req.IsActive);
            await SendAsync(response, cancellation: ct);
        }        
    }
    public class GetTotaltemsAvailableRequest
    {
        [QueryParam]
        public string? SaleType { get; set; }

        [QueryParam]
        public bool IsActive { get; set; } = true;
    }
}
