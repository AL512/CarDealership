using System;
using FluentValidation;

namespace СarDealership.Application.CarInfo.Queries.GetCarList
{
    /// <summary>
    /// Валидация данных запроса списка автомобилей
    /// </summary>
    public class GetCarListQueryValidator : AbstractValidator<GetCarListQuery>
    {
        /// <summary>
        /// Валидация данных запроса списка автомобилей
        /// </summary>
        public GetCarListQueryValidator()
        {
            RuleFor(contryList => contryList.UserId).NotEqual(Guid.Empty);
        }
    }
}
