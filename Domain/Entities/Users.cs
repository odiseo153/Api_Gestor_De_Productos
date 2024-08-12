using Gestor_Productos.Domain.Enums;
using Microsoft.AspNetCore.Identity;


namespace Gestor_Productos.Domain.Entities
{
    public class Users :BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }     

        public Roles Rol { get; set; }
        public IEnumerable<Order> Orders { get; set; } 
    } 
}
