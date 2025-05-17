using Libreria.CasoUsoCompartida.UCInterfaces;
using Libreria.LogicaAplicacion.Mapper;
using Libreria.LogicaDeNegocio.InterfacesRepositorio;

namespace Libreria.LogicaAplicacion.CasoUso.Shipments
{
    public class GetAllShipment : IGetAll<DtoListedShipment>
    {
        private readonly IShipmentRepository _repo;

        public GetAllShipment(IShipmentRepository repo)
        {
            _repo = repo;
        }
        
        public IEnumerable<DtoListedShipment> Execute()
        {
            return MapperShipment.ToListaDto(_repo.GetAll());
        }
    }
}
