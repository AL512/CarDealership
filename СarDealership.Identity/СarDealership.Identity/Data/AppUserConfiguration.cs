using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using СarDealership.Identity.Models;

namespace СarDealership.Identity.Data
{
    /// <summary>
    /// Конфигурация сущности AppUser
    /// </summary>
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        /// <summary>
        /// Задает параметры конфигурации для AppUser
        /// </summary>
        /// <param name="builder">Билдер AppUser в EntityFramework</param>
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
