using Libreria.CasoUsoCompartida.DTOS.Shipment;
using Libreria.CasoUsoCompartida.UCInterfaces;
using Libreria.LogicaAplicacion.Mapper;
using Libreria.LogicaDeNegocio.InterfacesRepositorio;
namespace Libreria.LogicaDeAplicacion.CasoUso.Shipment
{
    public class AddShipment:IAdd<ShipmentDto>
    {
        private IShipmentRepository _repo;
        public AddShipment(IShipmentRepository repo)
       {
            _repo = repo;
        }
        public int Execute(ShipmentDto shipmentDto)
        {
           return(_repo.Add(MapperShipment.FromDto(shipmentDto)));
        }
    }
}
