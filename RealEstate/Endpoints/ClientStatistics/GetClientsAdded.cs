using FastEndpoints;
using RealEstate.API.Application.Services;
using System;
using System.Collections.Generic;

namespace RealEstate.API.Endpoints.ClientStatistics
{
    public class GetClientsAddedRequest
    {
        [QueryParam]
        public string TimeInterval { get; set; }
    }

    public class GetClientsAddedEndpoint : Endpoint<GetClientsAddedRequest, Dictionary<DateTime, int>>
    {
        private readonly ClientStatisticsService _service;
        public GetClientsAddedEndpoint(ClientStatisticsService service)
        {
            _service = service;
        }
        public override void Configure()
        {
            Get("api/client/statistics/added");
            AllowAnonymous();
        }
        public override Task HandleAsync(GetClientsAddedRequest req, CancellationToken ct)
        {
            var result = _service.GetClientsAdded(req.TimeInterval);
            return SendAsync(result, cancellation: ct);
        }
    }
}
