using FastEndpoints;
using RealEstate.API.Application.Services;
using RealEstate.API.Domain;
using System.Collections.Generic;

namespace RealEstate.API.Endpoints.ClientStatistics
{
    public class GetClientsWithHighestPriorityRequest
    {
        [QueryParam]
        public int TopN { get; set; }
    }

    public class GetClientsWithHighestPriorityEndpoint : Endpoint<GetClientsWithHighestPriorityRequest, List<Client>>
    {
        private readonly ClientStatisticsService _service;
        public GetClientsWithHighestPriorityEndpoint(ClientStatisticsService service)
        {
            _service = service;
        }
        public override void Configure()
        {
            Get("api/client/statistics/priority/top");
            AllowAnonymous();
        }
        public override Task HandleAsync(GetClientsWithHighestPriorityRequest req, CancellationToken ct)
        {
            var result = _service.GetClientsWithHighestPriority(req.TopN);
            return SendAsync(result, cancellation: ct);
        }
    }
}
