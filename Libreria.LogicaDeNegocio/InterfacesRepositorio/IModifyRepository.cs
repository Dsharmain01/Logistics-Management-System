namespace Libreria.LogicaDeNegocio.InterfacesRepositorio
{
    public interface IModifyRepository<T>
    {
        void Modify(T obj, int id);
    }
}
