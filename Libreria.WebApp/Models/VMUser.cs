using System.ComponentModel.DataAnnotations;


namespace Libreria.WebApp.Models
{
    public class VMUser
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(15, ErrorMessage = "El {0} no puede tener más de {1} caracteres.")]
        [Display(Name = "Nombre del Usuario")]
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Rol { get; set; }
    }

}