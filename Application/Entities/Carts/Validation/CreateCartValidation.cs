using FluentValidation;
using Gestor_Productos.Application.Entities.Carts.Command;

namespace Gestor_Productos.Application.Entities.Carts.Validation
{
    public class CreateCartValidation : AbstractValidator<CreateCartCommand>
    {
        public CreateCartValidation()
        {
            RuleFor(x => x.UsuarioId)
                .NotEmpty()
                .NotNull();
        }
    }
}
