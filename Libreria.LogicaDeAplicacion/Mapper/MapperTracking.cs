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

        public static IEnumerable<DtoListedTracking> ToListaDto(IEnumerable<Tracking> trackings)
        {
            List<DtoListedTracking> dtoListedTracking = new List<DtoListedTracking>();
            foreach (Tracking item in trackings)
            {
                dtoListedTracking.Add(new DtoListedTracking(item.Id,
                                                             item.TrackNbr,
                                                             item.Comment,
                                                              item.CommentDate,
                                                              item.EmployeeId
                                                                ));
            }
            return dtoListedTracking;
        }
    }
}
