using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using СarDealership.Domain.CarInfo;

namespace СarDealership.Persistence.EntityTypeConfigurations
{
    /// <summary>
    /// Конфигурация сущности Car
    /// </summary>
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        /// <summary>
        /// Задает параметры конфигурации для Car
        /// </summary>
        /// <param name="builder">Билдер Car в EntityFramework</param>
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(car => car.Id);
            builder.HasIndex(car => car.Id).IsUnique();
            builder.Property(car => car.Name).HasMaxLength(250).IsRequired();
            builder.Property(car => car.Price).HasColumnType("money").HasPrecision(10, 2);
            builder.Property(p => p.Version).IsRowVersion();
        }
    }
}