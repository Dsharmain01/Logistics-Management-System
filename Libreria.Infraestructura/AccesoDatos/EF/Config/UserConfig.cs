using Libreria.LogicaDeNegocio.Entities;
using Libreria.LogicaNegocio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libreria.Infraestructura.AccesoDatos.EF.Config
{
    class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.OwnsOne(u => u.LastName, LastName =>
              {
                  LastName.Property(n => n.Value).HasColumnName("LastName");
              });

            builder.OwnsOne(u => u.Name, Name =>
            {
                Name.Property(n => n.Value).HasColumnName("Name");
            });

            builder.OwnsOne(u => u.Email, Email =>
            {
                Email.Property(n => n.Value).HasColumnName("Email");
            });

            builder.OwnsOne(u => u.Password, Password =>
            {
                Password.Property(n => n.Value)
            .HasColumnName("Password")
            .HasMaxLength(256)
            .IsRequired();
            });

            builder.HasMany<Shipment>()
             .WithOne()
            .HasForeignKey(s => s.EmployeeId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
