using System;

namespace СarDealership.Application.Interfaces
{
    /// <summary>
    /// Получение сведений о текущем пользователе
    /// </summary>
    public interface ICurrentUserService
    {
        /// <summary>
        /// ИД пользователя
        /// </summary>
        Guid UserId { get; }
    }
}
