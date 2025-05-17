
using Libreria.LogicaNegocio.InterfacesDominio;

namespace Libreria.LogicaDeNegocio.Entities
{
    public abstract class Shipment : IEntity
    {
        public int TrackNbr { get; set; }
        public decimal Weight { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime? DeliveryDate { get; set; }
        public Status CurrentStatus { get; set; }
        public string CustomerEmail { get; set; }
        int IEntity.Id
        {
            get => TrackNbr;
            set => TrackNbr = value;
        }

        public enum Status
        {
            IN_PROGRESS,
            FINALIZED
        }

        protected Shipment() { }

        public Shipment(
            int trackNbr,
            decimal weight,
            int employeeId,
            DateTime? startDate,
            DateTime? deliveryDate,
            string customerEmail)
        {
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
