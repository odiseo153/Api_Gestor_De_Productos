using FluentValidation;
using Gestor_Productos.Application.Entities.CartDetail.Command;



namespace Gestor_Productos.Application.Entities.CartDetail.Validation
{
    public class CreateCartDetailValidation : AbstractValidator<CreateCartDetailsCommand>
    {
        public CreateCartDetailValidation() 
        {
            RuleFor(x => x.UserId)
            .NotEmpty()
            .NotNull();

            RuleFor(x => x.ProductId)
            .NotEmpty()
            .NotNull();

            RuleFor(x => x.Amount)
            .NotEmpty()
            .NotNull();
        }

    }
}
