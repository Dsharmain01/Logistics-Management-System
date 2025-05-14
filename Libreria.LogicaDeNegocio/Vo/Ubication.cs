

namespace Libreria.LogicaDeNegocio.Vo
{
    public record class Ubication
    {

        public float? Length { get; }
        public float? Latitude { get; }
        public float? PostalAddress { get; }
        
        public Ubication(float? length, float? latitude, float? postalAddress)
        {
            Length = length;
            Latitude = latitude;
            PostalAddress = postalAddress;
        }
    }
}
