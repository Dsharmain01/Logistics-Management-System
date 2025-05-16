using Libreria.LogicaDeNegocio.Entities;
using Libreria.LogicaNegocio.Entities;
using Libreria.LogicaNegocio.Vo;

namespace Libreria.Infraestructura.AccesoDatos.EF
{
    public class SeedData
    {

        private LibreriaContext _context;

        public SeedData(LibreriaContext context)
        {
            _context = context;
        }

        public void Run()
        {
            Console.WriteLine("Ejecutando SeedData...");
            if (!_context.Users.Any()) Users();
            if (!_context.Shipments.Any()) Shipments();
        }

        private void Users()
        {
            var users = new List<User>
            {
            new Admin(0, new Name("Juan"), new LastName("Pérez"), new Email("juan@gmail.com"), new Password("admin123")),
            new Worker(0, new Name("Ana"), new LastName("Gómez"), new Email("ana@gmail.com"), new Password("worker123")),
            new Worker(0, new Name("Carlos"), new LastName("López"), new Email("carlos@gmail.com"), new Password("worker456")),
            new Client(0, new Name("Lucía"), new LastName("Méndez"), new Email("lucia@gmail.com"), new Password("client123")),
            new Worker(0, new Name("María"), new LastName("Fernández"), new Email("maria@gmail.com"), new Password("worker789")),
            new Client(0, new Name("Javier"), new LastName("Santos"), new Email("javier@gmail.com"), new Password("client456")),
            new Worker(0, new Name("Luis"), new LastName("Martínez"), new Email("luis@gmail.com"), new Password("worker101")),
            new Client(0, new Name("Elena"), new LastName("Ruiz"), new Email("elena@gmail.com"), new Password("client789")),
            new Worker(0, new Name("Sofía"), new LastName("García"), new Email("sofia@gmail.com"), new Password("worker102")),
            new Client(0, new Name("Pablo"), new LastName("Gómez"), new Email("pablo@gmail.com"), new Password("client101"))
            };

            _context.Users.AddRange(users);
            _context.SaveChanges();

        }

        private void Shipments()
        {
            var shipments = new List<Shipment>
{
    new Common(0, 12345, 10.5m, 2, DateTime.Now, null, "lucia@gmail.com", "1"), // Cliente: Lucía Méndez
    new Common(0, 67890, 5.2m, 3, DateTime.Now, null, "javier@gmail.com", "2"), // Cliente: Javier Santos
    new Common(0, 11111, 7.8m, 4, DateTime.Now, null, "elena@gmail.com", "3"), // Cliente: Elena Ruiz
    new Common(0, 22222, 3.4m, 5, DateTime.Now, null, "pablo@gmail.com", "4"), // Cliente: Pablo Gómez
    new Common(0, 33333, 6.1m, 1, DateTime.Now, null, "lucia@gmail.com", "2"), // Cliente: Lucía Méndez
    new Urgent(0, 44444, 8.9m, 2, DateTime.Now, null, "javier@gmail.com", postalAddress: "Calle Falsa 123"), // Cliente: Javier Santos
    new Urgent(0, 55555, 4.7m, 3, DateTime.Now, null, "elena@gmail.com", postalAddress: "Av. Siempre Viva 742"), // Cliente: Elena Ruiz
    new Urgent(0, 66666, 9.3m, 4, DateTime.Now, null, "pablo@gmail.com", postalAddress: "Boulevard Central 50"), // Cliente: Pablo Gómez
    new Urgent(0, 77777, 2.5m, 5, DateTime.Now, null, "lucia@gmail.com", postalAddress: "Paseo de la Reforma 100"), // Cliente: Lucía Méndez
    new Urgent(0, 88888, 1.8m, 1, DateTime.Now, null, "javier@gmail.com", postalAddress: "Calle 8 #45")  // Cliente: Javier Santos
};


            _context.Shipments.AddRange(shipments);
            _context.SaveChanges();
        }
    }
}
