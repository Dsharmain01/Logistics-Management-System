using Libreria.CasoUsoCompartida.DTOS.Shipment;
using Libreria.CasoUsoCompartida.UCInterfaces;
using Libreria.Infraestructura.AccesoDatos.Excepciones;
using Libreria.LogicaDeNegocio.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ShipmentsController : Controller
    {

        private IGetById<ShipmentWithTrackingsDto> _getById;
        private IGetByTrackNbr _getByTrackNbr;
        private IGetShipmentsByCustomer<ShipmentWithTrackingsDto> _getShipmentsByClient;
        private ISearchShipmentByDate<DtoListedShipment> _searchShipmentByDate;
        private ISearchShipmentByComment<ShipmentWithTrackingsDto> _searchShipmentByComment;

        public ShipmentsController(
            IGetById<ShipmentWithTrackingsDto> getById,
            IGetByTrackNbr getByTrackNbr,
            IGetShipmentsByCustomer<ShipmentWithTrackingsDto> getShipmentsByClient,
            ISearchShipmentByDate<DtoListedShipment> searchShipmentByDate,
            ISearchShipmentByComment<ShipmentWithTrackingsDto> searchShipmentByComment)
        {
            _getById = getById;
            _getByTrackNbr = getByTrackNbr;
            _getShipmentsByClient = getShipmentsByClient;
            _searchShipmentByDate = searchShipmentByDate;
            _searchShipmentByComment = searchShipmentByComment;
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
                return Ok(shipment);
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

        [HttpGet ("by-date")]
        public IActionResult SearchShipmentByDate(DateTime date1, DateTime date2, string? estado)
        {
            try
            {
                var email = User.FindFirst(ClaimTypes.Email)?.Value;
                if (date1 == default || date2 == default)
                {
                    throw new BadRequestException("Las fechas proporcionadas son inválidas.");
                }

                if (string.IsNullOrEmpty(estado))
                {
                    throw new BadRequestException("El estado no puede ser vacio");
                }

                var shipments =_searchShipmentByDate.Execute(date1, date2, estado, email);

                if (!shipments.Any())
                {
                    throw new NotFoundException("No se encontraron envíos en el rango de fechas especificado.");
                }
                return Ok(shipments);
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

        [HttpGet("by_comment")]
        public IActionResult SearchByComment(string comment)
        {

            try
            {
                var email = User.FindFirst(ClaimTypes.Email)?.Value;

                if (string.IsNullOrWhiteSpace(comment))
                {
                    throw new BadRequestException("El comentario no puede estar vacío.");
                }
                var shipments = _searchShipmentByComment.Execute(comment, email);
                if (!shipments.Any())
                {
                    throw new NotFoundException("No se encontraron envíos con el comentario especificado.");
                }
                return Ok(shipments);
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

        [HttpGet]
        public IActionResult GetShipments()
        {
            try
            {
                var customerEmail = User.FindFirst(ClaimTypes.Email)?.Value;

                if (string.IsNullOrWhiteSpace(customerEmail))
                {
                    throw new BadRequestException("El correo electrónico del cliente no puede estar vacío.");
                }

                var shipments = _getShipmentsByClient.Execute(customerEmail);

                if (!shipments.Any())
                {
                    throw new NotFoundException("No se encontraron envíos para el cliente especificado.");
                }

                return Ok(shipments);
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
