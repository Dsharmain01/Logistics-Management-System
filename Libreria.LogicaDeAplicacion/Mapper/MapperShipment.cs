using Libreria.CasoUsoCompartida.DTOS.Shipment;
using Libreria.CasoUsoCompartida.DTOS.Tracking;
using Libreria.LogicaDeNegocio.Entities;

namespace Libreria.LogicaAplicacion.Mapper
{
    internal class MapperShipment
    {
        public static Shipment FromDto(ShipmentDto shipmentDto)
        {
            int trackNbr = shipmentDto.TrackingNumber; // Usar el valor del DTO

            if (shipmentDto.TipoEnvio == TipoEnvio.COMMON)
            {
                return new Common(
                    trackNbr,
                    shipmentDto.Weight,
                    shipmentDto.EmployeeId,
                    shipmentDto.startDate,
                    shipmentDto.DeliveryDate,
                    shipmentDto.CustomerEmail,
                    shipmentDto.PickupAgency
                )
                {
                    CurrentStatus = shipmentDto.CurrentStatus
                };
            }
            else if (shipmentDto.TipoEnvio == TipoEnvio.URGENT)
            {
                return new Urgent(
                    trackNbr,
                    shipmentDto.Weight,
                    shipmentDto.EmployeeId,
                    shipmentDto.startDate,
                    shipmentDto.DeliveryDate,
                    shipmentDto.CustomerEmail,
                    shipmentDto.PostalAddress
                )
                {
                    CurrentStatus = shipmentDto.CurrentStatus
                };
            }

            throw new InvalidOperationException("Tipo de envío no reconocido.");
        }

        public static ShipmentDto ToDto(Shipment shipment)
        {
            if (shipment is Urgent urgent)
            {
                return new ShipmentDto(
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
        public static DtoListedShipment ToListedDto(Shipment shipment)
        {
            TipoEnvio tipo = shipment is Urgent ? TipoEnvio.URGENT : TipoEnvio.COMMON;

            int? pickupAgency = tipo == TipoEnvio.COMMON ? ((Common)shipment).PickupAgency : null;
            string? postalAddress = tipo == TipoEnvio.URGENT ? ((Urgent)shipment).PostalAddress : null;

            return new DtoListedShipment(
                shipment.TrackNbr,
                shipment.Weight,
                shipment.EmployeeId,
                shipment.StartDate,
                shipment.DeliveryDate,
                shipment.CurrentStatus,
                shipment.CustomerEmail,
                tipo,
                pickupAgency,
                postalAddress
            );
        }

        public static ShipmentWithTrackingsDto ToWithTrackingsDto(Shipment shipment)
        {
            TipoEnvio tipo = shipment is Urgent ? TipoEnvio.URGENT : TipoEnvio.COMMON;

            int? pickupAgency = tipo == TipoEnvio.COMMON ? ((Common)shipment).PickupAgency : null;
            string? postalAddress = tipo == TipoEnvio.URGENT ? ((Urgent)shipment).PostalAddress : null;

            var trackings = shipment.Trackings?
                .Select(t => new TrackingDto(
                    t.TrackNbr,
                    t.Comment,
                    t.CommentDate,
                    t.EmployeeId
                )).ToList() ?? new List<TrackingDto>();

            return new ShipmentWithTrackingsDto(
                shipment.TrackNbr,
                shipment.Weight,
                shipment.EmployeeId,
                shipment.StartDate,
                shipment.DeliveryDate,
                shipment.CurrentStatus,
                shipment.CustomerEmail,
                tipo,
                pickupAgency,
                postalAddress,
                trackings
            );
        }


        public static IEnumerable<DtoListedShipment> ToListaDto(IEnumerable<Shipment> shipments)
        {
            List<DtoListedShipment> shipmentDtos = new List<DtoListedShipment>();

            foreach (Shipment shipment in shipments)
            {
                TipoEnvio tipo = shipment is Urgent ? TipoEnvio.URGENT : TipoEnvio.COMMON;

                int? pickupAgency = shipment is Common commonShipment ? commonShipment.PickupAgency : null;
                string? postalAddress = shipment is Urgent urgentShipment ? urgentShipment.PostalAddress : null;

                shipmentDtos.Add(new DtoListedShipment(
                    shipment.TrackNbr,
                    shipment.Weight,
                    shipment.EmployeeId,
                    shipment.StartDate,
                    shipment.DeliveryDate,
                    shipment.CurrentStatus,
                    shipment.CustomerEmail,
                    tipo,
                    pickupAgency,
                    postalAddress
                ));
            }

            return shipmentDtos;
        }

        public static IEnumerable<ShipmentWithTrackingsDto> ToListaWithTrackingsDto(IEnumerable<Shipment> shipments)
            {
              var shipmentDtos = new List<ShipmentWithTrackingsDto>();

                foreach (var shipment in shipments)
                {
                    TipoEnvio tipo = shipment is Urgent ? TipoEnvio.URGENT : TipoEnvio.COMMON;
                    int? pickupAgency = shipment is Common commonShipment ? commonShipment.PickupAgency : null;
                    string? postalAddress = shipment is Urgent urgentShipment ? urgentShipment.PostalAddress : null;

                    // Mapear los trackings
                    var trackings = shipment.Trackings?
                        .Select(t => new TrackingDto(
                            t.TrackNbr,
                            t.Comment,
                            t.CommentDate,
                            t.EmployeeId
                        )).ToList() ?? new List<TrackingDto>();

                    shipmentDtos.Add(new ShipmentWithTrackingsDto(
                        shipment.TrackNbr,
                        shipment.Weight,
                        shipment.EmployeeId,
                        shipment.StartDate,
                        shipment.DeliveryDate,
                        shipment.CurrentStatus,
                        shipment.CustomerEmail,
                        tipo,
                        pickupAgency,
                        postalAddress,
                        trackings
                    ));
                }

                return shipmentDtos;
            }
        }
    }



