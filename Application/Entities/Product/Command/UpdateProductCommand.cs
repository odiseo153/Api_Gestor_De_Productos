
using Application;
using Gestor_Productos.Domain.Entities;
using Gestor_Productos.Infraestructure.Repository;
using MediatR;

namespace Gestor_Productos.Application.Entities.Product.Command
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; }
        public string? CategoryId { get; set; }
    }

    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        public BaseRepository<Products> repository;

        public UpdateProductHandler(BaseRepository<Products> repository)
        {
            this.repository = repository;
        }
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = MapperControl.mapper.Map<Products>(request);

            var response = await repository.Update(product);

            return response;
        }
    }
}
