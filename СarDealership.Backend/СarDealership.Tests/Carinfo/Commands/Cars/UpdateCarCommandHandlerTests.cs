using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using СarDealership.Application.Common.Exceptions;
using СarDealership.Application.CarInfo.Commands.UpdateCar;
using СarDealership.Tests.Common;
using Xunit;

namespace СarDealership.Tests.Carinfo.Commands.Cars
{
    /// <summary>
    /// Тестирование обработчика команд обновления автомобиля
    /// </summary>
    public class UpdateCarCommandHandlerTests : TestCommandBase
    {
        /// <summary>
        /// Проверяет успешное обновления автомобиля
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task UpdateCarCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateCarCommandHandler(Context);
            var updatedName = "Ford Mondeo";

            // Act
            await handler.Handle(new UpdateCarCommand
            {
                Id = CarsContextFactory.CarIdForUpdate,
                UserId = CarsContextFactory.UserBId,
                Name = updatedName
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Cars.SingleOrDefaultAsync(car =>
                car.Id == CarsContextFactory.CarIdForUpdate &&
                car.Name == updatedName));
        }
        // <summary>
        /// Проверяет появления исключения "NotFoundException"
        /// при обновлении автомобиля с ID, которого нет в БД
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task UpdateCarCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateCarCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateCarCommand
                    {
                        Id = Guid.NewGuid(),
                        UserId = CarsContextFactory.UserAId
                    },
                    CancellationToken.None));
        }
        
        // TODO : Добавить проверку по ролям

    }
}
