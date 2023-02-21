using System;
using FluentValidation;
using СarDealership.Application.CarInfo.Queries.GetCarDetails;

namespace СarDealership.Application.CarInfo.Queries.GetCarDetails
{
    /// <summary>
    /// Валидация данных детального запроса автомобиля
    /// </summary>
    public class GetCarDetailsQueryValidator : AbstractValidator<GetCarDetailsQuery>
    {
        /// <summary>
        /// Валидация данных детального запроса автомобиля
        /// </summary>
        public GetCarDetailsQueryValidator()
        {
            RuleFor(contry => contry.Id).NotEqual(Guid.Empty);
            RuleFor(contry => contry.UserId).NotEqual(Guid.Empty);
        }
    }
}
