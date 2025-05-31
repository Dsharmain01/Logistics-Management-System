using Libreria.CasoUsoCompartida.DTOS.Tracking;
using Libreria.CasoUsoCompartida.UCInterfaces;
using Libreria.LogicaDeAplicacion.Mapper;
using Libreria.LogicaDeNegocio.InterfacesRepositorio;

namespace Libreria.LogicaDeAplicacion.CasoUso.Tracking
{
    public class GetByTrackNbr : IGetByTrackNbr
    {
        private ITrackingRepository _repo;

        public GetByTrackNbr(ITrackingRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<DtoListedTracking> Execute(int trackNbr)
        {
            return MapperTracking.ToListaDto(_repo.GetByTrackNbr(trackNbr));
        }
    }
}
