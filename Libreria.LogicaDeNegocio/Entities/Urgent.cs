namespace Libreria.LogicaDeNegocio.Entities
{
    public class Urgent : Shipment
    {
        public string PostalAddress { get; set; }
        protected Urgent() { }
        public Urgent(
            int trackNbr,
            decimal weight,
            int? employeeId,
            DateTime startDate,
            DateTime? deliveryDate,
            Status status,
            string customerEmail,
            string postalAddress) : base(trackNbr, weight, employeeId, startDate, deliveryDate,status, customerEmail)
        {
            StartDate = startDate;
            PostalAddress = postalAddress;
        }
        public bool IsEfficientDelivery =>
        DeliveryDate.HasValue &&
       (DeliveryDate.Value - StartDate).TotalHours < 24;
    }
}