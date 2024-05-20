using Application.Wrappers;
using System.Net;
using System.Text.Json;

namespace WebApi.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
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
            catch (Exception exception)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new Response<string>() { Succeded = false, Message = exception?.Message };

                string method = context.Request.Method;
                string path = context.Request.Path.Value!;

                switch (exception)
                {
                    case Application.Exceptions.ApiException e:
                        // Custom application error API
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        _logger.LogWarning($"Custom Api: {e}");
                        _logger.LogWarning($"[Custom Api] Method: {method}; Path: {path}; {e.Message}");
                        break;
                    case Application.Exceptions.ValidationException e:
                        // Custom application error Validation
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Errors = e.Errors;
                        _logger.LogWarning($"[Custom Validation] Method: {method}; Path: {path}; {e.Message}; Errors: { String.Join(",", e.Errors) }");
                        break;
                    case KeyNotFoundException e:
                        // Not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        _logger.LogWarning($"[Not Found] Method: {method}; Path: {path}; {e.Message}; {e.InnerException?.Message}");
                        break;
                    default:
                        // Unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        responseModel.Message += exception?.InnerException;
                        _logger.LogWarning($"[Error] Method: {method}; Path: {path}; {exception?.InnerException?.Message}");
                        break;
                }

                var result = JsonSerializer.Serialize(responseModel);

                await response.WriteAsync(result);
            }
        }
    }
}
