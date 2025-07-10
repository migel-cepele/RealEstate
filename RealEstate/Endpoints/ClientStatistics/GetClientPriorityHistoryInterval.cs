using FastEndpoints;
using RealEstate.API.Application.Services;
using System;
using System.Collections.Generic;

namespace RealEstate.API.Endpoints.ClientStatistics
{
    public class GetClientPriorityHistoryIntervalRequest
    {
        [QueryParam]
        public int TopN { get; set; }
        [QueryParam]
        public DateTime StartDate { get; set; }
        [QueryParam]
        public DateTime EndDate { get; set; }
        [QueryParam]
        public string? ItemStatus { get; set; }
    }

    public class GetClientPriorityHistoryIntervalEndpoint : Endpoint<GetClientPriorityHistoryIntervalRequest, Dictionary<DateTime, decimal>>
    {
        private readonly ClientStatisticsService _service;
        public GetClientPriorityHistoryIntervalEndpoint(ClientStatisticsService service)
        {
            _service = service;
        }
        public override void Configure()
        {
            Get("api/client/statistics/priority/history/interval");
            AllowAnonymous();
        }
        public override Task HandleAsync(GetClientPriorityHistoryIntervalRequest req, CancellationToken ct)
        {
            var result = _service.GetClientPriorityHistoryInterval(req.TopN, req.StartDate, req.EndDate, req.ItemStatus);
            return SendAsync(result, cancellation: ct);
        }
    }
}
