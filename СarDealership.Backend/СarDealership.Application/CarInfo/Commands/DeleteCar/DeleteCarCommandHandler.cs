using System.Threading;
using System.Threading.Tasks;
using MediatR;
using СarDealership.Application.Interfaces;
using СarDealership.Application.Common.Exceptions;
using СarDealership.Domain.CarInfo;

namespace СarDealership.Application.CarInfo.Commands.DeleteCar
{
    /// <summary>
    /// Обработчик команды удаления автомобиля
    /// </summary>
    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand>
    {
        /// <summary>
        /// Контекст БД
        /// </summary>
        private readonly IСarDealershipDbContext _dbContext;
        /// <summary>
        /// Обработчика команды удаления автомобиля
        /// </summary>
        /// <param name="dbContext">Контекст БД</param>
        public DeleteCarCommandHandler(IСarDealershipDbContext dbContext) =>
            _dbContext = dbContext;

        /// <summary>
        /// Логика обработки команды
        /// </summary>
        /// <param name="request">Ответ на команду</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Пустой ответ</returns>
        public async Task<Unit> Handle(DeleteCarCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Cars
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Car), request.Id);
            }

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.Cars.Remove(entity);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                }
            }
            return Unit.Value;
        }
    }
}
