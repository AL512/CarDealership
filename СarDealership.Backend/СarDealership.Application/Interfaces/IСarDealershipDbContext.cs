using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using СarDealership.Domain.CarInfo;

namespace СarDealership.Application.Interfaces
{
    /// <summary>
    /// Основной интерфейс для контекста БД
    /// </summary>
    public interface IСarDealershipDbContext
    {
        /// <summary>
        /// Контекст автомобилей
        /// </summary>
        // TODO : Вынести DbSet<Car> Cars и другое в отдельные интерфейсы?
        DbSet<Car> Cars { get; set; }
        /// <summary>
        /// Ассинхронное сохранение изменений контекста в БД
        /// </summary>
        /// <param name="cancellationToken">Токен отмены задачи</param>
        /// <returns>Количество записей состояния, записанных в базу данных</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
