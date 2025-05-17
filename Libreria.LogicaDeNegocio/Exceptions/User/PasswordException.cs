namespace Libreria.LogicaNegocio.Exceptions.User
{
    
    public class PasswordException : UserException
    {
        public PasswordException()
        {
        }
        public PasswordException(string message) : base(message)
        {
        }
    }      
}
