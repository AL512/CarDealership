using System;
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace СarDealership.WebApi.Controllers
{
    /// <summary>
    /// Основа для контроллеров
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        /// <summary>
        /// Медиатор
        /// </summary>
        private IMediator _mediator;
        /// <summary>
        /// Медиатор для формирования команд при выполнении запросов
        /// </summary>
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        /// <summary>
        /// ИД пользователя от сервера идентификации
        /// </summary>
        internal Guid UserId => !User.Identity.IsAuthenticated
            ? Guid.Empty
            : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        // TODO : Получать роль пользователя
    }
}
