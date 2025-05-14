
using Libreria.LogicaNegocio.Exceptions.User;

namespace Libreria.LogicaNegocio.Vo
{
    public record Password
    {
        public string Value { get;}

        public Password(string value) {
            if (string.IsNullOrEmpty(value))
                throw new PasswordException("Password cannot be null or empty");
            Value = value;
        }


    }
}
