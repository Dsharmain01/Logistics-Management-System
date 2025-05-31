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
                // Administrador precargado
                new Admin(0, new Name("Administrador"), new LastName("Principal"), new Email("administrador@gmail.com"), new Password("Gerente2025.")),

                // Otros administradores
                new Admin(0, new Name("Carlos"), new LastName("Ramírez"), new Email("carlos.ramirez@gmail.com"), new Password("Admin+123")),
                new Admin(0, new Name("Lucía"), new LastName("Fernández"), new Email("lucia.fernandez@gmail.com"), new Password("Lucia#2023")),

                // Trabajadores
                new Worker(0, new Name("Javier"), new LastName("Santos"), new Email("javier.santos@gmail.com"), new Password("Worker+456")),
                new Worker(0, new Name("Elena"), new LastName("Ruiz"), new Email("elena.ruiz@gmail.com"), new Password("Elena#789")),
                new Worker(0, new Name("Pablo"), new LastName("Gómez"), new Email("pablo.gomez@gmail.com"), new Password("Pablo+101")),
                new Worker(0, new Name("Sofía"), new LastName("García"), new Email("sofia.garcia@gmail.com"), new Password("Sofia#102")),
                new Worker(0, new Name("Ana"), new LastName("Martínez"), new Email("ana.martinez@gmail.com"), new Password("Ana+456")),
                new Worker(0, new Name("Luis"), new LastName("López"), new Email("luis.lopez@gmail.com"), new Password("Luis#789")),
                new Worker(0, new Name("María"), new LastName("Gómez"), new Email("maria.gomez@gmail.com"), new Password("Maria+2023")),
                new Worker(0, new Name("Matías"), new LastName("Silveira"), new Email("matias.silveira@gmail.com"), new Password("Matias#2024"))
            };

            _context.Users.AddRange(users);
            _context.SaveChanges();
        }

        private void Shipments()
        {
            var shipments = new List<Shipment>
            {
                new Common(0, 10.5m, 2, DateTime.Now, null, "lucia.fernandez@gmail.com", 1), // Cliente: Lucía Fernández
                new Common(0, 5.2m, 3, DateTime.Now, null, "javier.santos@gmail.com", 2), // Cliente: Javier Santos
                new Common(0, 7.8m, 4, DateTime.Now, null, "elena.ruiz@gmail.com", 3), // Cliente: Elena Ruiz
                new Common(0, 3.4m, 5, DateTime.Now, null, "pablo.gomez@gmail.com", 4), // Cliente: Pablo Gómez
                new Common(0, 6.1m, 1, DateTime.Now, null, "sofia.garcia@gmail.com", 2), // Cliente: Sofía García
                new Urgent(0, 8.9m, 2, DateTime.Now, null, "ana.martinez@gmail.com", postalAddress: "Calle Falsa 456"), // Cliente: Ana Martínez
                new Urgent(0, 4.7m, 3, DateTime.Now, null, "luis.lopez@gmail.com", postalAddress: "Av. Siempre Viva 555"), // Cliente: Luis López
                new Urgent(0, 9.3m, 4, DateTime.Now, null, "maria.gomez@gmail.com", postalAddress: "Boulevard Central 80"), // Cliente: María Gómez
                new Urgent(0, 2.5m, 5, DateTime.Now, null, "matias.silveira@gmail.com", postalAddress: "Paseo de la Reforma 500"), // Cliente: Matías Silveira
                new Urgent(0, 1.8m, 1, DateTime.Now, null, "carlos.ramirez@gmail.com", postalAddress: "Calle 25 #36")  // Cliente: Carlos Ramírez
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
                new Tracking(0, 2, "En preparación", DateTime.Now.AddHours(-10), 1),
                new Tracking(0, 2, "En tránsito hacia destino", DateTime.Now.AddHours(-5), 1),

                new Tracking(0, 5, "Retirado por agencia", DateTime.Now.AddHours(-4), 2),
                new Tracking(0, 5, "En camino al destino", DateTime.Now.AddHours(-2), 2),

                new Tracking(0, 6, "En preparación", DateTime.Now.AddHours(-3), 3),

                new Tracking(0, 7, "Listo para enviar", DateTime.Now.AddHours(-2), 4),
                new Tracking(0, 7, "Salida del centro logístico", DateTime.Now.AddHours(-1), 4),

                new Tracking(0, 8, "Entregado", DateTime.Now, 5),

                new Tracking(0, 3, "En reparto", DateTime.Now.AddMinutes(-20), 1),
                new Tracking(0, 3, "Entregado al destinatario", DateTime.Now, 1)
            };

            _context.Trackings.AddRange(trackings);
            _context.SaveChanges();
        }
    }
}
