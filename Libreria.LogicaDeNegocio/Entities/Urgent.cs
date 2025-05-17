namespace Libreria.LogicaDeNegocio.Entities
{
    public class Urgent : Shipment
    {
        public string PostalAddress { get; set; }

        public Urgent(
            int trackNbr,
            decimal weight,
            int? employeeId,
            DateTime startDate,
            DateTime? deliveryDate,
            string customerEmail,
            string postalAddress) : base(trackNbr, weight, employeeId, startDate, deliveryDate, customerEmail)
        {
            StartDate = startDate;
            PostalAddress = postalAddress;
        }
        public bool IsEfficientDelivery =>
        DeliveryDate.HasValue &&
       (DeliveryDate.Value - StartDate).TotalHours < 24;
    }
}