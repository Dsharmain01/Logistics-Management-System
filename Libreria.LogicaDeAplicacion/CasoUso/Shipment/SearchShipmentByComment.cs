using Libreria.CasoUsoCompartida.DTOS.Shipment;
using Libreria.CasoUsoCompartida.UCInterfaces;
using Libreria.LogicaAplicacion.Mapper;
using Libreria.LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaDeAplicacion.CasoUso.Shipment
{
    public class SearchShipmentByComment : ISearchShipmentByComment<ShipmentWithTrackingsDto>
    {
        private IShipmentRepository _repo;
        public SearchShipmentByComment(IShipmentRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<ShipmentWithTrackingsDto> Execute(string comment, string customerEmail)
        {
      
            var shipments = _repo.SearchShipmentByComment(comment, customerEmail);

            return MapperShipment.ToListaWithTrackingsDto(shipments);
        }
    }
}
