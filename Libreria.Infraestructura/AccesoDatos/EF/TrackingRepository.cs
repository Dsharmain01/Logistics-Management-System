using Libreria.Infraestructura.AccesoDatos.Excepciones;
using Libreria.LogicaDeNegocio.Entities;
using Libreria.LogicaDeNegocio.InterfacesRepositorio;
using Libreria.LogicaNegocio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public IEnumerable<Tracking> GetByTrackNbr(int trackNbr)
        {
            List<Tracking> trackings = _context.Trackings
                .Where(tracking => tracking.TrackNbr == trackNbr)
                .ToList();

            if (!trackings.Any())
            {
                throw new NotFoundException($"No se encontraron trackings para el número {trackNbr}");
            }

            return trackings;
        }

       
    }
}
