namespace Libreria.LogicaDeNegocio.Entities
{
    public class Common : Shipment
    {
        public string PickupAgency { get; set; }

        public Common(int id, int trackNbr, decimal weight, int employeeId, DateTime startDate, DateTime? deliveryDate, string customerEmail, string pickupAgency) : base(id, trackNbr, weight, employeeId, startDate, deliveryDate, customerEmail)
        {
            PickupAgency = pickupAgency;
        }
    }
}

