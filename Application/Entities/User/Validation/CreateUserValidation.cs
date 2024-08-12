using FluentValidation;
using Gestor_Productos.Application.Entities.User.Command;

namespace Gestor_Productos.Application.Entities.User.Validation
{


public class CreateUserValidation : AbstractValidator<CreateUserCommand>
{
    public CreateUserValidation() {

        RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty()
                .NotNull()
                .MinimumLength(3);

            RuleFor(x => x.Name)
                    .NotEmpty()
                    .NotNull()
                    .MinimumLength(3);

            RuleFor(x => x.Password)
            .NotEmpty()
            .NotNull()
            .MinimumLength(3);

            RuleFor(x => x.Rol)
            .NotEmpty()
            .NotNull();

        }
}

}