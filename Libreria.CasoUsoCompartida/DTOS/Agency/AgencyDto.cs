
using Libreria.LogicaDeNegocio.Vo;

namespace Libreria.CasoUsoCompartida.DTOS.Agency
{
    public record AgencyDto(
        int Id,
        string Name,
        int EmployeeId,
        Ubication Ubication
        );
    
}
