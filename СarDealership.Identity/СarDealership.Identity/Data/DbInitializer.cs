namespace СarDealership.Identity.Data
{
    /// <summary>
    /// Инициализирует БД
    /// </summary>
    public class DbInitializer
    {
        /// <summary>
        /// Инициализирует БД
        /// </summary>
        /// <param name="context">Контекст БД</param>
        public static void Initialize(AuthDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
