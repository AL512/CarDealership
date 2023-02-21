using System;
using MediatR;

namespace СarDealership.Application.CarInfo.Commands.UpdateCar
{
    /// <summary>
    /// Команда обновления автомоюиля
    /// </summary>
    public class UpdateCarCommand : BaseCommand
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
    }
}
