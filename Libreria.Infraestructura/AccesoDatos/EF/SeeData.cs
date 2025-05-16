using Libreria.LogicaDeNegocio.Entities;
using Libreria.LogicaDeNegocio.Vo;
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
            if (!_context.Agencies.Any()) Agencies();
            if (!_context.Trackings.Any()) Trackings();

        }

        private void Users()
        {
            var users = new List<User>
            {
            new Admin(0, new Name("Pedro"), new LastName("Pascal"), new Email("pedro@gmail.com"), new Password("admin123")),
            new Admin(0, new Name("Jose"), new LastName("Silva"), new Email("jose@gmail.com"), new Password("admin123")),
            new Admin(0, new Name("Juan"), new LastName("Pérez"), new Email("juan@gmail.com"), new Password("admin123")),
            new Worker(0, new Name("Fernanda"), new LastName("Gómez"), new Email("fernanda@gmail.com"), new Password("worker123")),
            new Worker(0, new Name("Matias"), new LastName("Silveira"), new Email("matias@gmail.com"), new Password("worker123")),
            new Worker(0, new Name("Ana"), new LastName("Gómez"), new Email("ana@gmail.com"), new Password("worker123")),
            new Worker(0, new Name("Carlos"), new LastName("López"), new Email("carlos@gmail.com"), new Password("worker456")),
            new Worker(0, new Name("María"), new LastName("Fernández"), new Email("maria@gmail.com"), new Password("worker789")),
            new Worker(0, new Name("Luis"), new LastName("Martínez"), new Email("luis@gmail.com"), new Password("worker101")),
            new Worker(0, new Name("Sofía"), new LastName("García"), new Email("sofia@gmail.com"), new Password("worker102")),
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
        new Urgent(0, 44444, 8.9m, 2, DateTime.Now, null, "javier@gmail.com", postalAddress: "Calle Falsa 456"), // Cliente: Javier Santos
        new Urgent(0, 55555, 4.7m, 3, DateTime.Now, null, "elena@gmail.com", postalAddress: "Av. Siempre Viva 555"), // Cliente: Elena Ruiz
        new Urgent(0, 66666, 9.3m, 4, DateTime.Now, null, "pablo@gmail.com", postalAddress: "Boulevard Central 80"), // Cliente: Pablo Gómez
        new Urgent(0, 77777, 2.5m, 5, DateTime.Now, null, "lucia@gmail.com", postalAddress: "Paseo de la Reforma 500"), // Cliente: Lucía Méndez
        new Urgent(0, 88888, 1.8m, 1, DateTime.Now, null, "javier@gmail.com", postalAddress: "Calle 25 #36")  // Cliente: Javier Santos
        };

            _context.Shipments.AddRange(shipments);
            _context.SaveChanges();
        }

        private void Agencies()
        {
            var agencies = new List<Agency>
        {
            new Agency(0, new Name("Agencia Centro"), 1, new Ubication(10.5f, 12345f, "Calle Falsa 123")),
            new Agency(0, new Name("Agencia Norte"), 2, new Ubication(5.2f, 67890f, "Av. Siempre Viva 742")),
            new Agency(0, new Name("Agencia Sur"), 3, new Ubication(7.8f, 11111f, "Boulevard Central 50")),
            new Agency(0, new Name("Agencia Este"), 7, new Ubication(3.4f, 22222f, "Paseo de la Reforma 100")),
            new Agency(0, new Name("Agencia Oeste"), 5, new Ubication(6.1f, 33333f, "Calle 8 #45")),
            new Agency(0, new Name("Agencia Palermo"), 1, new Ubication(8.9f, 44444f, "Diagonal Norte 321")),
            new Agency(0, new Name("Agencia Recoleta"), 2, new Ubication(4.7f, 55555f, "Av. Libertador 999")),
            new Agency(0, new Name("Agencia Belgrano"), 3, new Ubication(9.3f, 66666f, "San Martín 1500")),
            new Agency(0, new Name("Agencia Constitución"), 7, new Ubication(2.5f, 77777f, "9 de Julio 200")),
            new Agency(0, new Name("Agencia Retiro"), 5, new Ubication(1.8f, 88888f, "Av. Córdoba 400"))
        };

            _context.Agencies.AddRange(agencies);
            _context.SaveChanges();
        }

        private void Trackings()
        {
            var trackings = new List<Tracking>
    {
        new Tracking(0, 12345, "En preparación", DateTime.Now.AddHours(-10), 1),
        new Tracking(0, 12345, "En tránsito hacia destino", DateTime.Now.AddHours(-5), 1),

        new Tracking(0, 67890, "Retirado por agencia", DateTime.Now.AddHours(-4), 2),
        new Tracking(0, 67890, "En camino al destino", DateTime.Now.AddHours(-2), 2),

        new Tracking(0, 11111, "En preparación", DateTime.Now.AddHours(-3), 3),

        new Tracking(0, 22222, "Listo para enviar", DateTime.Now.AddHours(-2), 4),
        new Tracking(0, 22222, "Salida del centro logístico", DateTime.Now.AddHours(-1), 4),

        new Tracking(0, 44444, "Entregado", DateTime.Now, 5),

        new Tracking(0, 55555, "En reparto", DateTime.Now.AddMinutes(-20), 1),
        new Tracking(0, 55555, "Entregado al destinatario", DateTime.Now, 1)
    };

            _context.Trackings.AddRange(trackings);
            _context.SaveChanges();
        }


    }
}
