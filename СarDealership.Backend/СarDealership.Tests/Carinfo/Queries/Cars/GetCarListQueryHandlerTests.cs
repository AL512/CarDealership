using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using СarDealership.Application.CarInfo.Queries.GetCarList;
using СarDealership.Persistence;
using СarDealership.Tests.Common;
using Shouldly;
using Xunit;

namespace СarDealership.Tests.Carinfo.Queries.Cars
{
    /// <summary>
    /// Тестирование обработчика запроса списка автомобилей
    /// </summary>
    [Collection("QueryCollection")]
    public class GetCarListQueryHandlerTests
    {
        /// <summary>
        /// Контекст БД
        /// </summary>
        private readonly СarDealershipDbContext Context;
        /// <summary>
        /// Маппер
        /// </summary>
        private readonly IMapper Mapper;
        /// <summary>
        /// Тестирование обработчика запроса списка автомобилей
        /// </summary>
        /// <param name="fixture">Вспомогательный класс проверки запросов</param>
        public GetCarListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }
        /// <summary>
        /// Проверяет успешное получение списка автомобилей
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetCarListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetCarListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetCarListQuery
                {
                    UserId = CarsContextFactory.UserBId
                },
                CancellationToken.None);

            // Assert
            // ShouldBe - "должен быть". Из Shouldly
            result.ShouldBeOfType<CarList>();
            result.Cars.Count.ShouldBe(4);
        }
    }
}
