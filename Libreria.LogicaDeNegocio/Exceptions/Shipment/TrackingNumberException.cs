
namespace Libreria.LogicaDeNegocio.Exceptions.Shipment
{
    public class TrackingNumberException : ShipmentException
    {
        public TrackingNumberException()
        {
        }

        public TrackingNumberException(string message) : base(message)
        {
        }
    }
}
