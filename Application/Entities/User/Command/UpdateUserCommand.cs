using Application;
using Gestor_Productos.Domain.Entities;
using Gestor_Productos.Domain.Enums;
using Gestor_Productos.Infraestructure.Repository;
using MediatR;

namespace Gestor_Productos.Application.Entities.User.Command
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public Roles? Rol { get; set; }
    }

    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand,bool>
    {
        public BaseRepository<Users> repository;

        public UpdateUserHandler(BaseRepository<Users> repository)
        {
            this.repository = repository;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = MapperControl.mapper.Map<Users>(request);
            var response = await repository.Update(user);

            return response;
        } 
    }

}
