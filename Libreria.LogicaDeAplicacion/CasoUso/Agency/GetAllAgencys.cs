

using Libreria.CasoUsoCompartida.DTOS.Agency;
using Libreria.CasoUsoCompartida.UCInterfaces;
using Libreria.LogicaDeAplicacion.Mapper;
using Libreria.LogicaDeNegocio.InterfacesRepositorio;

namespace Libreria.LogicaDeAplicacion.CasoUso.Agency
{
    public class GetAllAgencys:IGetAll<DtoListedAgency>
    {
        private IAgencyRepository _repo;
        public GetAllAgencys(IAgencyRepository repo)
        {
            this._repo = repo;
        }
        public IEnumerable<DtoListedAgency> Execute()
        {
            return MapperAgency.ToListaDto(_repo.GetAll());
        }
    }
    
    
}
