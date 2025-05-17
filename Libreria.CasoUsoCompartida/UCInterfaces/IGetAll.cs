namespace Libreria.CasoUsoCompartida.UCInterfaces
{
    public interface IGetAll <T>
    {
        IEnumerable<T> Execute();
    }
}
