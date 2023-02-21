using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СarDealership.Application.CarInfo.Commands
{
    /// <summary>
    /// Основные элементы для всех команд создания
    /// </summary>
    public abstract class BaseCreateCommand : IRequest<Guid>
    {
        /// <summary>
        /// ИД пользователя
        /// </summary>
        public Guid UserId { get; set; }
    }
}
