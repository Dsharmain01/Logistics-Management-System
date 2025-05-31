using Libreria.CasoUsoCompartida.DTOS.Tracking;

namespace Libreria.CasoUsoCompartida.UCInterfaces
{
    public interface IGetByTrackNbr
    {
        IEnumerable<DtoListedTracking> Execute(int trackNbr);
    }
}
