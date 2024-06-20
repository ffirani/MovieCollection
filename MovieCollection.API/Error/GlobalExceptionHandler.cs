
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace MovieCollection.API.Error
{
    public class GlobalExceptionHandler : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;
        private readonly IConfiguration _config;
        public GlobalExceptionHandler(IConfiguration config,ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
            _config = config;
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
            var isDebugMode = _config.GetValue<bool>("IsDebugMode");
            var response = new ErrorResponse();
            if (ex is AppException currentException)
            {
                response.ErrorCode = currentException.ErrorCode;
                response.Message = currentException.Message;
                response.ErrorDetail = isDebugMode ? currentException.ToString() : string.Empty;
            }
            else if (ex is FluentValidation.ValidationException validationException)
            {
                response.ErrorCode = "ERR5001";
                response.Message = "Validation Error";
                response.ErrorDetail = isDebugMode ? validationException.ToString() : string.Empty;
            }
            else
            {
                response.ErrorCode = "ERR10000";
                response.Message = "Unexpected error occured.";
                response.ErrorDetail = isDebugMode ? ex.ToString():string.Empty;
            }
            
            
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
        
    }
}
