using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using СarDealership.Application.Interfaces;
using СarDealership.Application.Common.Exceptions;
using СarDealership.Domain.CarInfo;

namespace СarDealership.Application.CarInfo.Commands.UpdateCar
{
    /// <summary>
    /// Обработчик команды изменения автомобиля
    /// </summary>
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand>
    {
        /// <summary>
        /// Контекст БД
        /// </summary>
        private readonly IСarDealershipDbContext _dbContext;

        /// <summary>
        /// Обработчик команды изменения автомобиля
        /// </summary>
        /// <param name="dbContext">Контекст БД</param>
        public UpdateCarCommandHandler(IСarDealershipDbContext dbContext) =>
            _dbContext = dbContext;

        /// <summary>
        /// Логика обработки команды
        /// </summary>
        /// <param name="request">Ответ на команду</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Пустой ответ</returns>
        public async Task<Unit> Handle(UpdateCarCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Cars.FirstOrDefaultAsync(car =>
                    car.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Car), request.Id);
            }
            entity.Name = request.Name;
            entity.Pow = request.Pow;
            entity.Long = request.Long;
            entity.Price = request.Price;

            entity.EditDate = DateTime.Now;

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    await transaction.CommitAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    // TODO: Обработка конфликтов параллелизма. Нужна ?
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                }
            }

            return Unit.Value;
        }
    }
}
