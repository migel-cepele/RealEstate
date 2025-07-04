using FastEndpoints;

namespace RealEstate.API.Endpoints
{
    public class FastEndpointTest : EndpointWithoutRequest<FastEndpointTestResponse>
    {
        public override void Configure()
        {
            Get("/fast-endpoint-test");
            AllowAnonymous();
        }
        public override async Task HandleAsync(CancellationToken ct)
        {
            var response = new FastEndpointTestResponse();
            await SendAsync(response, cancellation: ct);
        }
    }
    
    

    public class FastEndpointTestResponse
    {
        public string Message { get; set; } = "Hello from FastEndpoints!";
    }
}
