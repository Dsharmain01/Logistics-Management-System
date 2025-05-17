namespace Libreria.LogicaNegocio.Exceptions
{
    public class NameException : LogicaNegocioException
    {
        public NameException()
        {
        }

        public NameException(string? message) : base(message)
        {
        }
    }
}
