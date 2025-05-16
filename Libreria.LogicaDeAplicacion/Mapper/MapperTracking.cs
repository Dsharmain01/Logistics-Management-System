using Libreria.CasoUsoCompartida.DTOS.Tracking;
using Libreria.LogicaDeNegocio.Entities;



namespace Libreria.LogicaDeAplicacion.Mapper
{
    internal class MapperTracking
    {

        public static Tracking FromDto(TrackingDto trackingDto)
        {
            return new Tracking(
                            0,
                            trackingDto.trackNbr,
                            trackingDto.comment,
                            trackingDto.commentDate,         
                            trackingDto.employeeId
                             );
        }
    }
}
