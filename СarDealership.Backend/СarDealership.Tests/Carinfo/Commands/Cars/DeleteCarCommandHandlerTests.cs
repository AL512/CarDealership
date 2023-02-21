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

        // TODO : <_> Проверяет появления исключения "NotFoundException" при удаление автомобиля пользователем, который его не создавал. Переделать логику
        // TODO : Добавить проверку по ролям
        /*/// <summary>
        /// Проверяет появления исключения "NotFoundException"
        /// при удаление автомобиля пользователем, который его не создавал
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task DeleteCarCommandHandler_FailOnWrongUserId()
        {
            
            // Arrange
            var deleteHandler = new DeleteCarCommandHandler(Context);
            var createHandler = new CreateCarCommandHandler(Context);
            var carId = await createHandler.Handle(
                new CreateCarCommand
                {
                    Name = "CarName",
                    UserId = CarsContextFactory.UserAId
                }, CancellationToken.None);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await deleteHandler.Handle(
                    new DeleteCarCommand
                    {
                        Id = carId,
                        UserId = CarsContextFactory.UserBId
                    }, CancellationToken.None));
        }*/
    }
}
