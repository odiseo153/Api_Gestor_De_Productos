using Gestor_Productos.Application.Entities.Base.Command;
using Gestor_Productos.Application.Entities.Base.Queries;
using Gestor_Productos.Application.Entities.Product.Command;
using Gestor_Productos.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gestor_Productos.Presentation.Controllers
{
    [ApiController]
    [Authorize]
    public class ProductController : BaseApiController
    {
        public ProductController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            return await Mediator.Send(new GetEntityQuery<Products>());
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(string Id)
        {
            return await Mediator.Send(new GetEntityByIdQuery<Products>(Id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand product)
        {
            return await Mediator.Send(product);
        }

        [HttpPut]
        public async Task<bool> Update(UpdateProductCommand product)
        {
            return await Mediator.Send(product);
        }

        [HttpDelete("{Id}")]
        public async Task<bool> Delete(string Id)
        {
            return await Mediator.Send(new DeleteEntityCommand<Products>(Id));
        }
    }
}







