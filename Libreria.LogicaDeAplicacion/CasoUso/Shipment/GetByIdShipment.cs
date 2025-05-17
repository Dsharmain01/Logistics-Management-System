using Libreria.CasoUsoCompartida.UCInterfaces;
using Libreria.LogicaAplicacion.Mapper;
using Libreria.LogicaDeNegocio.InterfacesRepositorio;

namespace Libreria.LogicaAplicacion.CasoUso.Usuarios
{
    public class GetByIdShipment : IGetById<DtoListedShipment>
    {
        private IShipmentRepository _repo;

        public GetByIdShipment(IShipmentRepository repo)
        {
            _repo = repo;
        }

        public DtoListedShipment Execute(int trackNbr)
        {
            return MapperShipment.ToListedDto(_repo.GetById(trackNbr));
        }
    }
}