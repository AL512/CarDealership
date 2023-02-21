using System;
using System.Threading.Tasks;
using System.Net;
using System.Text.Json;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using СarDealership.Application.Common.Exceptions;

namespace СarDealership.WebApi.Middleware
{
    /// <summary>
    /// Пользовательское промежуточное ПО обработки исключений
    /// </summary>
    public class CustomExceptionHandlerMiddleware
    {
        /// <summary>
        /// Следующей делегат запроса в конвейере
        /// </summary>
        private readonly RequestDelegate _next;
        /// <summary>
        /// Пользовательское промежуточное ПО обработки исключений
        /// </summary>
        /// <param name="next">Следующей делегат запроса в конвейере</param>
        public CustomExceptionHandlerMiddleware(RequestDelegate next) =>
            _next = next;
        
        /// <summary>
        /// Пытается вызвать делегат, перехватывает и обрабатывает исключения, если они есть
        /// </summary>
        /// <param name="context">Контекст</param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }
        /// <summary>
        /// Обработка исключений
        /// </summary>
        /// <param name="context">Контекст</param>
        /// <param name="exception">Исключение</param>
        /// <returns></returns>
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Код ответа
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;
            switch(exception)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.Errors);
                    break;
                case NotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (result == string.Empty)
            {
                result = JsonSerializer.Serialize(new { errpr = exception.Message });
            }

            return context.Response.WriteAsync(result);
        }
    }
}
