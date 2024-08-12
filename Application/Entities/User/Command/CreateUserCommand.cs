using Application;
using Gestor_Productos.Application.Entities.User.Validation;
using Gestor_Productos.Domain.Entities;
using Gestor_Productos.Domain.Enums;
using Gestor_Productos.Infraestructure.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gestor_Productos.Application.Entities.User.Command
{
    public class CreateUserCommand : IRequest<IActionResult>
    {
        public string Name { get; set; }
        public string  Email { get; set; }
        public Roles Rol { get; set; }
        public string Password { get; set; }
    }

    public class CreateUserHandler : IRequestHandler<CreateUserCommand, IActionResult>
    {
        public BaseRepository<Users> repository;

        public CreateUserHandler(BaseRepository<Users> repository)
        {
            this.repository = repository;
        }


        public async Task<IActionResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = MapperControl.mapper.Map<Users>(request);

            var validation = await new CreateUserValidation().ValidateAsync(request);

            if (!validation.IsValid)
            {
                return new JsonResult(validation.Errors);
            }

            var response =await repository.Create(user);

            return new JsonResult(response);
        }
    }
}
