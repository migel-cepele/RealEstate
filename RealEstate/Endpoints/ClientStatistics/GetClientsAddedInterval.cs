using FastEndpoints;
using RealEstate.API.Application.Services;
using System;
using System.Collections.Generic;

namespace RealEstate.API.Endpoints.ClientStatistics
{
    public class GetClientsAddedIntervalRequest
    {
        [QueryParam]
        public DateTime StartDate { get; set; }
        [QueryParam]
        public DateTime EndDate { get; set; }
    }

    public class GetClientsAddedIntervalEndpoint : Endpoint<GetClientsAddedIntervalRequest, Dictionary<DateTime, int>>
    {
        private readonly ClientStatisticsService _service;
        public GetClientsAddedIntervalEndpoint(ClientStatisticsService service)
        {
            _service = service;
        }
        public override void Configure()
        {
            Get("api/client/statistics/added/interval");
            AllowAnonymous();
        }
        public override Task HandleAsync(GetClientsAddedIntervalRequest req, CancellationToken ct)
        {
            var result = _service.GetClientsAddedInterval(req.StartDate, req.EndDate);
            return SendAsync(result, cancellation: ct);
        }
    }
}
