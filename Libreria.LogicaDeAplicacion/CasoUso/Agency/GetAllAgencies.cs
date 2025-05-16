using Libreria.CasoUsoCompartida.DTOS.Agency;
using Libreria.CasoUsoCompartida.UCInterfaces;
using Libreria.LogicaDeAplicacion.Mapper;
using Libreria.LogicaDeNegocio.InterfacesRepositorio;


namespace Libreria.LogicaDeAplicacion.CasoUso.Agency
{
    public class GetAllAgencies : IGetAll<DtoListedAgency>
    {
        private IAgencyRepository _repo;

        public GetAllAgencies(IAgencyRepository repo)
        {
            this._repo = repo;
        }

        public IEnumerable<DtoListedAgency> Execute()
        {
            return MapperAgency.ToListaDto(_repo.GetAll());
        }

    }
}
