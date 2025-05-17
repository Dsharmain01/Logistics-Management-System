using Libreria.LogicaDeNegocio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libreria.Infraestructura.AccesoDatos.EF.Config
{
    class AgencyConfig : IEntityTypeConfiguration<Agency>
    {
        public void Configure(EntityTypeBuilder<Agency> builder)
        {
            builder.OwnsOne(a => a.Name, Name =>
            {
                Name.Property(n => n.Value).HasColumnName("Name");
            });

            builder.OwnsOne(a => a.Ubication, Ubication =>
            {
                Ubication.Property(n => n.Longitude).HasColumnName("Longitude");
                Ubication.Property(n => n.Latitude).HasColumnName("Latitude");
                Ubication.Property(n => n.PostalAddress).HasColumnName("PostalAddress");
            });

            builder.HasOne<Employee>()
             .WithMany()
             .HasForeignKey(agency => agency.EmployeeId)
             .OnDelete(DeleteBehavior.SetNull);

        }
    }
}