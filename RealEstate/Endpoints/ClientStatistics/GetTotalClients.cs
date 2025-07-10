using FastEndpoints;
using RealEstate.API.Application.Services;

namespace RealEstate.API.Endpoints.ClientStatistics
{
    public class GetTotalClientsRequest
    {
        [QueryParam]
        public bool? IsActive { get; set; }
    }

    public class GetTotalClientsEndpoint : Endpoint<GetTotalClientsRequest, int>
    {
        private readonly ClientStatisticsService _service;
        public GetTotalClientsEndpoint(ClientStatisticsService service)
        {
            _service = service;
        }
        public override void Configure()
        {
            Get("api/client/statistics/total");
            AllowAnonymous();
        }
        public override Task HandleAsync(GetTotalClientsRequest req, CancellationToken ct)
        {
            var result = _service.GetTotalClients(req.IsActive);
            return SendAsync(result, cancellation: ct);
        }
    }
}
