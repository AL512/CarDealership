using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using СarDealership.Application.Common.Exceptions;
using СarDealership.Application.CarInfo.Commands.DeleteCar;
using СarDealership.Application.CarInfo.Commands.CreateCar;
using СarDealership.Tests.Common;
using Xunit;

namespace СarDealership.Tests.Carinfo.Commands.Cars
{
    /// <summary>
    /// Тестирование обработчика команд удаления автомобиля
    /// </summary>
    public class DeleteCarCommandHandlerTests : TestCommandBase
    {
        /// <summary>
        /// Проверяет успешное удаление автомобиля по ID
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task DeleteCarCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteCarCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteCarCommand
            {
                Id = CarsContextFactory.CarIdForDelete,
                UserId = CarsContextFactory.UserAId
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Cars.SingleOrDefault(car =>
                car.Id == CarsContextFactory.CarIdForDelete));
        }

        /// <summary>
        /// Проверяет появления исключения "NotFoundException"
        /// при удаление автомобиля с ID, которого нет в БД
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task DeleteCarCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteCarCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteCarCommand
                    {
                        Id = Guid.NewGuid(),
                        UserId = CarsContextFactory.UserAId
                    },
                    CancellationToken.None));
        }
    }
}
