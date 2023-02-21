using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
using СarDealership.Application.CarInfo.Queries.GetCarDetails;
using СarDealership.Persistence;
using СarDealership.Tests.Common;
using Shouldly;
using Xunit;

namespace СarDealership.Tests.Carinfo.Queries
{
    // <summary>
    /// Тестирование обработчика запроса автомобиля
    /// </summary>
    [Collection("QueryCollection")]
    public class GetCarDetailsQueryHandlerTests
    {
        /// <summary>
        /// Контекст заказов в БД
        /// </summary>
        private readonly СarDealershipDbContext Context;
        /// <summary>
        /// Маппер
        /// </summary>
        private readonly IMapper Mapper;
        /// <summary>
        /// Тестирование обработчика запроса автомобиля
        /// </summary>
        /// <param name="fixture">Вспомогательный класс проверки запросов</param>
        public GetCarDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        /// <summary>
        /// Проверяет успешное получение автомобиля
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetCarDetailsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetCarDetailsQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetCarDetailsQuery
                {
                    UserId = CarsContextFactory.UserBId,
                    Id = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084")
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<CarDetails>();
            result.Name.ShouldBe("Toyota Corolla");
            result.CreationDate.ShouldBe(DateTime.Today);
        }
    }
}
