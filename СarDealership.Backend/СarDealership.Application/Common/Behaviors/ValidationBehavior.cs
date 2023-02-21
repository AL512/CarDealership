using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using FluentValidation;

namespace СarDealership.Application.Common.Behaviors
{
    /// <summary>
    /// Процесс валидации во время запросов и команд
    /// </summary>
    /// <typeparam name="TRequest">Объект запроса, переданный через медиатор</typeparam>
    /// <typeparam name="TResponse">Объект ответа</typeparam>
    public class ValidationBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> where TRequest 
        : IRequest<TResponse>
    {
        /// <summary>
        /// Список объектов, подлежащих валидации
        /// </summary>
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        /// <summary>
        /// Процесс валидации во время запросов и команд
        /// </summary>
        /// <param name="validator">Список объектов, подлежащих валидации</param>
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) =>
            _validators = validators;

        /// <summary>
        /// Логика работы валидации
        /// </summary>
        /// <param name="request">Объект запроса, переданный через медиатор</param>
        /// <param name="next">Асинхронное продолжение следующего действия в цепочке</param>
        /// <param name="cancellationToken">Токен отмены задачи</param>
        /// <returns>Следующее действие в цепочке вызовов</returns>
        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(failure => failure != null)
                .ToList();
            if (failures.Count != 0)
            {
                throw new ValidationException(failures);
            }
            return next();
        }
    }
}
