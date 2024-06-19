
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.Identity.Client;
using System.Net;
using System.Text.Json;

namespace MovieCollection.API.Error
{
    public class GlobalExceptionHandler : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch(AppException ex)
            {
                _logger.LogError(ex,ex.Message);
                await HandleExceptionAsync(context, ex);
            }
            catch(AggregateException ex)
            {
                _logger.LogError($"Unexpected Error:\r\n{ex.Flatten()}");
                await HandleExceptionAsync(context, ex.Flatten());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unexpected Error:\r\n{ex}");
                await HandleExceptionAsync(context, ex);
            }
            
        }
        public async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            var response = new ErrorResponse();
            if (ex is AppException currentException)
            {
                response.ErrorCode = currentException.ErrorCode;
                response.Message = currentException.Message;
                response.ErrorDetail = currentException.ToString();
            }
            else
            {
                response.ErrorCode = "10000000";
                response.Message = "Unexpected error occured.";
                response.ErrorDetail = ex.ToString();
            }
            
            
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
        
    }
}
