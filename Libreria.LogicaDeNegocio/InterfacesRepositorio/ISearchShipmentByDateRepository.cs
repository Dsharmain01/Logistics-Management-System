

namespace Libreria.LogicaDeNegocio.InterfacesRepositorio
{
    public interface ISearchShipmentByDateRepository<T>
    {
        IEnumerable<T> SearchShipmentByDate(DateTime date1, DateTime date2, string estado, string customerEmail);
    }
}
