using Libreria.LogicaDeNegocio.Exceptions.Shipment;

namespace Libreria.LogicaNegocio.Exceptions.Shipment
{
    public class EmailException : ShipmentException
    {
        public EmailException()
        {
        }
        public EmailException(string message) : base(message)
        {
        }
    }
}
