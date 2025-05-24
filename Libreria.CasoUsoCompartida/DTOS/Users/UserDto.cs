using System.Text.Json.Serialization;

namespace Libreria.CasoUsoCompartida.DTOS.Users
{
    public record UserDto(
            string Name,
            string LastName,
            string Email,
            string Password,
            string Rol
        )
    {
        [JsonIgnore]
        public int Id { get; set; } = 0; 
    }
}
