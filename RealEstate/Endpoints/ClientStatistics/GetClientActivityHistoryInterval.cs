using FastEndpoints;
using RealEstate.API.Application.Services;
using System;
using System.Collections.Generic;

namespace RealEstate.API.Endpoints.ClientStatistics
{
    public class GetClientActivityHistoryIntervalRequest
    {
        [QueryParam]
        public long ClientId { get; set; }
        [QueryParam]
        public string? ItemStatus { get; set; }
        [QueryParam]
        public DateTime StartDate { get; set; }
        [QueryParam]
        public DateTime EndDate { get; set; }
    }

    public class GetClientActivityHistoryIntervalEndpoint : Endpoint<GetClientActivityHistoryIntervalRequest, Dictionary<DateTime, decimal>>
    {
        private readonly ClientStatisticsService _service;
        public GetClientActivityHistoryIntervalEndpoint(ClientStatisticsService service)
        {
            _service = service;
        }
        public override void Configure()
        {
            Get("api/client/statistics/price/history/interval");
            AllowAnonymous();
        }
        public override Task HandleAsync(GetClientActivityHistoryIntervalRequest req, CancellationToken ct)
        {
            var result = _service.GetClientActivityHistory(req.ClientId, req.ItemStatus, req.StartDate, req.EndDate);
            return SendAsync(result, cancellation: ct);
        }
    }
}
