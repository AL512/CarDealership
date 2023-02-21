using System;
using MediatR;

namespace СarDealership.Application.CarInfo.Queries.GetCarList
{
    /// <summary>
    /// Запрос списка автомобилей
    /// </summary>
    public class GetCarListQuery : IRequest<CarList>
    {
        /// <summary>
        /// ИД пользователя
        /// </summary>
        public Guid UserId { get; set; }
    }
}
