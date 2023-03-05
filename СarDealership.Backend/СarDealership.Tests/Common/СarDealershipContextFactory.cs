using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using СarDealership.Domain;
using СarDealership.Domain.CarInfo;
using СarDealership.Persistence;

namespace СarDealership.Tests.Common
{
    public class CarsContextFactory
    {
        /// <summary>
        /// ИД пользователя А
        /// </summary>
        public static Guid UserAId = Guid.NewGuid();
        /// <summary>
        /// ИД пользователя В
        /// </summary>
        public static Guid UserBId = Guid.NewGuid();

        /// <summary>
        /// ИД автомобиля для удаления
        /// </summary>
        public static Guid CarIdForDelete = Guid.NewGuid();
        /// <summary>
        /// ИД автомобиля для обновления
        /// </summary>
        public static Guid CarIdForUpdate = Guid.NewGuid();

        /// <summary>
        /// Создаем контекст ДБ для тестирования
        /// </summary>
        /// <returns>Контекст ДБ для тестирования</returns>
        public static СarDealershipDbContext Create()
        {
            var options = new DbContextOptionsBuilder<СarDealershipDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;
            var context = new СarDealershipDbContext(options);
            context.Database.EnsureCreated();
            context.Cars.AddRange(
                new Car
                {
                    CreationDate = DateTime.Today,
                    EditDate = null,
                    Id = Guid.Parse("A6BB65BB-5AC2-4AFA-8A28-2616F675B825"),
                    Name = "ВАЗ 2109",
                    UserId = UserAId
                },
                new Car
                {
                    CreationDate = DateTime.Today,
                    EditDate = null,
                    Id = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084"),
                    Name = "Toyota Corolla",
                    UserId = UserBId
                },
                new Car
                {
                    CreationDate = DateTime.Today,
                    EditDate = null,
                    Id = CarIdForDelete,
                    Name = "Porsche 911",
                    UserId = UserAId
                },
                new Car
                {
                    CreationDate = DateTime.Today,
                    EditDate = null,
                    Id = CarIdForUpdate,
                    Name = "Ford Focus",
                    UserId = UserBId
                }
            );
            context.SaveChanges();
            return context;
        }
        /// <summary>
        /// Удаляет контекст ДБ для тестирования
        /// </summary>
        /// <param name="context">Контекст ДБ для тестирования</param>
        public static void Destroy(СarDealershipDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
