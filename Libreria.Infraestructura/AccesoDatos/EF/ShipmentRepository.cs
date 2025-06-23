using Libreria.LogicaDeNegocio.InterfacesRepositorio;
using Libreria.LogicaDeNegocio.Entities;
using Libreria.Infraestructura.AccesoDatos.Excepciones;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Infraestructura.AccesoDatos.EF
{
    public class ShipmentRepository : IShipmentRepository
    {
        private LibreriaContext _context;
        public ShipmentRepository(LibreriaContext context)
        {
            _context = context;
        }
        public int Add(Shipment obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Esta vacio");
            }
            obj.Validar();
            _context.Shipments.Add(obj);
            _context.SaveChanges();
            return obj.TrackNbr;
        }

        public IEnumerable<Shipment> GetAll()
        {
            return _context.Shipments
            .ToList();
        }

        public Shipment GetById(int trackNbr)
        {
            Shipment unS = _context.Shipments
                .Include(s => s.Trackings)
                .OrderBy(s=>s.StartDate)
               .FirstOrDefault(shipment => shipment.TrackNbr == trackNbr)
               ;
            if (unS == null)
            {
                throw new NotFoundException($"No se encontro el id {trackNbr}");
            }

            unS.Trackings = unS.Trackings.OrderBy(t => t.CommentDate).ToList();
            return unS;
        }

        public void Modify(Shipment obj, int trkNbr)
        {
            var existingShipment = GetById(trkNbr);

            if (existingShipment == null) throw new Exception("Shipment no encontrado");

            existingShipment.Weight = obj.Weight;
            existingShipment.EmployeeId = obj.EmployeeId;
            existingShipment.CustomerEmail = obj.CustomerEmail;
            existingShipment.DeliveryDate = DateTime.Now;

            if (existingShipment.DeliveryDate.HasValue)
            {
                existingShipment.CurrentStatus = Shipment.Status.FINALIZED;
            }
            else
            {
                existingShipment.CurrentStatus = Shipment.Status.IN_PROGRESS;
            }

            _context.SaveChanges();
        }

        public IEnumerable<Shipment> GetByCustomerEmail(string customerEmail)
        {

                return _context.Shipments
                .Include(s => s.Trackings)
                .Where(s => s.CustomerEmail == customerEmail)
                .OrderBy(s => s.StartDate)
                .ToList();
         
        }

        public IEnumerable<Shipment> SearchShipmentByDate(DateTime date1, DateTime date2, string? estado, string customerEmail)
        {
            IEnumerable<Shipment> shipments = Enumerable.Empty<Shipment>(); 

            if (estado == null)
            {
                shipments = _context.Shipments
                    .AsEnumerable()
                    .Where(s => s.CustomerEmail == customerEmail && s.StartDate >= date1 && s.StartDate <= date2)
                    .OrderBy(s => s.TrackNbr)
                    .ToList();
            }
            else
            {
                shipments = _context.Shipments
                    .AsEnumerable()
                    .Where(s => s.CustomerEmail == customerEmail && s.StartDate >= date1 && s.StartDate <= date2 && s.CurrentStatus.ToString() == estado)
                    .OrderBy(s => s.TrackNbr)
                    .ToList();
            }

            return shipments;
        }

        public IEnumerable<Shipment> SearchShipmentByComment(string comment, string customerEmail)
        {
            return _context.Shipments
                .Include(s => s.Trackings)
                .Where(s => s.CustomerEmail == customerEmail && s.Trackings.Any(t => t.Comment.Contains(comment)))
                .OrderBy(s => s.StartDate)
                .ToList();
        }
    }
}

