using Libreria.CasoUsoCompartida.UCInterfaces;
using Libreria.Infraestructura.AccesoDatos.Excepciones;
using Libreria.LogicaDeNegocio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class ShipmentsController : Controller
    {

        private IGetById<DtoListedShipment> _getById;
        private IGetByTrackNbr _getByTrackNbr;
        private IGetShipmentsByCustomer<DtoListedShipment> _getShipmentsByClient;

        public ShipmentsController(
            IGetById<DtoListedShipment> getById,
            IGetByTrackNbr getByTrackNbr,
            IGetShipmentsByCustomer<DtoListedShipment> getShipmentsByClient)
        {
            _getById = getById;
            _getByTrackNbr = getByTrackNbr;
            _getShipmentsByClient = getShipmentsByClient;
        }

        [HttpGet("{trackNbr}")]
        public IActionResult GetById(int trackNbr)
        {
            try
            {
                if (trackNbr == 0)
                {
                    throw new BadRequestException("El valor del id es incorrecto");
                }
                var shipment = _getById.Execute(trackNbr);
                var trackings = _getByTrackNbr.Execute(trackNbr);
                var result = new
                {
                    Shipment = shipment,
                    Trackings = trackings
                };

                return Ok(result);
            }
            catch (NotFoundException e)
            {
                return StatusCode(e.StatusCode(), e.Error());
            }
            catch (BadRequestException e)
            {
                return StatusCode(e.StatusCode(), e.Error());
            }
            catch (Exception)
            {
                Error error = new Error(500, "Intente nuevamente");
                return StatusCode(500, error); ;
            }
        }

        [HttpGet("client/{customerEmail}")]
        public IActionResult GetShipmentsByCustomer(string customerEmail)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(customerEmail))
                {
                    throw new BadRequestException("El correo electrónico del cliente no puede estar vacío.");
                }

                var shipments = _getShipmentsByClient.Execute(customerEmail);

                if (!shipments.Any())
                {
                    throw new NotFoundException("No se encontraron envíos para el cliente especificado.");
                }

                var result = shipments.Select(shipment => new
                {
                    Shipment = shipment,
                    Trackings = _getByTrackNbr.Execute(shipment.TrackingNumber)
                });

                return Ok(result);
            }
            catch (NotFoundException e)
            {
                return StatusCode(e.StatusCode(), e.Error());
            }
            catch (BadRequestException e)
            {
                return StatusCode(e.StatusCode(), e.Error());
            }
            catch (Exception)
            {
                var error = new Error(500, "Ocurrió un error inesperado. Intente nuevamente.");
                return StatusCode(500, error);
            }
        }
    }
}
