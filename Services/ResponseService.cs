using DTO;

namespace Services
{
    public class ResponseService
    {
        public static ResponseModel CreateResult(string message, bool response, object? info, int statusCode)
        {
            return new ResponseModel(message, response, info, statusCode);
        }
    }
}
