
using Microsoft.AspNetCore.Identity;

namespace Libreria.LogicaDeNegocio.Utilitarias
{
    public static class PasswordUtils
    {
        public static string HashPassword(string password)
        {
            var hasher = new PasswordHasher<object>();
            return hasher.HashPassword(null, password);
        }
    }
}
