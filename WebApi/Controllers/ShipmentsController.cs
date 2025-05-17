using Libreria.CasoUsoCompartida.UCInterfaces;
using Libreria.Infraestructura.AccesoDatos.Excepciones;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class ShipmentsController : Controller
    {

        private IGetById<DtoListedShipment> _getById;

        public ShipmentsController(
            IGetById<DtoListedShipment> getById)
        {
            _getById = getById;
        }

        [HttpGet("{trackNbr}")]
        public IActionResult GetById(int trackNbr)
        {
            try
            {
                return Ok(_getById.Execute(trackNbr));
            }
            catch (NotFoundException e)
            {
                return StatusCode(404, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Intente nuevamente");
            }
        }
    }
}
