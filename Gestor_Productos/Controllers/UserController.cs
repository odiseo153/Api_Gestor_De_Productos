using Gestor_Productos.Application.Authentication.Command;
using Gestor_Productos.Application.Entities.Base.Command;
using Gestor_Productos.Application.Entities.Base.Queries;
using Gestor_Productos.Application.Entities.User.Command;
using Gestor_Productos.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace Gestor_Productos.Presentation.Controllers
{
    [ApiController]
    [Authorize]
    public class UserController : BaseApiController
    {
        public UserController(IMediator mediator) : base(mediator) { }


        [HttpPost("/Auth")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginCommand user)
        {
            return await Mediator.Send(user);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand user)
        {
            return await Mediator.Send(user);
        }
                
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await Mediator.Send(new GetEntityQuery<Users>());
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(string Id)
        {
            return await Mediator.Send(new GetEntityByIdQuery<Users>(Id));
        }

        [HttpDelete("{Id}")]
        public async Task<bool> Delete(string Id)
        {
            return await Mediator.Send(new DeleteEntityCommand<Users>(Id));
        }

        [HttpPut]
        public async Task<bool> Update(UpdateUserCommand user)
        {
            return await Mediator.Send(user);
        }
    }
}









