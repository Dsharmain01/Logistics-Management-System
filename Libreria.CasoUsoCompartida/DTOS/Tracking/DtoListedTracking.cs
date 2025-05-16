

namespace Libreria.CasoUsoCompartida.DTOS.Tracking
{
    public record DtoListedTracking(
        int Id,
        int TrackNbr,
        string Comment,
        DateTime CommentDate,
        int EmployeeId
        );
   
}
