using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using СarDealership.Domain.CarInfo;

namespace СarDealership.Application.Interfaces
{
    /// <summary>
    /// Основной интерфейс для контекста БД
    /// </summary>
    public interface IСarDealershipDbContext : IСarDbContext
    {
        /// <summary>
        /// Предоставляет доступ к информации и операциям, связанным с базой данных, для контекста
        /// </summary>
        DatabaseFacade Database { get; }
        /// <summary>
        /// Ассинхронное сохранение изменений контекста в БД
        /// </summary>
        /// <param name="cancellationToken">Токен отмены задачи</param>
        /// <returns>Количество записей состояния, записанных в базу данных</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
