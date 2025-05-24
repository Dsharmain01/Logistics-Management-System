using Libreria.CasoUsoCompartida.DTOS.Users;
using Libreria.CasoUsoCompartida.UCInterfaces;
using Libreria.LogicaAplicacion.Mapper;
using Libreria.LogicaNegocio.InterfacesRepositorio;

namespace Libreria.LogicaAplicacion.CasoUso.Usuarios
{
    public class ModifyUsuario : IModify<UserDto>
    {
        private IUserRepository _repo;

        public ModifyUsuario(IUserRepository repo)
        {
            _repo = repo;
        }

        public void Execute(UserDto userDto, int id)
        {
            var user = MapperUser.FromDto(userDto);
            user.Id = id;
            _repo.Modify(user,id);
        }
    }
}

