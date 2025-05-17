using Libreria.LogicaDeNegocio.Entities;

namespace Libreria.LogicaDeNegocio.InterfacesRepositorio
{
    public interface IAgencyRepository :
           IAddRepository<Agency>,
           IGetAllRepository<Agency>;
}
    

