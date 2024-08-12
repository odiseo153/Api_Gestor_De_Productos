using Gestor_Productos.Application.Entities.Base.Command;
using Gestor_Productos.Application.Entities.Base.Queries;
using Gestor_Productos.Application.Entities.CartDetail.Command;
using Gestor_Productos.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gestor_Productos.Presentation.Controllers
{ 
    public class CartDetailsController : BaseApiController
    {
        public CartDetailsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await Mediator.Send(new GetEntityQuery<CartDetails>());
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(string Id)
        {
            return await Mediator.Send(new GetEntityByIdQuery<CartDetails>(Id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCartDetailsCommand cartDetails)
        {
            return await Mediator.Send(cartDetails);
        }

        [HttpDelete("{Id}")]
        public async Task<bool> Create(string Id)
        {
            return await Mediator.Send(new DeleteEntityCommand<CartDetails>(Id));
        }
    }
}
