
using Libreria.CasoUsoCompartida.DTOS.Users;
using Libreria.CasoUsoCompartida.UCInterfaces;
using Libreria.LogicaAplicacion.Mapper;
using Libreria.LogicaNegocio.InterfacesRepositorio;

namespace Libreria.LogicaAplicacion.CasoUso.Usuarios
{
    public class AddUser : IAdd<UserDto>
    {
        private IUserRepository _repo;

        public AddUser(IUserRepository repo)
        {
            _repo = repo;
        }

        public void Execute(UserDto userDto)
        {
            _repo.Add(MapperUser.FromDto(userDto));
        }
    }
}
