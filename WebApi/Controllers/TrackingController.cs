
using Libreria.CasoUsoCompartida.UCInterfaces;
using Microsoft.AspNetCore.Mvc;
using Libreria.CasoUsoCompartida.DTOS.Tracking;

namespace WebApi.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class TrackingController : ControllerBase
    {

        private IGetByTrackNbr<DtoListedTracking> _getAllByTrackingNbr;


        public TrackingController(
            IGetByTrackNbr<DtoListedTracking> getAllByTrackNbr)

        {
            _getAllByTrackingNbr = getAllByTrackNbr;
        }


        [HttpGet("{trackNbr}")]
        public IActionResult GetByTrackNbr(int trackNbr)
        {
            try
            {
                var model = _getAllByTrackingNbr.Execute(trackNbr);

                if (model.Count() == 0)
                {
                    return StatusCode(204);
                }
                return Ok(model);
            }
            catch (Exception)
            {
                return StatusCode(500, "Intente nuevamente");
            }
        }
    }
}    