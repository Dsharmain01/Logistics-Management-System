
using Libreria.CasoUsoCompartida.DTOS.Users;
using Libreria.CasoUsoCompartida.UCInterfaces;
using Libreria.LogicaAplicacion.Mapper;
using Libreria.LogicaDeNegocio.InterfacesRepositorio;
using Libreria.LogicaNegocio.InterfacesRepositorio;

namespace Libreria.LogicaAplicacion.CasoUso.Usuarios
{
    public class GetByIdShipment : IGetById<DtoListedShipment>
    {
        private IShipmentRepository _repo;

        public GetByIdShipment(IShipmentRepository repo)
        {
            _repo = repo;
        }

        public DtoListedShipment Execute(int id)
        {
            return MapperShipment.ToListedDto(_repo.GetById(id));
        }
    }
}