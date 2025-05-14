using Libreria.LogicaNegocio.Exceptions;
using Libreria.LogicaNegocio.Exceptions.User;
namespace Libreria.LogicaNegocio.Vo
{
    public record Email
    {
        public string Value { get; }
        public Email(string value)
        {
            if(string.IsNullOrEmpty(value))
                throw new EmailException("Email cannot be null or empty");
            Value = value;
        }
    }
}
