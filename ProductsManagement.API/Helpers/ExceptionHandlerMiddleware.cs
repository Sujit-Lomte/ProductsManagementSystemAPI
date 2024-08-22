using ProductsManagement.API.Models.Core;
using ProductsManagement.API.Models.Response;
using System.Net;
using System.Text.Json;

namespace ProductsManagement.API.Helpers
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;

                response.ContentType = "application/json";

                switch (error)
                {
                    case AppException:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        _logger.LogError(error, error.Message);
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(new ErrorResponse { Success = false, Message = error?.Message, StatusCode = HttpStatusCode.InternalServerError });

                await response.WriteAsync(result);
            }
        }
    }
}
