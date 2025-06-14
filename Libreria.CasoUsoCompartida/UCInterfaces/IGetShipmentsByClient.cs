
using Libreria.CasoUsoCompartida.DTOS.Shipment;

namespace Libreria.CasoUsoCompartida.UCInterfaces
{
    public interface IGetShipmentsByCustomer<T>
    {
        IEnumerable<DtoListedShipment> Execute(string customerEmail);
    }
}
