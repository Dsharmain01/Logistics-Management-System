namespace Libreria.CasoUsoCompartida.DTOS.Users
{
    public record UserDto(
        int Id,
        string Name,
        string LastName,
        string Email,
        string Password);
}
