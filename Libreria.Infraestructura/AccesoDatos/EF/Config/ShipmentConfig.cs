using Libreria.LogicaDeNegocio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libreria.Infraestructura.AccesoDatos.EF.Config
{
    class ShipmentConfig : IEntityTypeConfiguration<Shipment>
    {
        public void Configure(EntityTypeBuilder<Shipment> builder)
        {

            builder.HasOne(shipment => shipment.Employee)
                .WithMany()
                .HasForeignKey(shipment => shipment.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}