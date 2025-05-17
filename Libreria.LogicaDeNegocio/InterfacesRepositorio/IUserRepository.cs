using Libreria.LogicaDeNegocio.InterfacesRepositorio;
using Libreria.LogicaNegocio.Entities;

namespace Libreria.LogicaNegocio.InterfacesRepositorio
{
    public interface IUserRepository :
        IAddRepository<User>,
        IModifyRepository<User>,
        IRemoveRepository<User>,
        IGetAllRepository<User>,
        IGetByIdRepository<User>

    {
        User GetByEmail(string email);
        bool ExisteEmail(string email);
    }
}

