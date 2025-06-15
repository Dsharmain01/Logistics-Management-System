using Libreria.LogicaDeNegocio.Entities;
using Libreria.LogicaDeNegocio.InterfacesRepositorio;

namespace Libreria.Infraestructura.AccesoDatos.EF
{
    public class TrackingRepository : ITrackingRepository
    {
        private LibreriaContext _context;

        public TrackingRepository(LibreriaContext context)
        {
            _context = context;
        }


        public int Add(Tracking obj)
        {
            if (obj == null)
                throw new ArgumentNullException("Esta vacio");

            obj.Validar();

            var shipment = _context.Shipments
                .FirstOrDefault(s => s.TrackNbr == obj.TrackNbr);

            if (shipment == null)
                throw new ArgumentException("No existe un envío con ese número de tracking.");

            shipment.Trackings.Add(obj);
            _context.SaveChanges();

            return obj.Id;
        }



        public IEnumerable<Tracking> GetByTrackNbr(int trackNbr)
        {
            if (trackNbr <= 0)
            {
                throw new ArgumentException("El número de tracking debe ser mayor que cero.");
            }

            return _context.Trackings
                           .Where(t => t.TrackNbr == trackNbr)
                           .ToList();
        }
    }
}
