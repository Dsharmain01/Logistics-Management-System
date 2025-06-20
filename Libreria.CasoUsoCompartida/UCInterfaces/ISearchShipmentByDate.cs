using Libreria.CasoUsoCompartida.DTOS.Tracking;

namespace Libreria.CasoUsoCompartida.UCInterfaces
{
    public interface ISearchShipmentByDate<T>
    {
        IEnumerable<DtoListedShipment> Execute(DateTime date1, DateTime date2, string estado, string customerEmail);
    }
}
