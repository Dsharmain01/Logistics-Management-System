using Libreria.LogicaNegocio.Exceptions;
namespace Libreria.LogicaDeNegocio.Exceptions.Shipment
{
    public class ShipmentException : LogicaNegocioException
    {
        public ShipmentException()
        {
        }

        public ShipmentException(string message) : base(message)
        {
        }
    }  
}
