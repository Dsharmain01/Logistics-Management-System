

using Libreria.CasoUsoCompartida.DTOS.Agency;
using Libreria.CasoUsoCompartida.DTOS.Users;
using Libreria.LogicaDeNegocio.Entities;
using Libreria.LogicaNegocio.Entities;

namespace Libreria.LogicaDeAplicacion.Mapper
{
    internal class MapperAgency
    {
        public static IEnumerable<DtoListedAgency> ToListaDto(IEnumerable<Agency> agency)
        {
            List<DtoListedAgency> dtoListedAgency = new List<DtoListedAgency>();
            foreach (var item in agency)
            {
                dtoListedAgency.Add(new DtoListedAgency(item.Id,
                                                        item.Name.Value));
            }
            return dtoListedAgency;
        }
    }
}
