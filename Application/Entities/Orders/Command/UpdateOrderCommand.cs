using Application;
using Gestor_Productos.Domain.Entities;
using Gestor_Productos.Infraestructure.Repository;
using MediatR;


namespace Gestor_Productos.Application.Entities.Orders.Command
{
    public class UpdateOrderCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public int Total { get; set; }
    }
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, bool>
    {
        public BaseRepository<Order> repository;

        public UpdateOrderHandler(BaseRepository<Order> repository)
        {
            this.repository = repository;
        }
        public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = MapperControl.mapper.Map<Order>(request);

            return await repository.Update(order);
        }
    }
}
