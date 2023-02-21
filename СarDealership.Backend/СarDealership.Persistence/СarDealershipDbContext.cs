using Microsoft.EntityFrameworkCore;
using СarDealership.Application.Interfaces;
using СarDealership.Domain.CarInfo;
using СarDealership.Persistence.EntityTypeConfigurations;

namespace СarDealership.Persistence
{
    /// <summary>
    /// Реализация контекста БД
    /// </summary>
    public class СarDealershipDbContext : DbContext, IСarDealershipDbContext
    {
        public DbSet<Car> Cars { get; set; }

        /// <summary>
        /// Реализация контекста БД
        /// </summary>
        /// <param name="options">Параметры контекста</param>
        public СarDealershipDbContext(DbContextOptions<СarDealershipDbContext> options)
            : base(options) { }

        /// <summary>
        /// Настраиваем схему
        /// </summary>
        /// <param name="builder">Методы для конфигурации сущностей и отношений между ними</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CarConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
