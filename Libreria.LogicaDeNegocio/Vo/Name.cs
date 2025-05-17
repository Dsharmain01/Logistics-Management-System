
using Libreria.LogicaNegocio.Exceptions;
using Libreria.LogicaNegocio.Exceptions.User;

namespace Libreria.LogicaNegocio.Vo
{
    public record Name
    {
        public string Value { get; }

        public Name(string value)
        {
            Value = value;
            Validar();
        }
        private void Validar()
        {
            if (string.IsNullOrEmpty(Value))
            {
                throw new NameException("Last name cannot be null or empty");
            }
            if (Value.Length < 2)
            {
                throw new NameException("Last name must be at least 2 characters long");
            }
            if (Value.Length > 50)
            {
                throw new NameException("Last name cannot exceed 50 characters");
            }
            if (Value.Any(char.IsDigit))
            {
                throw new NameException("Last name cannot contain numbers");
            }
        }
    }
}
