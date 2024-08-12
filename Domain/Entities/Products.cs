

namespace Gestor_Productos.Domain.Entities
{
    public class Products : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }

    }
}




