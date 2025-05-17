using Libreria.LogicaNegocio.Entities;
using Libreria.LogicaNegocio.Vo;

namespace Libreria.LogicaDeNegocio.Entities
{
    public class Client : User
    {
        public Client()
        {
        }

        public Client(
            int id,
            Name name,
            LastName lastName,
            Email email,
            Password password) : base(id, name, lastName, email, password)
        {
        }
    }   
}
