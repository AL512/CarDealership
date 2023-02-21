using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using СarDealership.Application.CarInfo.Commands.CreateCar;
using СarDealership.Tests.Common;
using Xunit;

namespace СarDealership.Tests.Carinfo.Commands.Cars
{
    /// <summary>
    /// Тестирование обработчика команд создания автомобиля
    /// </summary>
    public class CreateCarCommandHandlerTests : TestCommandBase
    {
        // TODO : Деталлизировать и дополнить тесты
        /// <summary>
        /// Проверяет успешное создание автомобиля
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateCarCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateCarCommandHandler(Context);
            var carName = "Honda Accord";

            // Act
            var carId = await handler.Handle(
                new CreateCarCommand
                {
                    Name = carName,
                    UserId = CarsContextFactory.UserAId
                },
                CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Cars.SingleOrDefaultAsync(car =>
                    car.Id == carId && car.Name == carName));
        }
    }
}
