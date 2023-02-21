using Microsoft.AspNetCore.Builder;

namespace СarDealership.WebApi.Middleware
{
    /// <summary>
    /// Расширения CustomExceptionHandlerMiddleware для включения в конвейер
    /// </summary>
    public static class CustomExceptionHandlerMiddlewareExtensions
    {
        /// <summary>
        /// Расширения CustomExceptionHandlerMiddleware для включения в конвейер
        /// </summary>
        /// <param name="builder">IApplicationBuilder</param>
        /// <returns></returns>
        public static IApplicationBuilder UseCustomExceptionHandler(this
            IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}
