using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using СarDealership.Identity.Models;

namespace СarDealership.Identity.Data
{
    /// <summary>
    /// Контекст БД пользователей
    /// </summary>
    public class AuthDbContext : IdentityDbContext<AppUser>
    {
        /// <summary>
        /// Контекст БД пользователей
        /// </summary>
        /// <param name="options"></param>
        public AuthDbContext(DbContextOptions<AuthDbContext> options)
            : base(options) { }
        /// <summary>
        /// Настраиваем схему
        /// </summary>
        /// <param name="builder">Методы для конфигурации сущностей и отношений между ними</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>(entity => entity.ToTable(name: "Users"));
            builder.Entity<IdentityRole>(entity => entity.ToTable(name: "Roles"));
            builder.Entity<IdentityUserRole<string>>(entity =>
                entity.ToTable(name: "UserRoles"));
            builder.Entity<IdentityUserClaim<string>>(entity =>
                entity.ToTable(name: "UserClaim"));
            builder.Entity<IdentityUserLogin<string>>(entity =>
                entity.ToTable("UserLogins"));
            builder.Entity<IdentityUserToken<string>>(entity =>
                entity.ToTable("UserTokens"));
            builder.Entity<IdentityRoleClaim<string>>(entity =>
                entity.ToTable("RoleClaims"));

            builder.ApplyConfiguration(new AppUserConfiguration());
        }
    }
}
