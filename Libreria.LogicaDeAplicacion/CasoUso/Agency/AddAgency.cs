using Libreria.CasoUsoCompartida.DTOS.Agency;
using Libreria.CasoUsoCompartida.UCInterfaces;
using Libreria.LogicaDeAplicacion.Mapper;
using Libreria.LogicaDeNegocio.InterfacesRepositorio;

namespace Libreria.LogicaDeAplicacion.CasoUso.Agency
{
    public class AddAgency:IAdd<AgencyDto>
    {
        private IAgencyRepository _repo;
        public AddAgency(IAgencyRepository repo)
        {
            _repo = repo;
        }
        public int Execute(AgencyDto agencyDto)
        {
            return(_repo.Add(MapperAgency.FromDto(agencyDto)));
        }
    }
}
