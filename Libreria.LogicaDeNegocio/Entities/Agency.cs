using Libreria.LogicaDeNegocio.Vo;
using Libreria.LogicaNegocio.Vo;

namespace Libreria.LogicaDeNegocio.Entities
{
    public class Agency
    {
        public Agency(
            int id,
            Name name,
            int employeeId, 
            Ubication ubication
            )
        {
            Id = id;
            Name = name;
            EmployeeId = employeeId;
            Ubication = ubication;
        }

        protected Agency()
        {
        }

        public int Id { get; set; }
       public Name Name { get; set; }
       public int EmployeeId { get; set; }
       public Ubication Ubication { get; set; }

        public void Validar()
        {
           
        }

    }
}
