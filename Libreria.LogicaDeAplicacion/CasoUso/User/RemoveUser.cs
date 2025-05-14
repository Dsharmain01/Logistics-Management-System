

using Libreria.CasoUsoCompartida.UCInterfaces;
using Libreria.LogicaNegocio.InterfacesRepositorio;

namespace Libreria.LogicaAplicacion.CasoUso.Usuarios
{
    public class RemoveUser: IRemove
    {
        private IUserRepository _repo;

        public RemoveUser(IUserRepository repo)
        {
            _repo = repo;
        }

        public void Execute(int id)
        {
            _repo.Remove(id);
        }

    }
}
