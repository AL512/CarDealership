using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using СarDealership.Application.Interfaces;

namespace СarDealership.WebApi.Services
{
    /// <summary>
    /// Сервис текущего пользователя
    /// </summary>
    public class CurrentUserService : ICurrentUserService
    {
        /// <summary>
        /// Предоставляет доступ к текущему HTTP контексту
        /// </summary>
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Сервис текущего пользователя
        /// </summary>
        /// <param name="httpContextAccessor">доступ к текущему HTTP контексту</param>
        public CurrentUserService(IHttpContextAccessor httpContextAccessor) =>
            _httpContextAccessor = httpContextAccessor;

        /// <summary>
        /// Ид пользователя
        /// </summary>
        public Guid UserId
        {
            get
            {
                var id = _httpContextAccessor.HttpContext?.User?
                    .FindFirstValue(ClaimTypes.NameIdentifier);
                return string.IsNullOrEmpty(id) ? Guid.Empty : Guid.Parse(id);
            }
        }
    }
}
