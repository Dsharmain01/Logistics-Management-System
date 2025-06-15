using Libreria.CasoUsoCompartida.DTOS.Shipment;
using Libreria.CasoUsoCompartida.UCInterfaces;
using Libreria.LogicaAplicacion.Mapper;
using Libreria.LogicaDeNegocio.InterfacesRepositorio;

namespace Libreria.LogicaDeAplicacion.CasoUso.Shipment
{
    public class GetShipmentsByCustomer : IGetShipmentsByCustomer<ShipmentWithTrackingsDto>
    {
        private IShipmentRepository _repo;

        public GetShipmentsByCustomer(IShipmentRepository shipmentRepository)
        {
            _repo = shipmentRepository;
        }

        public IEnumerable<ShipmentWithTrackingsDto> Execute(string customerEmail)
        {
            return MapperShipment.ToListaWithTrackingsDto(_repo.GetByCustomerEmail(customerEmail)
                );
        }
    }
}
