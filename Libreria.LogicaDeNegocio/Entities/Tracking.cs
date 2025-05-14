
namespace Libreria.LogicaDeNegocio.Entities
{
    public class Tracking
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime CommentDate { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }

        protected Tracking()
        {
        }

        public Tracking(
            int id,
            string comment,
            DateTime commentDate,
            int employeeId)
        {
            Id = id;
            Comment = comment;
            CommentDate = commentDate;
            EmployeeId = employeeId;
        }
    }
}
