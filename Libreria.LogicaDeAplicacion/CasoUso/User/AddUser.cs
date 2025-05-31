using Libreria.CasoUsoCompartida.DTOS.Users;
using Libreria.CasoUsoCompartida.UCInterfaces;
using Libreria.LogicaAplicacion.Mapper;
using Libreria.LogicaNegocio.Exceptions.User;
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

        public int Execute(UserDto userDto)

        {
            if (_repo.ExisteEmail(userDto.Email))
            {
                throw new RepeatedUserException("Ya existe un usuario registrado con ese email.");
            }
            var user = MapperUser.FromDto(userDto);
            return(_repo.Add(user));
        }
    }
}
