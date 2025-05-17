using System.ComponentModel.DataAnnotations;
using Libreria.CasoUsoCompartida.DTOS.Shipment;
using static Libreria.LogicaDeNegocio.Entities.Shipment;
namespace Libreria.WebApp.Models
{
    public class VMShipment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El número de seguimiento es obligatorio.")]
        public int TrackingNumber { get; set; }

        [Range(0.1, double.MaxValue, ErrorMessage = "El peso debe ser mayor a 0.")]
        public decimal Weight { get; set; }

        [Required(ErrorMessage = "El ID del empleado es obligatorio.")]
        public int EmployeeId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? DeliveryDate { get; set; }

        [Required(ErrorMessage = "El estado actual es obligatorio.")]
        public Status CurrentStatus { get; set; }

        public string CustomerEmail { get; set; }

        [Required(ErrorMessage = "El tipo de envío es obligatorio.")]
        public TipoEnvio TipoEnvio { get; set; }

        public string? PickupAgency { get; set; }
        public string? PostalAddress { get; set; }

    }
}
