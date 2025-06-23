using Libreria.LogicaDeNegocio.Exceptions.Shipment;
using Libreria.LogicaNegocio.Exceptions.User;
using Libreria.LogicaNegocio.InterfacesDominio;

namespace Libreria.LogicaDeNegocio.Entities
{
    public abstract class Shipment : IEntity
    {
        public int TrackNbr { get; set; }
        public decimal Weight { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime? DeliveryDate { get; set; }
        public Status CurrentStatus { get; set; }
        public string CustomerEmail { get; set; }

        public ICollection<Tracking> Trackings { get; set; } = new List<Tracking>();

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
            int? employeeId,
            DateTime? startDate,
            DateTime? deliveryDate,
            Status status,
            string customerEmail)
        {
            TrackNbr = trackNbr;
            Weight = weight;
            EmployeeId = employeeId;
            StartDate = startDate ?? DateTime.Now;
            DeliveryDate = deliveryDate;
            CurrentStatus = status;
            CustomerEmail = customerEmail;
        }

        public void Validar() 
        {     
            if (Weight <= 0)
            {
                throw new WeightException("El peso del envío debe ser mayor a 0.");
            }

            if (string.IsNullOrWhiteSpace(CustomerEmail))
            {
                throw new ArgumentException("El correo del cliente no puede estar vacío.");
            }

            if (!CustomerEmail.Contains("@") || !CustomerEmail.Contains("."))
            {
                throw new EmailException("El correo del cliente no tiene un formato válido.");
            }
        }
    }
}
