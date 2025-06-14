using Libreria.LogicaDeNegocio.Entities;

namespace Libreria.LogicaDeNegocio.InterfacesRepositorio
{
    public interface IShipmentRepository:
        IAddRepository<Shipment>,
        IGetByIdRepository<Shipment>,
        IGetAllRepository<Shipment>,
        IModifyRepository<Shipment>,
        IGetShipmentsByCustomerRepository<Shipment>
    {
    }
}
