
using Libreria.LogicaNegocio.Entities;
using Libreria.LogicaNegocio.Vo;

namespace Libreria.LogicaDeNegocio.Entities
{
    public abstract class Employee : User
    {
        public Employee()
        {
        }

        public Employee(
            int id,
            Name name,
            LastName lastName,
            Email email,
            Password password) : base(id, name, lastName, email, password)
        {
        }
    }
   
}
