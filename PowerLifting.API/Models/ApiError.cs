using System;
namespace PowerLifting.API.Models
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

    public class ApiErrorWithDetails<T> : ApiError
    {
        public ApiErrorWithDetails() : base() { }

        public ApiErrorWithDetails(Exception ex, T details) : base(ex)
        {
            ErrorDetails = details;
        }

        public T ErrorDetails { get; set; }
    }
}
