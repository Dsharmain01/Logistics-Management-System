using Libreria.CasoUsoCompartida.DTOS.Agency;
using Libreria.CasoUsoCompartida.DTOS.Shipment;
using Libreria.CasoUsoCompartida.UCInterfaces;
using Libreria.LogicaAplicacion.Mapper;
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
        public void Execute(AgencyDto agencyDto)
        {
            _repo.Add(MapperAgency.FromDto(agencyDto));
        }
    }
}
