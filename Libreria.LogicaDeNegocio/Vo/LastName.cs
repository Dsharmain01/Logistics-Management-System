using Libreria.LogicaNegocio.Exceptions;
using Libreria.LogicaNegocio.Exceptions.User;

namespace Libreria.LogicaNegocio.Vo
{
    public record LastName
    {
        public string Value { get;}

        public LastName (string value)
        {
            Value = value;
            Validar();                     
        }
        private void Validar()
        {
            if (string.IsNullOrEmpty(Value))
            {
                throw new LastNameException("Last name cannot be null or empty");
            }
            if (Value.Length < 2)
            {
                throw new LastNameException("Last name must be at least 2 characters long");
            }
            if (Value.Length > 50)
            {
                throw new LastNameException("Last name cannot exceed 50 characters");
            }
            if (Value.Any(char.IsDigit))
            {
                throw new LastNameException("Last name cannot contain numbers");
            }
        }
    }
}
