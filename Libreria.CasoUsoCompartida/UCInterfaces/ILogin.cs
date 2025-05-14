
using Libreria.CasoUsoCompartida.DTOS.Users;
namespace Libreria.CasoUsoCompartida.UCInterfaces
{
    public interface ILogin
    {
        DtoListedUser Execute(LoginDto loginDto);
    }
}
