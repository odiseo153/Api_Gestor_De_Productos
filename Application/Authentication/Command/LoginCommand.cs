using Gestor_Productos.Infraestructure.Context;
using Gestor_Productos.Infraestructure.Repository;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestor_Productos.Application.Authentication.Command
{
    public class LoginCommand : IRequest<IActionResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginHandler : IRequestHandler<LoginCommand, IActionResult>
    {
        public ApplicationContext context { get; set; }
        public JWTServices jwtServices { get; set; }
        public IHttpContextAccessor http { get; set; }


        public LoginHandler(IHttpContextAccessor http,ApplicationContext context,JWTServices jwtServices) 
        {
         this.jwtServices = jwtServices;
         this.context = context;
         this.http = http;

        }


        public async Task<IActionResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = context.Users.FirstOrDefault(x => x.Email.Equals(request.Email) && x.Password.Equals(request.Password));

            if (user == null)
            {
                return new JsonResult(new {
                Error="No existe usuario con esas crededenciales",
                Status=StatusCodes.Status400BadRequest
                });
            }

            var jwtSecutiryToken = await jwtServices.GetSecurityToken(user);


            return new JsonResult(new
            {
                message="Bienvenid@ a la api de productos",
                Status=StatusCodes.Status200OK,
                Token= jwtSecutiryToken

            });

        }
    }
}
