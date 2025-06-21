using Libreria.CasoUsoCompartida.DTOS.Users;
using Libreria.CasoUsoCompartida.UCInterfaces;
using Libreria.LogicaAplicacion.Mapper;
using Libreria.LogicaNegocio.InterfacesRepositorio;
using Microsoft.AspNetCore.Identity;

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

            if (user == null)
            {
                return null;
            }

            var hasher = new PasswordHasher<object>();
            var result = hasher.VerifyHashedPassword(null, user.Password.Value, loginDto.Password);

            if (result == PasswordVerificationResult.Success)
            {
                return MapperUser.ToDto(user);
            }

            return null;
        }
    }
}
