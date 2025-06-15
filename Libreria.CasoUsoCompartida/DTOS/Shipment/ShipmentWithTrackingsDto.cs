
using Libreria.CasoUsoCompartida.DTOS.Tracking;
using static Libreria.LogicaDeNegocio.Entities.Shipment;

namespace Libreria.CasoUsoCompartida.DTOS.Shipment
{
    public enum TipoEnvio1
    {
        COMMON,
        URGENT
    }

    public record ShipmentWithTrackingsDto(
        int TrackingNumber,
        decimal Weight,
        int? EmployeeId,
        DateTime startDate,
        DateTime? DeliveryDate,
        Status CurrentStatus,
        string CustomerEmail,
        TipoEnvio TipoEnvio,
        int? PickupAgency,
        string? PostalAddress,
       List<TrackingDto> Trackings
    );
}
