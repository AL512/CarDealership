using System;
using FluentValidation;

namespace СarDealership.Application.CarInfo.Commands.UpdateCar
{
    /// <summary>
    /// Валидация данных команды обновления автомобиля
    /// </summary>
    public class UpdateCarCommandValidator : AbstractValidator<UpdateCarCommand>
    {
        /// <summary>
        /// Валидация данных команды обновления автомобиля
        /// </summary>
        public UpdateCarCommandValidator()
        {
            RuleFor(command => command.Id).NotEqual(Guid.Empty);
            RuleFor(command => command.UserId).NotEqual(Guid.Empty);
            RuleFor(command => command.Name).NotEmpty().MaximumLength(250);
            RuleFor(command => command.Pow).GreaterThan(0);
            RuleFor(command => command.Long).GreaterThan(0);
            RuleFor(command => command.Price).GreaterThan(0);
        }
    }
}
