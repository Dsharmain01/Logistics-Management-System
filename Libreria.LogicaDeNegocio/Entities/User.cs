
using Libreria.LogicaNegocio.InterfacesDominio;
using Libreria.LogicaNegocio.Vo;


namespace Libreria.LogicaNegocio.Entities
{
    public abstract class User : IEntity, IEquatable<User>
    {

        public int Id { get; set; }
        public Name Name { get; set; }
        public LastName LastName { get; set; }
        public Email Email { get; set; }
        public Password Password { get; set; }

        protected User()
        {
        }

        public User(
            int id,
            Name name,
            LastName lastName,
            Email email,
            Password password)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public void Validar()
        {

        }

        public bool Equals(User? other)
        {
            return Id == other?.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

    }
}
