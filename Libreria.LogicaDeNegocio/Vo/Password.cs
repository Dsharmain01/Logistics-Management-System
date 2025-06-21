using Libreria.LogicaNegocio.Exceptions.User;

public record Password
{
    public string Value { get; }

    public Password(string value)
    {
        Value = value;
    }

    public static Password FromPlain(string plainPassword)
    {
        var password = new Password(plainPassword);
        password.Validar();
        return password;
    }

    public static Password FromHash(string hash)
    {
        return new Password(hash);
    }

    private void Validar()
    {
        if (string.IsNullOrWhiteSpace(Value))
            throw new PasswordException("La contraseña no puede ser nula o vacía.");

        if (Value.Length < 6)
            throw new PasswordException("La contraseña debe tener al menos 6 caracteres.");

        if (!Value.Any(char.IsLetter))
            throw new PasswordException("La contraseña debe contener al menos una letra.");

        if (!Value.Any(char.IsDigit))
            throw new PasswordException("La contraseña debe contener al menos un número.");

        if (!Value.Any(c => "+.#!-".Contains(c)))
            throw new PasswordException("La contraseña debe contener al menos un carácter especial (+, ., #, !, -).");
    }
}
