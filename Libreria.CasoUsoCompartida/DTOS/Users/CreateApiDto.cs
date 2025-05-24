namespace Libreria.CasoUsoCompartida.DTOS.Users
{
    public record CreateApiDto(
        string Name,
        string LastName,
        string Email,
        string Password,
        string Rol);
}

