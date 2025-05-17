using Libreria.CasoUsoCompartida.DTOS.Users;
using Libreria.CasoUsoCompartida.UCInterfaces;
using Libreria.LogicaAplicacion.Mapper;
using Libreria.LogicaNegocio.InterfacesRepositorio;

namespace Libreria.LogicaAplicacion.CasoUso.Usuarios
{
    public class GetById : IGetById<DtoListedUser>
    {
        private IUserRepository _repo;

        public GetById(IUserRepository repo)
        {
            _repo = repo;
        }

        public DtoListedUser Execute(int id)
        {
            return MapperUser.ToDto(_repo.GetById(id));
        }
    }
}
