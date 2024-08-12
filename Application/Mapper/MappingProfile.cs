using AutoMapper;
using Gestor_Productos.Application.Entities.CartDetail.Command;
using Gestor_Productos.Application.Entities.Carts.Command;
using Gestor_Productos.Application.Entities.Orders.Command;
using Gestor_Productos.Application.Entities.Product.Command;
using Gestor_Productos.Application.Entities.User.Command;
using Gestor_Productos.Domain.Entities;

namespace Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

          CreateMap<CreateUserCommand,Users>().ReverseMap();
          CreateMap<CreateProductCommand, Products>().ReverseMap();
          CreateMap<UpdateUserCommand, Users>().ReverseMap();
          CreateMap<UpdateProductCommand,Products>().ReverseMap();
          CreateMap<UpdateOrderCommand,Order>().ReverseMap();
            CreateMap<CreateCartDetailsCommand, CartDetails>().ReverseMap();
            CreateMap<CreateCartCommand, Cart>().ReverseMap();
            CreateMap<CreateOrderCommand, Order>().ReverseMap();
        }
    }
}
