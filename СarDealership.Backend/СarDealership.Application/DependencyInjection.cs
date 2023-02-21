using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using СarDealership.Application.Common.Behaviors;

namespace СarDealership.Application
{
    /// <summary>
    /// Внедряет зависимостей
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Добавление зависимостей в сервисы и регистрирует их
        /// </summary>
        /// <param name="services">Коллекция служб</param>
        /// <returns>Коллекция служб</returns>
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            // Регистрируем медиатор
            services.AddMediatR(Assembly.GetExecutingAssembly());
            // Регистрируем процесс валидации
            services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            // Регистрируем ValidationBehavior, как реализацию IPipelineBehavior
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            // Регистрируем LoggingBehavior, как реализацию IPipelineBehavior
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            return services;
        }
    }
}
