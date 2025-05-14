
namespace Libreria.LogicaDeNegocio.Exceptions.Shipment
{
    public class EmployeeNotFoundException : ShipmentException
    {
        public EmployeeNotFoundException()
        {
        }

        public EmployeeNotFoundException(string message) : base(message)
        {
        }
    }
}
