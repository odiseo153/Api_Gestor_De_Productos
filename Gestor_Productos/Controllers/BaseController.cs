using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gestor_Productos.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;
        public IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public BaseApiController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
