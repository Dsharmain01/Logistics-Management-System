using Libreria.CasoUsoCompartida.DTOS.Shipment;
using Libreria.LogicaDeNegocio.Entities;

namespace Libreria.LogicaAplicacion.Mapper
{
    internal class MapperShipment
    {
        public static Shipment FromDto(ShipmentDto shipmentDto)
        {
            if (shipmentDto.TipoEnvio == TipoEnvio.COMMON)
            {
                return new Common(
                    0,
                    shipmentDto.TrackingNumber,
                    shipmentDto.Weight,
                    shipmentDto.EmployeeId,
                    shipmentDto.startDate,
                    shipmentDto.DeliveryDate,
                    shipmentDto.CustomerEmail,
                    shipmentDto.PickupAgency 
                )
                {
                    CurrentStatus = (Shipment.Status)shipmentDto.CurrentStatus
                };
            }
            else if (shipmentDto.TipoEnvio == TipoEnvio.URGENT)
            {
                return new Urgent(
                    0,
                    shipmentDto.TrackingNumber,
                    shipmentDto.Weight,
                    shipmentDto.EmployeeId,
                    shipmentDto.startDate,
                    shipmentDto.DeliveryDate,
                    shipmentDto.CustomerEmail,
                    shipmentDto.PostalAddress
                )
                {
                    CurrentStatus = (Shipment.Status)shipmentDto.CurrentStatus
                };
            }

            throw new InvalidOperationException("Tipo de envío no reconocido.");
        }


        public static ShipmentDto ToDto(Shipment shipment)
        {
            if (shipment is Urgent urgent)
            {
                return new ShipmentDto(
                    urgent.Id,
                    urgent.TrackNbr,
                    urgent.Weight,
                    urgent.EmployeeId,
                    urgent.StartDate,
                    urgent.DeliveryDate,
                    urgent.CurrentStatus,
                    urgent.CustomerEmail,
                    TipoEnvio.URGENT,
                    null,
                    urgent.PostalAddress
                );
            }
            else if (shipment is Common common)
            {
                return new ShipmentDto(
                    common.Id,
                    common.TrackNbr,
                    common.Weight,
                    common.EmployeeId,
                    common.StartDate,
                    common.DeliveryDate,
                    common.CurrentStatus,
                    common.CustomerEmail,
                    TipoEnvio.COMMON,
                    common.PickupAgency,
                    null
                );
            }
            else
            {
                throw new InvalidOperationException("Tipo de envío no reconocido");
            }
        }


        public static IEnumerable<DtoListedShipment> ToListaDto(IEnumerable<Shipment> shipments)
        {
            List<DtoListedShipment> shipmentDtos = new List<DtoListedShipment>();
            foreach (var shipment in shipments)
            {
                TipoEnvio tipo = shipment is Urgent ? TipoEnvio.URGENT : TipoEnvio.COMMON;

                shipmentDtos.Add(new DtoListedShipment(
                    shipment.Id,
                    shipment.TrackNbr,
                    shipment.Weight,
                    shipment.EmployeeId,
                    shipment.StartDate,
                    shipment.DeliveryDate,
                    shipment.CurrentStatus,
                    shipment.CustomerEmail,
                    tipo
                ));
            }
            return shipmentDtos;
        }



    }
}
