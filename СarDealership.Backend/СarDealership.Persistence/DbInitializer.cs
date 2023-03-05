using System;
using СarDealership.Domain.CarInfo;

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
            context.Cars.AddRange(
                new Car
                {
                    Name = "ВАЗ 2109",
                    UserId = Guid.Parse("98D51994-5CC4-44E2-B720-69FF4915EA42"),
                    Pow = 98,
                    Long = 3970,
                    Price = 45787
                },
                new Car
                {
                    Name = "Toyota Corolla",
                    UserId = Guid.Parse("98D51994-5CC4-44E2-B720-69FF4915EA42"),
                    Pow = 127,
                    Long = 4098,
                    Price = 748512
                });
            context.SaveChanges();
        }
    }
}
