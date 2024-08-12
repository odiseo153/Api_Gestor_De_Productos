
using FluentValidation;
using Gestor_Productos.Application.Entities.Orders.Command;

namespace Gestor_Productos.Application.Entities.Orders.Validation
{
    public class CreateOrderValidation : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderValidation()
        {
            RuleFor(x => x.Total)
                    .NotEmpty()
                    .NotNull();

            RuleFor(x => x.UserId)
                    .NotEmpty()
                    .NotNull();

            RuleFor(x => x.ProductId)
                    .NotEmpty()
                    .NotNull();

        }
    }
}
