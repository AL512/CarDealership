using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using СarDealership.Domain.CarInfo;

namespace СarDealership.Application.Interfaces
{
    /// <summary>
    /// Интерфейс для контекста автомобилей
    /// </summary>
    public interface IСarDbContext
    {
        /// <summary>
        /// Контекст автомобилей
        /// </summary>
        // TODO : Вынести DbSet<Car> Cars и другое в отдельные интерфейсы?
        DbSet<Car> Cars { get; set; }
    }
}
