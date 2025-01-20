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
    }

   
}
