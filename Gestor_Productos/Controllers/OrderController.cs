using Gestor_Productos.Application.Entities.Base.Command;
using Gestor_Productos.Application.Entities.Base.Queries;
using Gestor_Productos.Application.Entities.Orders.Command;
using Gestor_Productos.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace Gestor_Productos.Presentation.Controllers
{
    [ApiController]
    [Authorize]
    public class OrderController : BaseApiController
    {

        public OrderController(IMediator mediator) : base(mediator) {}


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await Mediator.Send(new GetEntityQuery<Order>());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderCommand order)
        {
            return await Mediator.Send(order);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(string Id)
        {
            return await Mediator.Send(new GetEntityByIdQuery<Order>(Id));
        }

        [HttpPut]
        public async Task<bool> Update(UpdateOrderCommand order)
        {
            return await Mediator.Send(order);
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(string id)
        {
            return await Mediator.Send(new DeleteEntityCommand<Order>(id));
        }


    }
}








