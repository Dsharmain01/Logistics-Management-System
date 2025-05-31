

namespace Libreria.Infraestructura.AccesoDatos.Excepciones
{
    public class NoContentException : InfrastructuraException
    {
        public NoContentException()
        {
        }

        public NoContentException(string? message) : base(message)
        {
        }

        public override int StatusCode()
        {
            return 204;
        }
    }
}
