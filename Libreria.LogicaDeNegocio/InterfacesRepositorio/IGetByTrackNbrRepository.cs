
namespace Libreria.LogicaDeNegocio.InterfacesRepositorio
{
    public interface IGetByTrackNbrRepository<T>
    {
        IEnumerable<T> GetByTrackNbr(int trackNbr);
    }
}
