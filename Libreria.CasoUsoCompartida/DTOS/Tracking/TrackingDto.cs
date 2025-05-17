namespace Libreria.CasoUsoCompartida.DTOS.Tracking
{
    public record TrackingDto(
        int trackNbr,
        string comment,
        DateTime commentDate,
        int? employeeId
        ); 
}
