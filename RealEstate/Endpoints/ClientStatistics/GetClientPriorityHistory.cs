using FastEndpoints;
using RealEstate.API.Application.Services;
using System;
using System.Collections.Generic;

namespace RealEstate.API.Endpoints.ClientStatistics
{
    public class GetClientPriorityHistoryRequest
    {
        [QueryParam]
        public int TopN { get; set; }
        [QueryParam]
        public string TimeInterval { get; set; }
        [QueryParam]
        public string? ItemStatus { get; set; }
    }

    public class GetClientPriorityHistoryEndpoint : Endpoint<GetClientPriorityHistoryRequest, Dictionary<DateTime, decimal>>
    {
        private readonly ClientStatisticsService _service;
        public GetClientPriorityHistoryEndpoint(ClientStatisticsService service)
        {
            _service = service;
        }
        public override void Configure()
        {
            Get("api/client/statistics/priority/history");
            AllowAnonymous();
        }
        public override Task HandleAsync(GetClientPriorityHistoryRequest req, CancellationToken ct)
        {
            var result = _service.GetClientPriorityHistory(req.TopN, req.TimeInterval, req.ItemStatus);
            return SendAsync(result, cancellation: ct);
        }
    }
}
