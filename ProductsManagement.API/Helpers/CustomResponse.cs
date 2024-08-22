using ProductsManagement.API.Models.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ProductsManagement.API.Helpers
{
    public class CustomResponse
    {
        public static IActionResult Success(string? message = "")
        {
            return new ObjectResult(new SuccessResponse<object> { Success = true, Message = message, Data = null })
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }

        public static IActionResult Success<T>(T response) where T : class
        {
            return new ObjectResult(new SuccessResponse<T> { Success = true, Message = string.Empty, Data = response })
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }

        public static IActionResult Success<T>(T response, string message) where T : class
        {
            return new ObjectResult(new SuccessResponse<T> { Success = true, Message = message, Data = response })
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }

        public static IActionResult NotFound(string message)
        {
            return new ObjectResult(new ErrorResponse { Success = false, Message = message })
            {
                StatusCode = (int)HttpStatusCode.NotFound
            };
        }

        public static IActionResult Failure(string message)
        {
            return new ObjectResult(new ErrorResponse { Success = false, Message = message })
            {
                StatusCode = (int)HttpStatusCode.BadRequest
            };
        }
    }
}
