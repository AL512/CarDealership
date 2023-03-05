using System;
using FluentValidation;

namespace СarDealership.Application.CarInfo.Commands.CreateCar
{
    /// <summary>
    /// Валидация данных команды создания автомобиля
    /// </summary>
    public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
    {
        /// <summary>
        /// Валидация данных команды создания автомобиля
        /// </summary>
        public CreateCarCommandValidator()
        {
            RuleFor(command => command.Name).NotEmpty().MaximumLength(250);
            RuleFor(command => command.UserId).NotEqual(Guid.Empty);
            RuleFor(command => command.Pow).GreaterThan(0);
            RuleFor(command => command.Long).GreaterThan(0);
            RuleFor(command => command.Price).GreaterThan(0);
        }
    }
}
