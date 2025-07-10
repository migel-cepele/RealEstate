using FastEndpoints;
using RealEstate.API.Application.Services;
using RealEstate.API.Domain;

namespace RealEstate.API.Endpoints.ClientStatistics
{
    public class GetClientMaxRequest
    {
        [QueryParam]
        public string? ItemStatus { get; set; }
    }

    public class GetClientMaxEndpoint : Endpoint<GetClientMaxRequest, Client>
    {
        private readonly ClientStatisticsService _service;
        public GetClientMaxEndpoint(ClientStatisticsService service)
        {
            _service = service;
        }
        public override void Configure()
        {
            Get("api/client/statistics/price/max");
            AllowAnonymous();
        }
        public override Task HandleAsync(GetClientMaxRequest req, CancellationToken ct)
        {
            var result = _service.GetClientMax(req.ItemStatus);
            return SendAsync(result, cancellation: ct);
        }
    }
}
