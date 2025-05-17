namespace Libreria.LogicaDeNegocio.InterfacesRepositorio
{
    public interface IGetAllRepository<T>
    {
        IEnumerable<T> GetAll();
    }
}
