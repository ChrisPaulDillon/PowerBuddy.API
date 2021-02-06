using System;

namespace PowerBuddy.API.Models
{
    public class ApiError
    {
        public ApiError()
        {
        }

        public ApiError(Exception ex)
        {
            ErrorCode = ex.GetType().Name;
            ErrorMessage = ex.Message;
        }

        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
