namespace DTO
{
    public class ResponseModel(string message, Boolean success, object? result, int statusCode)
    {
        public string? message { get; set; } = message;
        public Boolean success { get; set; } = success;
        public object? result { get; set; } = result;
        public int statusCode { get; set; } = statusCode;

    }
}
