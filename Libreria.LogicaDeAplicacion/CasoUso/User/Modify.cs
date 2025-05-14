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

            _repo.Modify(MapperUser.FromDto(userDto), userDto.Id); 
        }
    }
}

