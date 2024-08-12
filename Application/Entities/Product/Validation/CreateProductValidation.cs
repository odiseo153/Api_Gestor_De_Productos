using FluentValidation;
using Gestor_Productos.Application.Entities.Product.Command;

namespace Gestor_Productos.Application.Entities.Product.Validation
{
    public class CreateProductValidation : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidation() 
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3);

            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3);

            RuleFor(x => x.Price)
                .NotEmpty()
                .NotNull();


            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .NotNull();


        }    
    }
}
