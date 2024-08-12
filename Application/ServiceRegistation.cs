using Gestor_Productos.Application.Authentication.Command;
using Gestor_Productos.Application.Entities.Base.Command;
using Gestor_Productos.Application.Entities.Base.Queries;
using Gestor_Productos.Application.Entities.CartDetail.Command;
using Gestor_Productos.Application.Entities.Carts.Command;
using Gestor_Productos.Application.Entities.Orders.Command;
using Gestor_Productos.Application.Entities.Product.Command;
using Gestor_Productos.Application.Entities.User.Command;
using Gestor_Productos.Domain.Entities;
using Gestor_Productos.Infraestructure.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Gestor_Productos.Infraestructure
{
    public static class ServiceRegistation
    {
        public static void AddApplicationContextApp(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IRequestHandler<CreateUserCommand,IActionResult>,CreateUserHandler>();
            services.AddScoped<IRequestHandler<CreateProductCommand, IActionResult>, CreateProductHandler>();
            services.AddScoped<IRequestHandler<CreateOrderCommand, IActionResult>, CreateOrderHandler>();
            services.AddScoped<IRequestHandler<CreateCartCommand, IActionResult>, CreateCartHandler>();
            services.AddScoped<IRequestHandler<CreateCartDetailsCommand, IActionResult>, CreateCartDetailsHandler>();
            services.AddScoped<IRequestHandler<LoginCommand, IActionResult>, LoginHandler>();


            services.AddScoped<IRequestHandler<GetEntityQuery<Users>, IActionResult>, GetEntityHandler<Users>>();
            services.AddScoped<IRequestHandler<GetEntityQuery<Products>, IActionResult>, GetEntityHandler<Products>>();
            services.AddScoped<IRequestHandler<GetEntityQuery<Cart>, IActionResult>, GetEntityHandler<Cart>>();
            services.AddScoped<IRequestHandler<GetEntityQuery<CartDetails>, IActionResult>, GetEntityHandler<CartDetails>>();
            services.AddScoped<IRequestHandler<GetEntityQuery<Order>, IActionResult>, GetEntityHandler<Order>>();
            services.AddScoped<IRequestHandler<GetEntityQuery<Category>, IActionResult>, GetEntityHandler<Category>>();

            services.AddScoped<IRequestHandler<UpdateUserCommand, bool>, UpdateUserHandler>();
            services.AddScoped<IRequestHandler<UpdateOrderCommand, bool>, UpdateOrderHandler>();
            services.AddScoped<IRequestHandler<UpdateProductCommand, bool>, UpdateProductHandler>();

            services.AddScoped<IRequestHandler<GetEntityByIdQuery<Users>, IActionResult>, GetEntityByIdHandler<Users>>();
            services.AddScoped<IRequestHandler<GetEntityByIdQuery<Category>, IActionResult>, GetEntityByIdHandler<Category>>();
            services.AddScoped<IRequestHandler<GetEntityByIdQuery<Products>, IActionResult>, GetEntityByIdHandler<Products>>();
            services.AddScoped<IRequestHandler<GetEntityByIdQuery<Order>, IActionResult>, GetEntityByIdHandler<Order>>();
            services.AddScoped<IRequestHandler<GetEntityByIdQuery<Cart>, IActionResult>, GetEntityByIdHandler<Cart>>();
            services.AddScoped<IRequestHandler<GetEntityByIdQuery<Users>, IActionResult>, GetEntityByIdHandler<Users>>();
            services.AddScoped<IRequestHandler<GetEntityByIdQuery<CartDetails>, IActionResult>, GetEntityByIdHandler<CartDetails>>();



            services.AddScoped<IRequestHandler<DeleteEntityCommand<Users>,bool>, DeleteEntityHandler<Users>>();
            services.AddScoped<IRequestHandler<DeleteEntityCommand<Cart>, bool>, DeleteEntityHandler<Cart>>();
            services.AddScoped<IRequestHandler<DeleteEntityCommand<CartDetails>, bool>, DeleteEntityHandler<CartDetails>>();
            services.AddScoped<IRequestHandler<DeleteEntityCommand<Products>, bool>, DeleteEntityHandler<Products>>();
            services.AddScoped<IRequestHandler<DeleteEntityCommand<Category>, bool>, DeleteEntityHandler<Category>>();
            services.AddScoped<IRequestHandler<DeleteEntityCommand<Order>, bool>, DeleteEntityHandler<Order>>();

            services.AddScoped<HttpClient>();

        }

    }
}
