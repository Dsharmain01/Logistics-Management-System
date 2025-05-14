using Microsoft.AspNetCore.Mvc;
using Libreria.CasoUsoCompartida.UCInterfaces;
using Libreria.WebApp.Models;
using Libreria.CasoUsoCompartida.DTOS.Shipment;
using Admin = Libreria.WebApp.Filtros.Admin;
using Libreria.LogicaDeNegocio.Exceptions.Shipment;

namespace Libreria.WebApp.Controllers
{
    public class ShipmentController : Controller
    {
        private IGetAll<DtoListedShipment> _getAll;
        private IAdd<ShipmentDto> _add;
        //private IRemove _remove;
        //private IGetById<DtoListedShipment> _getById;
        //private IModify<ShipmentDto> _modify;

        public ShipmentController(
            IGetAll<DtoListedShipment> getAll,
            IAdd<ShipmentDto> add)
            //IRemove remove,
            //IGetById<DtoListedShipment> getById,
            //IModify<ShipmentDto> modify)
        {
            _getAll = getAll;
            _add = add;
            //_remove = remove;
            //_getById = getById;
            //_modify = modify;
        }

        [Admin]
        public IActionResult Index()
        {
            var shipments = _getAll.Execute();
            return View(shipments);
        }

        public IActionResult Create()
        {
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
                    shipment.StartDate,
                    shipment.DeliveryDate,
                    shipment.CurrentStatus,
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
            return View();
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

        //    [HttpGet]
        //    public IActionResult Modify(int id)
        //    {
        //        var shipment = _getById.Execute(id);
        //        if (shipment == null)
        //        {
        //            return RedirectToAction("Index");
        //        }

        //        var vmShipment = new VMShipment
        //        {
        //            Id = shipment.Id,
        //            TrackingNumber = shipment.TrackingNumber,
        //            Weight = shipment.Weight,
        //            EmployeeId = shipment.EmployeeId,
        //            DeliveryDate = shipment.DeliveryDate,
        //            CurrentStatus = shipment.CurrentStatus
        //        };

        //        return View(vmShipment);
        //    }

        //    [HttpPost]
        //    public IActionResult Modify(VMShipment shipment)
        //    {
        //        var shipmentDto = new ShipmentDto(
        //            shipment.Id,
        //            shipment.TrackingNumber,
        //            shipment.Weight,
        //            shipment.EmployeeId,
        //            shipment.DeliveryDate,
        //            shipment.CurrentStatus
        //        );

        //        try
        //        {
        //            _modify.Execute(shipmentDto, shipment.Id);
        //            return RedirectToAction("Index");
        //        }
        //        catch (Exception ex)
        //        {
        //            ViewBag.ErrorMessage = ex.Message;
        //            return View(shipment);
        //        }
        //    }
    }
}

