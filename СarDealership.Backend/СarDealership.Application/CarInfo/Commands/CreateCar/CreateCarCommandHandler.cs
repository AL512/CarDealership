using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using СarDealership.Application.Interfaces;
using СarDealership.Domain.CarInfo;

namespace СarDealership.Application.CarInfo.Commands.CreateCar
{
    /// <summary>
    /// Обработчик команды добавления автомобиля
    /// </summary>
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Guid>
    {
        /// <summary>
        /// Контекст БД
        /// </summary>
        private readonly IСarDealershipDbContext _dbContext;

        /// <summary>
        /// Обработчик команды добавления автомобиля
        /// </summary>
        /// <param name="dbContext">Контекст БД</param>
        public CreateCarCommandHandler(IСarDealershipDbContext dbContext) =>
            _dbContext = dbContext;

        /// <summary>
        /// Логика обработки команды
        /// </summary>
        /// <param name="request">Ответ на команду</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>ИД автомобиля в БД</returns>
        public async Task<Guid> Handle(CreateCarCommand request,
            CancellationToken cancellationToken)
        {
            var car = new Car
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                Name = request.Name,
                Pow = request.Pow,
                Long = request.Long,
                Price = request.Price,
                CreationDate = DateTime.Now,
                EditDate = null
            };

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    await _dbContext.Cars.AddAsync(car, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                }
            }
            return car.Id;
        }
    }
}
