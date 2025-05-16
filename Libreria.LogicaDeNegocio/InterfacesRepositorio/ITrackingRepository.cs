using Libreria.LogicaDeNegocio.Entities;

namespace Libreria.LogicaDeNegocio.InterfacesRepositorio
{
    public interface ITrackingRepository :
           IAddRepository<Tracking>,
           IGetByTrackNbrRepository<Tracking>
    {
    }
}
