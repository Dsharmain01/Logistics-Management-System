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
            {
                throw new ArgumentNullException("Esta vacio");
            }
            obj.Validar();
            _context.Trackings.Add(obj);
            _context.SaveChanges();
            return obj.Id;
        } 
    }
}
