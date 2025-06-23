namespace Libreria.LogicaDeNegocio.Entities
{
    public class Common : Shipment
    {
        public int? PickupAgency { get; set; }
        protected Common() { }
        public Common(
            int trackNbr,
            decimal weight,
            int? employeeId,
            DateTime startDate,
            DateTime? deliveryDate,
            Status status,
            string customerEmail,
            int? pickupAgency) : base(trackNbr, weight, employeeId, startDate, deliveryDate,status, customerEmail)
        {
            PickupAgency = pickupAgency;
        }
    }
}

