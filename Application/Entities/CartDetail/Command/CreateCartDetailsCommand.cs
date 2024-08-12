using Application;
using Gestor_Productos.Domain.Entities;
using Gestor_Productos.Infraestructure.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Gestor_Productos.Application.Entities.CartDetail.Command
{
    public class CreateCartDetailsCommand : IRequest<IActionResult>
    {
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public int Amount { get; set; }
    }
    public class CreateCartDetailsHandler : IRequestHandler<CreateCartDetailsCommand, IActionResult>
    {
        public BaseRepository<CartDetails> repository;

        public CreateCartDetailsHandler(BaseRepository<CartDetails> repository)
        {
            this.repository = repository;
        }

        public async Task<IActionResult> Handle(CreateCartDetailsCommand request, CancellationToken cancellationToken)
        {
            var cartDetail = MapperControl.mapper.Map<CartDetails>(request);
            var response = await repository.Create(cartDetail);

            return new JsonResult(response);
        }
    }
}





