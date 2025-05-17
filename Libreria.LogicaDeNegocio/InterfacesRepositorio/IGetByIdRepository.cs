namespace Libreria.LogicaDeNegocio.InterfacesRepositorio
{
    public interface IGetByIdRepository<T>
    {
        T GetById(int id);
    }
}
