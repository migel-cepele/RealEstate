namespace RealEstate.API.Application.Common
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; } = new();
        public string? Message { get; set; }

        public static OperationResult Ok(string? message = null)
            => new OperationResult { Success = true, Message = message };

        public static OperationResult Fail(params string[] errors)
            => new OperationResult { Success = false, Errors = errors.ToList() };
    }
}