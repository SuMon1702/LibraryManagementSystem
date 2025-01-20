using LibraryManagementSystem.LibraryManagement.Utlis.Enums;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using NuGet.Protocol.Plugins;

namespace LibraryManagementSystem.LibraryManagement.Utlis
{
    public class Result<T>
    {
        public T? Data { get; set; }
        public bool IsSuccess { get; set; }
        public EnumHttpStatusCode StatusCode { get; set; }
        public string? Message { get; set; }

        public static Result<T> Success (string message="Success")
        {
            return new Result<T>
            {
                Message = message,
                IsSuccess = true,
                StatusCode = EnumHttpStatusCode.Success,
            };
        }

        public static Result<T> Success (T data, string message="Success")
        {
            return new Result<T>
            {
                Data = data,
                IsSuccess = true,
                StatusCode = EnumHttpStatusCode.Success,
                Message = message
            };
        }

        public static Result<T> Fail(string message="Fail")
        {
            return new Result<T>
            {
                Message = message,
                StatusCode = EnumHttpStatusCode.BadRequest,
                IsSuccess = false
            };
        }

        public static Result<T> Fail (Exception ex)
        {
            return new Result<T>
            {
                Message = ex.Message,
                StatusCode = EnumHttpStatusCode.InternalServerError,
                IsSuccess = false
            };
        }
        
    }

   
}
