using FastEndpoints;
using RealEstate.API.Application.Services;
using System;
using System.Collections.Generic;

namespace RealEstate.API.Endpoints.ClientStatistics
{
    public class GetClientActivityHistoryRequest
    {
        [QueryParam]
        public long ClientId { get; set; }
        [QueryParam]
        public string? ItemStatus { get; set; }
        [QueryParam]
        public string TimeInterval { get; set; }
    }

    public class GetClientActivityHistoryEndpoint : Endpoint<GetClientActivityHistoryRequest, Dictionary<DateTime, decimal>>
    {
        private readonly ClientStatisticsService _service;
        public GetClientActivityHistoryEndpoint(ClientStatisticsService service)
        {
            _service = service;
        }
        public override void Configure()
        {
            Get("api/client/statistics/price/history");
            AllowAnonymous();
        }
        public override Task HandleAsync(GetClientActivityHistoryRequest req, CancellationToken ct)
        {
            var result = _service.GetClientActivityHistory(req.ClientId, req.ItemStatus, req.TimeInterval);
            return SendAsync(result, cancellation: ct);
        }
    }
}
