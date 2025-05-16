
using Libreria.LogicaDeNegocio.InterfacesRepositorio;
using Libreria.LogicaDeNegocio.Entities;
using Libreria.Infraestructura.AccesoDatos.Excepciones;

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
            return obj.Id;
        }

        public IEnumerable<Shipment> GetAll()
        {
            return _context.Shipments.ToList();
        }

        public Shipment GetById(int id)
        {
            Shipment unS = _context.Shipments
               .FirstOrDefault(shipment => shipment.Id == id);
            if (unS == null)
            {
                throw new NotFoundException($"No se encontro el id {id}");
            }
            return unS;
        }

        public void Modify(Shipment obj, int id)
        {
            var existingShipment = GetById(id);

            if (existingShipment == null) throw new Exception("Shipment no encontrado");

            existingShipment.TrackNbr = obj.TrackNbr;
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


    }
}
