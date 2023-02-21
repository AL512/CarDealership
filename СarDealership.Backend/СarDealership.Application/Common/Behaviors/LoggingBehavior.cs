using Serilog;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using СarDealership.Application.Interfaces;

namespace СarDealership.Application.Common.Behaviors
{
    /// <summary>
    /// Описывает поведение логгирования
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public class LoggingBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> where TRequest
        : IRequest<TResponse>
    {
        /// <summary>
        /// Сведения о текущем пользователе
        /// </summary>
        ICurrentUserService _currentUserService;
        /// <summary>
        /// Описывает поведение логгирования
        /// </summary>
        /// <param name="currentUserService">Сведения о текущем пользователе в http контексте</param>
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var userId = _currentUserService?.UserId;

            Log.Information("СarDealership Request: {Name} {@UserId} {@Request}",
                requestName, userId, request);

            var response = await next();

            return response;
        }
    }
}
