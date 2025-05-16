

namespace Libreria.LogicaDeNegocio.Vo
{
    public record class Ubication
    {
        public float? Longitude { get; }
        public float? Latitude { get; }
        public string? PostalAddress { get; }

        public Ubication(float? longitude, float? latitude, string? postalAddress)
        {
            Longitude = longitude;
            Latitude = latitude;
            PostalAddress = postalAddress;
        }
    }
}