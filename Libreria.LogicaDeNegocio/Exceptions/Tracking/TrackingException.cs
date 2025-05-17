using Libreria.LogicaNegocio.Exceptions;

namespace Libreria.LogicaDeNegocio.Exceptions.Tracking
{
    public class TrackingException : LogicaNegocioException
    {
        public TrackingException()
        {
        }

        public TrackingException(string message) : base(message)
        {
        }
    }
}
