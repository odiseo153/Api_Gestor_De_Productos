using Application;
using Gestor_Productos.Application.Entities.Carts.Validation;
using Gestor_Productos.Application.Entities.User.Validation;
using Gestor_Productos.Domain.Entities;
using Gestor_Productos.Infraestructure.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_Productos.Application.Entities.Carts.Command
{
    public class CreateCartCommand : IRequest<IActionResult>
    {
        public string UsuarioId { get; set; }
    }

    public class CreateCartHandler : IRequestHandler<CreateCartCommand,IActionResult>
    {
        public BaseRepository<Cart> repository;

        public CreateCartHandler(BaseRepository<Cart> repository)
        {
            this.repository = repository;
        }

        public async Task<IActionResult> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            var cart = MapperControl.mapper.Map<Cart>(request);
            var validation = await new CreateCartValidation().ValidateAsync(request);

            if (!validation.IsValid)
            {
                return new JsonResult(validation.Errors);
            }

            return new JsonResult(await repository.Create(cart));
        }
    }

}
