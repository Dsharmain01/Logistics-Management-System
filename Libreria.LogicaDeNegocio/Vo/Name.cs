
using Libreria.LogicaNegocio.Exceptions;

namespace Libreria.LogicaNegocio.Vo
{
    public record Name
    {
        public string Value { get; }

        public Name (string value)
        {
            if (string.IsNullOrEmpty(value))
            
                throw new NameException("Name cannot be null or empty");
                Value = value; 
            
        }
    }
}
