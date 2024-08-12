using Gestor_Productos.Domain.Entities;
using Gestor_Productos.Infraestructure.Context;
using Gestor_Productos.Infraestructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



namespace Gestor_Productos.Infraestructure
{
    public static class ServiceRegistation
    {
        public static void AddApplicationContext(this IServiceCollection services, IConfiguration configuration)
        {
         
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer("Server=odiseo\\ODISEO;Database=Gestor_Productos;User Id=odiseo;Password=Padomo153;TrustServerCertificate=True;");
            });

            services.AddScoped<JWTServices>();
            services.AddScoped<BaseRepository<Users>>();
            services.AddScoped<BaseRepository<Cart>>();
            services.AddScoped<BaseRepository<CartDetails>>();
            services.AddScoped<BaseRepository<Products>>();
            services.AddScoped<BaseRepository<Category>>();
            services.AddScoped<BaseRepository<Order>>();

            services.AddHttpContextAccessor();


        }

    }
}




