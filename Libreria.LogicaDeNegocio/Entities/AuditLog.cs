
namespace Libreria.LogicaDeNegocio.Entities
{
    public class AuditLog
    {
        public int Id { get; set; }
        public string Action { get; set; }  
        public DateTime Date { get; set; }    
        public string UserId { get; set; }
    }
}
