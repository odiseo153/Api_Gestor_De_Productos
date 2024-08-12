using Gestor_Productos.Domain.Entities;
using Gestor_Productos.Infraestructure.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_Productos.Application.Entities.Base.Queries
{
    public class GetEntityByIdQuery<T> : IRequest<IActionResult>
    {
        public string Id { get; set; }

        public GetEntityByIdQuery(string Id)
        {
            this.Id = Id;
        }

    }

    public class GetEntityByIdHandler<T> : IRequestHandler<GetEntityByIdQuery<T>, IActionResult> where T : BaseEntity
    {
        public BaseRepository<T> repository { get; set; }
        public GetEntityByIdHandler(BaseRepository<T> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException();
        }
        public async Task<IActionResult> Handle(GetEntityByIdQuery<T> request, CancellationToken cancellationToken)
        {
            var entities = await repository.GetById(request.Id);

            return new JsonResult(entities);
        }
    }
}
