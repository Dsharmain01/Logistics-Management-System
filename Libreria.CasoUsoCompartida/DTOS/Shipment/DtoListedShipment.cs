using Libreria.CasoUsoCompartida.DTOS.Shipment;
using static Libreria.LogicaDeNegocio.Entities.Shipment;

public record DtoListedShipment(
    int Id,
    int TrackingNumber,
    decimal Weight,
    int EmployeeId,
    DateTime startDate,
    DateTime? DeliveryDate,
    Status CurrentStatus,
    string CustomerEmail,
    TipoEnvio TipoEnvio
);
