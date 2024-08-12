using Gestor_Productos.Domain.Entities;
using Gestor_Productos.Infraestructure;
using Gestor_Productos.Infraestructure.Context;
using Gestor_Productos.Infraestructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

namespace Gestor_Productos.Presentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            });

            //services.AddTransient<GlobalHandlerException>();

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                // Configura las opciones de la sesión si es necesario
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Tiempo de inactividad
                options.Cookie.HttpOnly = true; // Solo cookies HTTP
                options.Cookie.IsEssential = true; // Esencial para la sesión
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(op => op.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTServices.key)),
                ValidateIssuerSigningKey = true

            });

            services.AddAuthentication();
            services.AddAuthorization();

            services.AddScoped<EntitySeed>();
            
            services.AddApplicationContext(Configuration);
            services.AddApplicationContextApp(Configuration);
          
            services.AddEndpointsApiExplorer();

           


            services.AddHttpClient("ClientWithToken")
                    .AddHttpMessageHandler<JWTServices>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mi Api de Libreria", Version = "v1" });
                // c.EnableAnnotations();
            });


            services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()); });
        }

       
    }
}