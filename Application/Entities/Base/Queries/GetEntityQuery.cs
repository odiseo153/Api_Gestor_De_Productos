using Gestor_Productos.Domain.Entities;
using Gestor_Productos.Infraestructure.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Gestor_Productos.Application.Entities.Base.Queries
{
    public class GetEntityQuery<T> : IRequest<IActionResult> 
    {

    }

    public class GetEntityHandler<T> : IRequestHandler<GetEntityQuery<T>, IActionResult> where T : BaseEntity
    {
        public BaseRepository<T> repository { get; set; }
        public GetEntityHandler(BaseRepository<T> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException();
        }
        public async Task<IActionResult> Handle(GetEntityQuery<T> request, CancellationToken cancellationToken)
        {
            var entities = await repository.GetAll();

            return new JsonResult(entities);
        }
    }
}




