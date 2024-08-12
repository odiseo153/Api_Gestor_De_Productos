


namespace Gestor_Productos.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int Total { get; set; }
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;

        public Products Product { get; set; }
        public Users User { get; set; }
    }
}
