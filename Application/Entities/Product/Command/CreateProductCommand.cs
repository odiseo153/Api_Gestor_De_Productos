

using Application;
using Gestor_Productos.Application.Entities.Product.Validation;
using Gestor_Productos.Application.Entities.User.Validation;
using Gestor_Productos.Domain.Entities;
using Gestor_Productos.Infraestructure.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gestor_Productos.Application.Entities.Product.Command
{
    public class CreateProductCommand : IRequest<IActionResult>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string CategoryId { get; set; }
    }
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, IActionResult>
    {
        public BaseRepository<Products> repository;

        public CreateProductHandler(BaseRepository<Products> repository)
        {
            this.repository = repository;
        }
        
        public async Task<IActionResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = MapperControl.mapper.Map<Products>(request);

            var validation = await new CreateProductValidation().ValidateAsync(request);

            if (!validation.IsValid)
            {
                return new JsonResult(validation.Errors);
            }

            var response = await repository.Create(product);
            
            return new JsonResult(response);
        }

    }
}
