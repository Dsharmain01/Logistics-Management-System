
namespace Libreria.CasoUsoCompartida.UCInterfaces
{
    public interface IModify<T>
    {
        void Execute(T obj, int id);
    }
}