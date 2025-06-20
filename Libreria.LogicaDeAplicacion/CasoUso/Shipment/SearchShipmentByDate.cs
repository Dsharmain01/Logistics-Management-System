using Libreria.CasoUsoCompartida.DTOS.Tracking;
using Libreria.CasoUsoCompartida.UCInterfaces;
using Libreria.LogicaAplicacion.Mapper;
using Libreria.LogicaDeAplicacion.Mapper;
using Libreria.LogicaDeNegocio.InterfacesRepositorio;

namespace Libreria.LogicaDeAplicacion.CasoUso.Shipment
{
    public class SearchShipmentByDate : ISearchShipmentByDate<DtoListedShipment>
    {
        private IShipmentRepository _repo;

        public SearchShipmentByDate(IShipmentRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<DtoListedShipment> Execute(DateTime date1, DateTime date2, string estado, string customerEmail)
        {
            return MapperShipment.ToListaDto(_repo.SearchShipmentByDate(date1, date2, estado, customerEmail));
        }
    }
}
