using Libreria.CasoUsoCompartida.DTOS.Shipment;
using Libreria.CasoUsoCompartida.UCInterfaces;
using Libreria.LogicaAplicacion.Mapper;
using Libreria.LogicaDeNegocio.InterfacesRepositorio;

namespace Libreria.LogicaAplicacion.CasoUso.Usuarios
{
    public class ModifyShipment : IModify<ShipmentDto>
    {
        private IShipmentRepository _repo;

        public ModifyShipment(IShipmentRepository repo)
        {
            _repo = repo;
        }


        public void Execute(ShipmentDto shipmentDto, int trackNbr)
        {

            _repo.Modify(MapperShipment.FromDto(shipmentDto), shipmentDto.TrackingNumber);
        }
    }
}

