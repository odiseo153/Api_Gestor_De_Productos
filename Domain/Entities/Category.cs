

namespace Gestor_Productos.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public IEnumerable<Products> Products { get; set; }
    }
}
