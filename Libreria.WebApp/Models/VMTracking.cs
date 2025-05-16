namespace Libreria.WebApp.Models
{
    public class VMTracking
    {
         public int Id { get; set; }
        public int TrackNbr { get; set; }

        public string Comment { get; set; }

        public DateTime CommentDate { get; set; }

        public int EmployeeId { get; set; }

    }
}
