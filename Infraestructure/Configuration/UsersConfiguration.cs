using Gestor_Productos.Domain.Entities;
using Gestor_Productos.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Gestor_Productos.Infraestructure.Configuration
{
    public class UsersConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {

            builder.Property(x => x.Name);
            builder.Property(x => x.Password);
            builder.Property(x => x.Email);
            builder.Property(x => x.Rol);
            builder.HasMany(x => x.Orders).WithOne(x => x.User);
            builder.Property(u => u.Rol)
            .HasConversion(
                v => v.ToString(),
                v => (Roles)Enum.Parse(typeof(Roles), v)
            );

        }
    }
}





