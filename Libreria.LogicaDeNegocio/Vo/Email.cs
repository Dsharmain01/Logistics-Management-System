using Libreria.LogicaNegocio.Exceptions.User;
namespace Libreria.LogicaNegocio.Vo
{
    public record Email
    {
        public string Value { get; }      
        public Email(string value)
        {
            Value = value;
            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrEmpty(Value))
                throw new EmailException("El correo electrónico no puede ser nulo o vacío.");
            if (!Value.Contains("@"))
                throw new EmailException("El correo electrónico debe contener '@'.");
            if (!Value.Contains("."))
                throw new EmailException("El correo electrónico debe contener '.'.");
            if (Value.Length < 5)
                throw new EmailException("El correo electrónico debe tener al menos 5 caracteres.");
            if (Value.Length > 50)
                throw new EmailException("El correo electrónico debe tener como máximo 50 caracteres.");
        }

    }
}
