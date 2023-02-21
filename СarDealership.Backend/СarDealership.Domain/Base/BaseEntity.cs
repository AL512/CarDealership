using System;

namespace СarDealership.Domain.Base
{
    /// <summary>
    /// Основные элементы для всех сущностей
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Основной идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// ИД пользователя
        /// </summary>
        public Guid UserId { get; set; }
    }
}
