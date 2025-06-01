using System.Text.Json.Serialization;

namespace Libreria.CasoUsoCompartida.DTOS.Users
{
    public record UserPasswordDto(
            string currentPassword,
            string newPassword
        );

}