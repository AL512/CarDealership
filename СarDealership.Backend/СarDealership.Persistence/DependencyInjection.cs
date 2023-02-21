using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using СarDealership.Application.Interfaces;

namespace СarDealership.Persistence
{
    /// <summary>
    /// Внедряет зависимости
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Добавляет контекст БД и регистрирует его
        /// </summary>
        /// <param name="services">Коллекция служб</param>
        /// <param name="configuration">Конфиг приложения</param>
        /// <returns>Коллекция служб</returns>
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<СarDealershipDbContext>(options =>
            {
                // TODO : Переделать БД на MS SQl local
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IСarDealershipDbContext>(provider =>
                provider.GetService<СarDealershipDbContext>());
            return services;
        }
    }
}
