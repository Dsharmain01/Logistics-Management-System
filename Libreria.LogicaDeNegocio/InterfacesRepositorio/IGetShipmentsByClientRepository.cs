
namespace Libreria.LogicaDeNegocio.InterfacesRepositorio
{
    public interface IGetShipmentsByCustomerRepository <T>
    {
        IEnumerable<T> GetByCustomerEmail(string customerEmail);
    }
}
