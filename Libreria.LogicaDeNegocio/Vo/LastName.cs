using Libreria.LogicaNegocio.Exceptions;
using Libreria.LogicaNegocio.Exceptions.User;


namespace Libreria.LogicaNegocio.Vo
{
    public record LastName
    {
        public string Value { get;}

        public LastName (string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new LastNameException("LastName cannot be null or empty");
            
            Value = value;
        }
    }
}
