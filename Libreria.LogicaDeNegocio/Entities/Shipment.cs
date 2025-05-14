
namespace Libreria.LogicaDeNegocio.Entities
{
    public class Shipment
    {

        public int Id { get; set; }
        public int TrackNbr { get; set; }
        public decimal Weight { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime? DeliveryDate { get; set; }
        public Status CurrentStatus { get; set; }
        public string CustomerEmail { get; set; }

        public enum Status
        {
            IN_PROGRESS,
            FINALIZED
        }

        protected Shipment() { }

        public Shipment(
            int id,
            int trackNbr,
            decimal weight,
            int employeeId,
            DateTime? startDate,
            DateTime? deliveryDate,
            string customerEmail)
        {
            Id = id;
            TrackNbr = trackNbr;
            Weight = weight;
            EmployeeId = employeeId;
            StartDate = startDate ?? DateTime.Now;
            DeliveryDate = deliveryDate;
            CustomerEmail = customerEmail;
        }

        public void Validar() { }
    }
}
