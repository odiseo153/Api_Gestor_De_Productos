using Gestor_Productos.Domain.Entities;
using Gestor_Productos.Infraestructure.Repository;
using MediatR;

namespace Gestor_Productos.Application.Entities.Base.Command
{
    // Command class for creating an entity
    public class DeleteEntityCommand<T> : IRequest<bool> 
    {
        public string Id { get; set; }

        public DeleteEntityCommand(string id)
        {
            Id = id;
        }
    }

    // Handler for processing the command
    public class DeleteEntityHandler<T> : IRequestHandler<DeleteEntityCommand<T>, bool> where T : BaseEntity
    {
        public BaseRepository<T> repository { get; set; }
        public DeleteEntityHandler(BaseRepository<T> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException();
        }
        
        public async Task<bool> Handle(DeleteEntityCommand<T> request, CancellationToken cancellationToken)
        {
            var response = await repository.Delete(request.Id);

            return response; 
        }
    }

}
