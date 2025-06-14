using Libreria.CasoUsoCompartida.UCInterfaces;
using Libreria.LogicaAplicacion.Mapper;
using Libreria.LogicaDeNegocio.InterfacesRepositorio;

namespace Libreria.LogicaDeAplicacion.CasoUso.Shipment
{
    public class GetShipmentsByCustomer : IGetShipmentsByCustomer<DtoListedShipment>
    {
        private IShipmentRepository _repo;

        public GetShipmentsByCustomer(IShipmentRepository shipmentRepository)
        {
            _repo = shipmentRepository;
        }

        public IEnumerable<DtoListedShipment> Execute(string customerEmail)
        {
            return MapperShipment.ToListaDto(_repo.GetByCustomerEmail(customerEmail)
                );
        }
    }
}
