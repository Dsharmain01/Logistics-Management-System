
namespace Libreria.LogicaDeNegocio.Entities
{
    public class Tracking
    {
        public int Id { get; set; }
        public int TrackNbr { get; set; }
        public string Comment { get; set; }
        public DateTime CommentDate { get; set; }
        public int EmployeeId { get; set; }

        protected Tracking()
        {
        }

        public Tracking(
            int id,
            int trackNbr,
            string comment,
            DateTime commentDate,
            int employeeId)
        {
            Id = id;
            TrackNbr = trackNbr;
            Comment = comment;
            CommentDate = commentDate;
            EmployeeId = employeeId;
        }

        public void Validar() { }
    }
}
