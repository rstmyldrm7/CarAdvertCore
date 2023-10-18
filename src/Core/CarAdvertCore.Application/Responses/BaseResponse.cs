using System.Collections.Generic;

namespace CarAdvertCore.Application.Responses
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Success = true;
            ValidationErrors = new List<string>();
        }

        public BaseResponse(string message = null)
        {
            Success = true;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> ValidationErrors { get; set; }
    }
}
