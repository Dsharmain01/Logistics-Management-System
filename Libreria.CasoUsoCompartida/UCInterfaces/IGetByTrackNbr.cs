namespace Libreria.CasoUsoCompartida.UCInterfaces
{
    public interface IGetByTrackNbr<T>
    {
        IEnumerable<T> Execute(int trackNbr);
    }
}
