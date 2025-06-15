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
            return _context.Shipments.ToList();
        }

        public Shipment GetById(int trackNbr)
        {
            Shipment unS = _context.Shipments
                .Include(s => s.Trackings)
               .FirstOrDefault(shipment => shipment.TrackNbr == trackNbr);
            if (unS == null)
            {
                throw new NotFoundException($"No se encontro el id {trackNbr}");
            }
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
                .ToList();
        }
    }
}

