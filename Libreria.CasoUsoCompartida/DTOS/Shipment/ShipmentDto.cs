using static Libreria.LogicaDeNegocio.Entities.Shipment;

namespace Libreria.CasoUsoCompartida.DTOS.Shipment
{
    public enum TipoEnvio
    {
        COMMON,
        URGENT
    }

    public record ShipmentDto(
        int TrackingNumber,
        decimal Weight,
        int? EmployeeId,
        DateTime startDate,
        DateTime? DeliveryDate,
        Status CurrentStatus,
        string CustomerEmail,
        TipoEnvio TipoEnvio,
        string? PickupAgency,
        string? PostalAddress
    );
}

