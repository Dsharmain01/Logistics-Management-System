
namespace Libreria.LogicaDeNegocio.Exceptions.Shipment
{
    public class RepeatedShipmentException : ShipmentException
    {
        public RepeatedShipmentException()
        {
        }

        public RepeatedShipmentException(string message) : base(message)
        {
        }
    }
}
