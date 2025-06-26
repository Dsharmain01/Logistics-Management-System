
namespace Libreria.Infraestructura.AccesoDatos.Excepciones
{
    [Serializable]
    public class TokenPermisoException : InfrastructuraException
    {
        public TokenPermisoException()
        {
        }

        public TokenPermisoException(string? message) : base(message)
        {
        }

        public override int StatusCode()
        {
            return 403;
        }
    }
}