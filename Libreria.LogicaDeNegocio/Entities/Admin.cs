
using Libreria.LogicaNegocio.Vo;

namespace Libreria.LogicaDeNegocio.Entities
{
    public class Admin : Employee
    {
        public Admin()
        {
        }

        public Admin(
            int id,
            Name name,
            LastName lastName,
            Email email,
            Password password) : base(id, name, lastName, email, password)
        {
        }
    }
}
