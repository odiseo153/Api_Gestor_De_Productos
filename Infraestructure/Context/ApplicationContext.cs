using Gestor_Productos.Domain.Entities;
using Gestor_Productos.Infraestructure.Configuration;
using Microsoft.EntityFrameworkCore;


namespace Gestor_Productos.Infraestructure.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        
        }

        public ApplicationContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

          modelBuilder.ApplyConfiguration(new CartConfiguration());
          modelBuilder.ApplyConfiguration(new OrderConfiguration());
          modelBuilder.ApplyConfiguration(new ProductConfiguration());
          modelBuilder.ApplyConfiguration(new UsersConfiguration());

        }

        public DbSet<Products> Products { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
