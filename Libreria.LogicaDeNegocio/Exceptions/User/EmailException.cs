namespace Libreria.LogicaNegocio.Exceptions.User
{
    public class EmailException : UserException
    {
        public EmailException()
        {
        }
        public EmailException(string message) : base(message)
        {
        }
    }
}
