

namespace Libreria.LogicaNegocio.Exceptions.User
{
    public class RepeatedUserException : UserException
    {
        public RepeatedUserException()
        {
        }

        public RepeatedUserException(string? message) : base(message)
        {
        }
    }
}
