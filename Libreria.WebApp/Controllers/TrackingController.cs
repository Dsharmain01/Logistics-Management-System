using Libreria.CasoUsoCompartida.DTOS.Tracking;
using Libreria.CasoUsoCompartida.UCInterfaces;
using Libreria.LogicaDeNegocio.Entities;
using Libreria.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Libreria.WebApp.Filtros;


namespace Libreria.WebApp.Controllers
{
        [AdminAndWorkerFilter]
    public class TrackingController : Controller
    {

        private IAdd<TrackingDto> _add;

        public TrackingController(IAdd<TrackingDto> add)
        {
            _add = add;
        }

        public IActionResult AddTracking(int TrackingNumber, int EmployeeId)
        {
            VMTracking vm = new VMTracking
            {
                TrackNbr = TrackingNumber,
                EmployeeId = EmployeeId
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult AddTracking(VMTracking tracking)
        {
            _add.Execute(new TrackingDto(tracking.TrackNbr,
                                          tracking.Comment,
                                           DateTime.Now,
                                          tracking.EmployeeId));

            TempData["SuccessMessage"] = "Tracking agregado correctamente.";

            return RedirectToAction("AddTracking", "Tracking");
        }
}
    }
