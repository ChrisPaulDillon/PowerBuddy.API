using System;
namespace PowerLifting.API.Models
{
    public class ApiBaseResponse<T>
    {
        public T Result { get; set; }
    }

    public class ApiResponse<T> : ApiBaseResponse<T>
    {

    }

    public static class Responses
    {
        public static ApiResponse<bool> Success()
        {
            return new ApiResponse<bool>
            {
                Result = true
            };
        }

        public static ApiResponse<T> Success<T>(T result)
        {
            return new ApiResponse<T>
            {
                Result = result
            };
        }

        public static ApiResponse<ApiError> Error(string code, string message)
        {
            return new ApiResponse<ApiError>
            {
                Result = new ApiError
                {
                    ErrorCode = code,
                    ErrorMessage = message
                }
            };
        }

        public static ApiResponse<ApiError> Error(int code, string message)
        {
            return Error($"{code}", message);
        }

        public static ApiResponse<ApiError> Error(Exception ex)
        {
            return new ApiResponse<ApiError>
            {
                Result = new ApiError
                {
                    ErrorCode = ex.GetType().Name,
                    ErrorMessage = ex.Message
                }
            };
        }

        public static ApiResponse<ApiErrorWithDetails<T>> DetailedError<T>(string code, string message, T details)
        {
            return new ApiResponse<ApiErrorWithDetails<T>>
            {
                Result = new ApiErrorWithDetails<T>
                {
                    ErrorCode = code,
                    ErrorMessage = message,
                    ErrorDetails = details
                }
            };
        }
    }
}
