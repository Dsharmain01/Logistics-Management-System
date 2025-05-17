using Libreria.CasoUsoCompartida.DTOS.Agency;
using Libreria.LogicaDeNegocio.Entities;
using Libreria.LogicaDeNegocio.Vo;
using Libreria.LogicaNegocio.Vo;

namespace Libreria.LogicaDeAplicacion.Mapper
{
    public class MapperAgency
    {

        public static Agency FromDto(AgencyDto agencyDto)
        {
            return new Agency(
                                0,
                                new Name(agencyDto.Name),
                                 agencyDto.EmployeeId,
                                new Ubication(
                                         agencyDto.Ubication.Longitude,
                                         agencyDto.Ubication.Latitude,
                                         agencyDto.Ubication.PostalAddress)
                            );
        }

        public static IEnumerable<DtoListedAgency> ToListaDto(IEnumerable<Agency> agencies)
        {
            List<DtoListedAgency> dtoListedAgencies = new List<DtoListedAgency>();
            foreach (var item in agencies)
            {
                dtoListedAgencies.Add(new DtoListedAgency(   item.Id,
                                                             item.Name.Value,
                                                             item.EmployeeId,
                                                             item.Ubication
                                                             ));
            }
            return dtoListedAgencies;
        }
    }
}
