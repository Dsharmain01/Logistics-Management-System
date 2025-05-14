
namespace Libreria.CasoUsoCompartida.DTOS.Users
{
    public record DtoListedUser (
        int Id,
        string Name,
        string LastName,
        string Email,
        string Password,
        string Rol)
    {
      
    }
}
