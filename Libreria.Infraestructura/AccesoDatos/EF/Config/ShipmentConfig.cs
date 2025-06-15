using Libreria.LogicaDeNegocio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libreria.Infraestructura.AccesoDatos.EF.Config
{
    class ShipmentConfig : IEntityTypeConfiguration<Shipment>
    {
        public void Configure(EntityTypeBuilder<Shipment> builder)
        {
            builder.HasKey(s => s.TrackNbr);

            builder.HasOne<Employee>()
                .WithMany()
                .HasForeignKey(shipment => shipment.EmployeeId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(s => s.Trackings)
                .WithOne() 
                .HasForeignKey(t => t.TrackNbr) 
                .HasPrincipalKey(s => s.TrackNbr)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
