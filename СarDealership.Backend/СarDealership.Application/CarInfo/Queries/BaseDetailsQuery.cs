using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СarDealership.Application.CarInfo.Queries
{
    /// <summary>
    /// Базовый класс детального запросса
    /// </summary>
    public abstract class BaseDetailsQuery<T> : IRequest<T>
    {
        /// <summary>
        /// ИД
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// ИД пользователя
        /// </summary>
        public Guid UserId { get; set; }
    }
}
