using Libreria.CasoUsoCompartida.DTOS.Users;
using Libreria.CasoUsoCompartida.UCInterfaces;
using Libreria.LogicaAplicacion.Mapper;
using Libreria.LogicaNegocio.InterfacesRepositorio;

namespace Libreria.LogicaDeAplicacion.CasoUso.User
{
    public class LoginUser : ILogin
    {
        private IUserRepository _repo;

        public LoginUser(IUserRepository repo)
        {
            _repo = repo;
        }

        public DtoListedUser Execute(LoginDto loginDto)
        {
            var user = _repo.GetByEmail(loginDto.Email);

            if (user == null || user.Password.Value != loginDto.Password)
            {
                return null;
            }

            return MapperUser.ToDto(user);
        }
    }
}
