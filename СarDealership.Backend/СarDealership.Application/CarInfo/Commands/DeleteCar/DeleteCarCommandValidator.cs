using System;
using FluentValidation;

namespace СarDealership.Application.CarInfo.Commands.DeleteCar
{
    public class DeleteCarCommandValidator : AbstractValidator<DeleteCarCommand>
    {
        /// <summary>
        /// Валидация данных команды удаления автомобиля
        /// </summary>
        public DeleteCarCommandValidator()
        {
            RuleFor(command => command.Id).NotEqual(Guid.Empty);
            RuleFor(command => command.UserId).NotEqual(Guid.Empty);
        }
    }
}
