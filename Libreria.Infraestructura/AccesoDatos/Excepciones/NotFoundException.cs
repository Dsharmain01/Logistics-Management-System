
namespace Libreria.Infraestructura.AccesoDatos.Excepciones
{
    [Serializable]
    public class NotFoundException : InfrastructuraException
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string? message) : base(message)
        {
        }

        public override int StatusCode()
        {
            return 404;
        }
    }
}