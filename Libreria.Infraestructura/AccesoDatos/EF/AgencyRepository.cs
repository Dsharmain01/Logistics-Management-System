using Libreria.LogicaDeNegocio.Entities;
using Libreria.LogicaDeNegocio.InterfacesRepositorio;

namespace Libreria.Infraestructura.AccesoDatos.EF
{
    public class AgencyRepository : IAgencyRepository
    {
        private LibreriaContext _context;

        public AgencyRepository(LibreriaContext context)
        {
            _context = context;
        }

        public int Add(Agency obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Esta vacio");
            }
            obj.Validar();
            _context.Agencies.Add(obj);
            _context.SaveChanges();
            return obj.Id;
        }

        public IEnumerable<Agency> GetAll()
        {
            return _context.Agencies.ToList();

        }
    }
}
