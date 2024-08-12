using Gestor_Productos.Domain.Entities;
using Gestor_Productos.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


namespace Gestor_Productos.Presentation
{
    public class EntitySeed
    {
        private readonly ApplicationContext _context;

        public EntitySeed(ApplicationContext context)
        {
            _context = context;
        }

        public async Task SeedEntities<TEntity>(string filePath) where TEntity : BaseEntity
        {
            // Leer el archivo JSON
            string path = Path.Combine("Seed", "Data", filePath);
            var json = await File.ReadAllTextAsync(path);

            // Deserializar el JSON en una lista de entidades
            var entities = JsonConvert.DeserializeObject<List<TEntity>>(json);

            if (entities == null || !entities.Any())
            {
                return;
            }

            // Insertar o actualizar las entidades en la base de datos
            foreach (var entity in entities)
            {
                var entityId = GetEntityId(entity);
                var existingEntity = await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id.Equals(entityId));

                if (existingEntity == null)
                {
                    _context.Set<TEntity>().Add(entity);
                }
            }

            await _context.SaveChangesAsync();
        }


        private string GetEntityId(BaseEntity entity)
        {
            var property = entity.GetType().GetProperty("Id");
            if (property != null && property.GetValue(entity) is string id)
            {
                return id;
            }
            throw new InvalidOperationException("Entity does not have an Id property");
        }
    }
}
