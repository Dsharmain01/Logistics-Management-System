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

        public ShipmentsController(
            IGetById<DtoListedShipment> getById,
            IGetByTrackNbr getByTrackNbr)
        {
            _getById = getById;
            _getByTrackNbr = getByTrackNbr;
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
    }
}
