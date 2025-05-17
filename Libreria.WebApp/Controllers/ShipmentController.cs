using Microsoft.AspNetCore.Mvc;
using Libreria.CasoUsoCompartida.UCInterfaces;
using Libreria.WebApp.Models;
using Libreria.CasoUsoCompartida.DTOS.Shipment;
using Libreria.LogicaDeNegocio.Exceptions.Shipment;
using Libreria.CasoUsoCompartida.DTOS.Users;
using Libreria.WebApp.Filtros;
using Libreria.LogicaDeNegocio.Entities;
using Libreria.CasoUsoCompartida.DTOS.Agency;
using Libreria.LogicaNegocio.Exceptions.Shipment;

namespace Libreria.WebApp.Controllers
{
    public class ShipmentController : Controller
    {
        private IGetAll<DtoListedShipment> _getAll;
        private IAdd<ShipmentDto> _add;
        private IGetAll<DtoListedUser> _getAllUsers;
        private IGetAll<DtoListedAgency> _getAllAgency;

        private IGetById<DtoListedShipment> _getById;
        private IModify<ShipmentDto> _modify;

        public ShipmentController(
            IGetAll<DtoListedShipment> getAll,
            IAdd<ShipmentDto> add,
            IGetAll<DtoListedUser> getAllUsers,
            IGetAll<DtoListedAgency> getAllAgency,

            IGetById<DtoListedShipment> getById,
            IModify<ShipmentDto> modify)
        {
            _getAll = getAll;
            _add = add;
            _getAllUsers = getAllUsers;
            _getById = getById;
            _modify = modify;
            _getAllAgency = getAllAgency;
        }

        [AdminAndWorkerFilter]
        public IActionResult Index(int? trackingNumber)
        {
            var shipments = _getAll.Execute();
            if (trackingNumber.HasValue)
            {
                shipments = shipments.Where(s => s.TrackingNumber == trackingNumber.Value).ToList();
            }
                    
            return View(shipments);
        }

        [AdminAndWorkerFilter]
        public IActionResult Create()
        {
            var users = _getAllUsers.Execute() ?? new List<DtoListedUser>();
            var agencies = _getAllAgency.Execute() ?? new List<DtoListedAgency>();
            ViewBag.Agencies = agencies;
            ViewBag.Users = users;
            return View();
        }

        [HttpPost]
        public IActionResult Create(VMShipment shipment)
        {
            try
            {
                int? pickupAgency = null;

                // Verificar si el tipo de envío es COMMON y convertir PickupAgency a int
                if (shipment.TipoEnvio == TipoEnvio.COMMON && !string.IsNullOrWhiteSpace(shipment.PickupAgency))
                {
                    if (int.TryParse(shipment.PickupAgency, out int parsedValue))
                    {
                        pickupAgency = parsedValue;
                    }
                }
                string? postalAddress = shipment.TipoEnvio == TipoEnvio.URGENT ? shipment.PostalAddress : null;

                var shipmentDto = new ShipmentDto(
                    shipment.TrackingNumber,
                    shipment.Weight,
                    shipment.EmployeeId,
                    shipment.StartDate = DateTime.Now,
                    shipment.DeliveryDate,
                    Shipment.Status.IN_PROGRESS,
                    shipment.CustomerEmail,
                    shipment.TipoEnvio,
                    pickupAgency,
                    postalAddress
                );

                _add.Execute(shipmentDto);
                return RedirectToAction("Index");
            }

            catch (WeightException ex)
            {
                ViewBag.Message = ex.Message;
                return View(shipment);

            }
            catch(EmailException ex)
            {
                ViewBag.Message = ex.Message;
                return View(shipment);
            }

            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            var users = _getAllUsers.Execute() ?? new List<DtoListedUser>();
            ViewBag.Users = users;

            return View(shipment); 
        }

        [HttpGet]
        public IActionResult Modify()
        {
            return View(); 
        }


        [HttpPost]
        public IActionResult Modify(int id)
        {
            try
            {
                var existingShipment = _getById.Execute(id);

                if (existingShipment == null)
                    return RedirectToAction("Index");

                DateTime deliveryDate = DateTime.Now;
                var status = Shipment.Status.FINALIZED;

                int? pickupAgency = existingShipment.TipoEnvio == TipoEnvio.COMMON ? existingShipment.PickupAgency : null;
                string? postalAddress = existingShipment.TipoEnvio == TipoEnvio.URGENT ? existingShipment.PostalAddress : null;

                var shipmentDto = new ShipmentDto(
                    existingShipment.TrackingNumber,
                    existingShipment.Weight,
                    existingShipment.EmployeeId,
                    existingShipment.startDate,
                    deliveryDate,
                    status,
                    existingShipment.CustomerEmail,
                    existingShipment.TipoEnvio,
                    pickupAgency,
                    postalAddress
                );

                _modify.Execute(shipmentDto, id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Ocurrió un error al modificar el envío: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}

