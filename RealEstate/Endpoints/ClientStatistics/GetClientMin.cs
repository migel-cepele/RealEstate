using FastEndpoints;
using RealEstate.API.Application.Services;
using RealEstate.API.Domain;

namespace RealEstate.API.Endpoints.ClientStatistics
{
    public class GetClientMinRequest
    {
        [QueryParam]
        public string? ItemStatus { get; set; }
    }

    public class GetClientMinEndpoint : Endpoint<GetClientMinRequest, Client>
    {
        private readonly ClientStatisticsService _service;
        public GetClientMinEndpoint(ClientStatisticsService service)
        {
            _service = service;
        }
        public override void Configure()
        {
            Get("api/client/statistics/price/min");
            AllowAnonymous();
        }
        public override Task HandleAsync(GetClientMinRequest req, CancellationToken ct)
        {
            var result = _service.GetClientMin(req.ItemStatus);
            return SendAsync(result, cancellation: ct);
        }
    }
}
