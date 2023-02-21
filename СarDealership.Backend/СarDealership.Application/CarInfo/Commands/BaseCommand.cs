using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СarDealership.Application.CarInfo.Commands
{
    /// <summary>
    /// Основные элементы для команд delete/update
    /// </summary>
    public abstract class BaseCommand : IRequest
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
