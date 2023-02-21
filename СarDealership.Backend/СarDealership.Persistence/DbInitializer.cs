namespace СarDealership.Persistence
{
    /// <summary>
    /// Инициализация БД
    /// </summary>
    public class DbInitializer
    {
        /// <summary>
        /// Инициализация БД
        /// </summary>
        /// <param name="context">Контекст Бд</param>
        public static void Initialize(СarDealershipDbContext context)
        {
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
