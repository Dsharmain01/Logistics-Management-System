using Libreria.LogicaDeNegocio.Vo;

namespace Libreria.CasoUsoCompartida.DTOS.Agency
{
    public record DtoListedAgency(
        int id,
        string name,
        int? employeeId,
        Ubication ubication
        );  
}
