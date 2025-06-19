using Libreria.CasoUsoCompartida.DTOS.Users;

namespace WebApi.Services
{
    public interface IJwtGenerator
    {
        public string GenerateToken(DtoListedUser usuario);
    }
}
