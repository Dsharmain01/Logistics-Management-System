using Libreria.CasoUsoCompartida.DTOS.Shipment;
using Libreria.CasoUsoCompartida.UCInterfaces;
using Libreria.LogicaAplicacion.Mapper;
using Libreria.LogicaDeNegocio.InterfacesRepositorio;

namespace Libreria.LogicaAplicacion.CasoUso.Usuarios
{
    public class GetByIdShipment : IGetById<ShipmentWithTrackingsDto>
    {
        private IShipmentRepository _repo;

        public GetByIdShipment(IShipmentRepository repo)
        {
            _repo = repo;
        }

        public ShipmentWithTrackingsDto Execute(int trackNbr)
        {
            return MapperShipment.ToWithTrackingsDto(_repo.GetById(trackNbr));
        }
    }
}