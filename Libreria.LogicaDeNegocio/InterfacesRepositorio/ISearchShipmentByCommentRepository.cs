
namespace Libreria.LogicaDeNegocio.InterfacesRepositorio
{
    public interface ISearchShipmentByCommentRepository<T>
    {
        IEnumerable<T> SearchShipmentByComment(string comment, string customerEmail);
    }
}
