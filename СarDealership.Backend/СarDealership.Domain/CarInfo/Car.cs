using System;
using СarDealership.Domain.Base;

namespace СarDealership.Domain.CarInfo
{
    /// <summary>
    /// Автомобиль
    /// </summary>
    public class Car : BaseEntity
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Мощность двигателя
        /// </summary>
        public int Pow { get; set; }
        /// <summary>
        /// Длина кузова
        /// </summary>
        public int Long { get; set; }
        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// Дата изменения
        /// </summary>
        public DateTime? EditDate { get; set; }
    }
}
