

namespace Gestor_Productos.Domain.Entities
{
    public class CartDetails : BaseEntity
    {
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public int Amount { get; set; }

        public Users User { get; set; }
        public Products Product { get; set; }
    }
}
