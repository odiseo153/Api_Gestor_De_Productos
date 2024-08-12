
using Application;
using Gestor_Productos.Application.Entities.Orders.Validation;
using Gestor_Productos.Domain.Entities;
using Gestor_Productos.Infraestructure.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gestor_Productos.Application.Entities.Orders.Command
{
    public class CreateOrderCommand : IRequest<IActionResult>
    {
        public int Total { get; set; }
        public string UserId { get; set; }
        public string ProductId { get; set; }
    }
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand,IActionResult>
    {

        public BaseRepository<Order> repository;

        public CreateOrderHandler(BaseRepository<Order> repository)
        {
            this.repository = repository;
        }

        public async Task<IActionResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = MapperControl.mapper.Map<Order>(request);
            var validation = await new CreateOrderValidation().ValidateAsync(request);

            if (!validation.IsValid)
            {
                return new JsonResult(validation.Errors);
            }

            return new JsonResult(await repository.Create(order));

        }
    }
}
