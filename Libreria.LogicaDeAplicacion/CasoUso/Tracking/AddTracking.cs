using Libreria.CasoUsoCompartida.DTOS.Tracking;
using Libreria.CasoUsoCompartida.UCInterfaces;
using Libreria.LogicaDeAplicacion.Mapper;
using Libreria.LogicaDeNegocio.InterfacesRepositorio;

namespace Libreria.LogicaDeAplicacion.CasoUso.Tracking
{
    public class AddTracking:IAdd<TrackingDto>
    {
        private ITrackingRepository _repo;
        public AddTracking(ITrackingRepository repo)
        {
            _repo = repo;
        }
        public void Execute(TrackingDto trackingDto)
        {
            _repo.Add(MapperTracking.FromDto(trackingDto));
        }
    }
}
