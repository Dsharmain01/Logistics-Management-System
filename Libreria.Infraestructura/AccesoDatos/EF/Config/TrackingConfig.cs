using Libreria.LogicaDeNegocio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Libreria.Infraestructura.AccesoDatos.EF.Config
{
    class TrackingConfig : IEntityTypeConfiguration<Tracking>
    {
        public void Configure(EntityTypeBuilder<Tracking> builder)
        {
            builder.HasOne<Employee>()
                .WithMany()
                .HasForeignKey(shipment => shipment.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}