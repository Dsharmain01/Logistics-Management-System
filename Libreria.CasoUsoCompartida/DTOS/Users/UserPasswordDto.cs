
namespace Libreria.CasoUsoCompartida.DTOS.Users
{
    public record UserPasswordDto(
            string currentPassword,
            string newPassword
        );

}