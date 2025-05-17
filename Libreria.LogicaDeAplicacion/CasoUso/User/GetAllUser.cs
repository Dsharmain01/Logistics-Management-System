using Libreria.CasoUsoCompartida.DTOS.Users;
using Libreria.CasoUsoCompartida.UCInterfaces;
using Libreria.LogicaAplicacion.Mapper;
using Libreria.LogicaNegocio.InterfacesRepositorio;

namespace Libreria.LogicaAplicacion.CasoUso.Usuarios
{
    public class GetAllUser : IGetAll<DtoListedUser>
    {
        private IUserRepository _repo;

        public GetAllUser(IUserRepository repo)
        {
            this._repo = repo;
        }

        public IEnumerable<DtoListedUser> Execute()
        {
            return MapperUser.ToListaDto(_repo.GetAll());
        }

    }
}
