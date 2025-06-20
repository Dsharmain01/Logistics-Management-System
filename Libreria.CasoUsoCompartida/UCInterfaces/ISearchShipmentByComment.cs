using Libreria.CasoUsoCompartida.DTOS.Shipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.CasoUsoCompartida.UCInterfaces
{
    public interface ISearchShipmentByComment<T>
    {
        IEnumerable<ShipmentWithTrackingsDto> Execute(string comment, string customerEmail);
    }
}
