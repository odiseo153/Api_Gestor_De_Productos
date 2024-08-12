using Gestor_Productos.Domain.Entities;
using Gestor_Productos.Infraestructure.Context;

namespace Gestor_Productos.Presentation;

public class Program
{
    public static async Task Main(string[] args)
    {
        // Crear el constructor de la aplicación web con los argumentos proporcionados
        var builder = WebApplication.CreateBuilder(args);
        var startup = new Startup(builder.Configuration);

        // Agregar servicios al contenedor de servicios
        startup.ConfigureServices(builder.Services);

        // Construir la aplicación web
        var app = builder.Build();

        // Configurar el pipeline de solicitudes HTTP
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        // Usar el contexto de la aplicación
        using (var db = new ApplicationContext())
        {
            // Asegurarse de que la base de datos sea eliminada y creada nuevamente
            //await db.Database.EnsureDeletedAsync();
            //await db.Database.EnsureCreatedAsync();

            // Crear un scope para obtener servicios del contenedor de dependencias
            var scope = app.Services.CreateScope();
            var seed = scope.ServiceProvider.GetRequiredService<EntitySeed>();

            // Lista de tareas de semilla para insertar datos en la base de datos
            var seedTasks = new List<Func<Task>>()
            {
                async () => await seed.SeedEntities<Category>("category.json"),
                async () => await seed.SeedEntities<Products>("products.json"),
         //       async () => await seed.SeedEntities<Users>("users.json"),
                async () => await seed.SeedEntities<Order>("orders.json"),
                async () => await seed.SeedEntities<CartDetails>("cartdetails.json")
            };

            // Inserción de datos en la base de datos (comentado)
            /*
            foreach (var seedTask in seedTasks)
            {
                try
                {
                    await seedTask();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al sembrar datos: {ex.Message}");
                }
            }
            */
        }

        // Usar redirección HTTPS
        app.UseHttpsRedirection();

        app.UseAuthentication();
        // Usar autorización
        app.UseAuthorization();

        // Mapear controladores
        app.MapControllers();

        app.UseSession();

        // Ejecutar la aplicación de forma asíncrona
        await app.RunAsync();  // RunAsync() is used here for async operation
    }
}
