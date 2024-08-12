using Gestor_Productos.Application.Entities.Base.Command;
using Gestor_Productos.Application.Entities.Base.Queries;
using Gestor_Productos.Application.Entities.Carts.Command;
using Gestor_Productos.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace Gestor_Productos.Presentation.Controllers
{
    [ApiController]
    [Authorize]
    public class CartController : BaseApiController
    {
        public CartController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await Mediator.Send(new GetEntityQuery<Cart>());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCartCommand cart)
        {
            return await Mediator.Send(cart);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(string Id)
        {
            return await Mediator.Send(new GetEntityByIdQuery<Cart>(Id));
        }

        [HttpDelete("{Id}")]
        public async Task<bool> Delete(string Id)
        {
            return await Mediator.Send(new DeleteEntityCommand<Cart>(Id));
        }

        
    }
}





