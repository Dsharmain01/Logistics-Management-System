using Microsoft.AspNetCore.Mvc;
using Libreria.CasoUsoCompartida.UCInterfaces;
using Libreria.WebApp.Models;
using Libreria.CasoUsoCompartida.DTOS.Shipment;
using Libreria.LogicaDeNegocio.Exceptions.Shipment;
using Libreria.CasoUsoCompartida.DTOS.Users;
using Libreria.WebApp.Filtros;

namespace Libreria.WebApp.Controllers
{
    public class ShipmentController : Controller
    {
        private IGetAll<DtoListedShipment> _getAll;
        private IAdd<ShipmentDto> _add;
        private IGetAll<DtoListedUser> _getAllUsers;
        //private IRemove _remove;
        private IGetById<DtoListedShipment> _getById;
        private IModify<ShipmentDto> _modify;

        public ShipmentController(
            IGetAll<DtoListedShipment> getAll,
            IAdd<ShipmentDto> add,
            IGetAll<DtoListedUser> getAllUsers,

            //IRemove remove,
            IGetById<DtoListedShipment> getById,
            IModify<ShipmentDto> modify)
        {
            _getAll = getAll;
            _add = add;
            _getAllUsers = getAllUsers;
            //_remove = remove;
            _getById = getById;
            _modify = modify;
        }

        [AdminAndWorkerFilter]
        public IActionResult Index()
        {
            var shipments = _getAll.Execute();
            return View(shipments);
        }

        [AdminAndWorkerFilter]
        public IActionResult Create()
        {
            var users = _getAllUsers.Execute() ?? new List<DtoListedUser>();
            ViewBag.Users = users;
            return View();
        }

        [HttpPost]
        public IActionResult Create(VMShipment shipment)
        {
            try
            {
                string? pickupAgency = shipment.TipoEnvio == TipoEnvio.COMMON ? shipment.PickupAgency : null;
                string? postalAddress = shipment.TipoEnvio == TipoEnvio.URGENT ? shipment.PostalAddress : null;

                var shipmentDto = new ShipmentDto(
                    shipment.Id,
                    shipment.TrackingNumber,
                    shipment.Weight,
                    shipment.EmployeeId,
                    shipment.StartDate = DateTime.Now,
                    shipment.DeliveryDate,
                    LogicaDeNegocio.Entities.Shipment.Status.IN_PROGRESS,
                    shipment.CustomerEmail,
                    shipment.TipoEnvio,
                    pickupAgency,
                    postalAddress
                );

                _add.Execute(shipmentDto);
                return RedirectToAction("Index");
            }
            catch (TrackingNumberException)
            {
                ViewBag.Message = "El número de seguimiento no es válido.";
            }
            catch (WeightException)
            {
                ViewBag.Message = "El peso del envío no es válido.";
            }
            catch (EmployeeNotFoundException)
            {
                ViewBag.Message = "El empleado asignado no existe.";
            }
            catch (DeliveryDateException)
            {
                ViewBag.Message = "La fecha de entrega no es válida.";
            }
            catch (StatusException)
            {
                ViewBag.Message = "El estado del envío no es válido.";
            }
            catch (RepeatedShipmentException)
            {
                ViewBag.Message = "El envío ya existe.";
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            var users = _getAllUsers.Execute() ?? new List<DtoListedUser>();
            ViewBag.Users = users;

            return View(shipment); 
        }


        //    public IActionResult Detail(int id)
        //    {
        //        var shipment = _getById.Execute(id);
        //        if (shipment == null)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        return View(shipment);
        //    }

        //    public IActionResult Remove(int id)
        //    {
        //        _remove.Execute(id);
        //        return RedirectToAction("Index");
        //    }

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
                var status = LogicaDeNegocio.Entities.Shipment.Status.FINALIZED;

                string? pickupAgency = existingShipment.TipoEnvio == TipoEnvio.COMMON ? existingShipment.PickupAgency : null;
                string? postalAddress = existingShipment.TipoEnvio == TipoEnvio.URGENT ? existingShipment.PostalAddress : null;

                var shipmentDto = new ShipmentDto(
                    existingShipment.Id,
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

