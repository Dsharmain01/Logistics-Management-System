
namespace Libreria.LogicaDeNegocio.Exceptions.Shipment
{
    public class DeliveryDateException : ShipmentException
    {
        public DeliveryDateException()
        {
        }

        public DeliveryDateException(string message) : base(message)
        {
        }
    }
}
