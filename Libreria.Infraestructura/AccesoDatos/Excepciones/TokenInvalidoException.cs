
namespace Libreria.Infraestructura.AccesoDatos.Excepciones
{
    [Serializable]
    public class TokenInvalidoException : InfrastructuraException
    {
        public TokenInvalidoException()
        {
        }

        public TokenInvalidoException(string? message) : base(message)
        {
        }

        public override int StatusCode()
        {
            return 401;
        }
    }
}