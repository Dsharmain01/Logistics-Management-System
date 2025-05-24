using Libreria.LogicaNegocio.Entities;
using Libreria.LogicaNegocio.InterfacesRepositorio;
using Libreria.Infraestructura.AccesoDatos.Excepciones;
using Libreria.LogicaDeNegocio.Entities;
using System.Net.Http;

namespace Libreria.Infraestructura.AccesoDatos.EF
{
    public class UserRepository : IUserRepository
    {
        private LibreriaContext _context;

        public UserRepository(LibreriaContext context)
        {
            _context = context;
        }

        public bool ExisteEmail(string email)
        {
            return _context.Users.Any(u => u.Email.Value == email);
        }

        public int Add(User obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Esta vacio");
            }
            obj.Validar();
            _context.Users.Add(obj);
            _context.SaveChanges();
            return obj.Id;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email.Value == email);
        }

        public User GetById(int id)
        {
            User unU = _context.Users
                .FirstOrDefault(usuario => usuario.Id == id);
            if (unU == null)
            {
                throw new NotFoundException($"No se encontro el id {id}");
            }
            return unU;
        }

        public void Modify(User obj, int Id)
        {
            var existingUser = GetById(Id);

            if (existingUser == null) throw new Exception("Usuario no encontrado");

            existingUser.Name = obj.Name;
            existingUser.LastName = obj.LastName;
            existingUser.Email = obj.Email;
            existingUser.Password = obj.Password;
            _context.SaveChanges();

        }

        public void Remove(int id)
        {
            User usuarioEliminar = GetById(id);
            _context.Users.Remove(usuarioEliminar);
            _context.SaveChanges();
        }
    }
}
