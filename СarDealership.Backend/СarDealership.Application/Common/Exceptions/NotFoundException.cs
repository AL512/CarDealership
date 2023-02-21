using System;

namespace СarDealership.Application.Common.Exceptions
{
    /// <summary>
    /// Ошибка нахождения сущности в БД
    /// </summary>
    public class NotFoundException : Exception
    {
        /// <summary>
        /// КОшибка нахождения сущности в БД
        /// </summary>
        /// <param name="name">Название сущности</param>
        /// <param name="key">Параметр сущности</param>
        public NotFoundException(string name, object key)
            : base($"Entity \"{name}\" ({key}) not found.") { }
    }
}
