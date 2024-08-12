

namespace Gestor_Productos.Domain.Entities
{
    public class Cart : BaseEntity
    {
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public Users User { get; set; }
        public string UsuarioId { get; set; }
        public List<CartDetails> CartDetails { get; set; }
    }
}
