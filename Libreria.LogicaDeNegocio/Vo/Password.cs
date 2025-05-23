using Libreria.LogicaNegocio.Exceptions.User;

namespace Libreria.LogicaNegocio.Vo
{
    public record Password
    {
        public string Value { get;}

        public Password(string value)
        {
            Value = value;
            Validar();
        }
        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Value))
            {
                throw new PasswordException("La contraseña no puede ser nula o vacía.");
            }

            if (Value.Length < 6)
            {
                throw new PasswordException("La contraseña debe tener al menos 6 caracteres.");
            }

            if (!Value.Any(char.IsLetter))
            {
                throw new PasswordException("La contraseña debe contener al menos una letra.");
            }

            if (!Value.Any(char.IsDigit))
            {
                throw new PasswordException("La contraseña debe contener al menos un número.");
            }

            if (!Value.Any(c => "+.#!-".Contains(c)))
            {
                throw new PasswordException("La contraseña debe contener al menos un carácter especial (+, ., #, !, -).");
            }
        }
    }
}
