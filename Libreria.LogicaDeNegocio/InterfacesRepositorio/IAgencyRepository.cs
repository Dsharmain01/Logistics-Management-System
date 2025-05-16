using Libreria.LogicaDeNegocio.Entities;
using Libreria.LogicaNegocio.Entities;


namespace Libreria.LogicaDeNegocio.InterfacesRepositorio
{
    public interface IAgencyRepository :
           IAddRepository<Agency>,
           IGetAllRepository<Agency>;
}
    

