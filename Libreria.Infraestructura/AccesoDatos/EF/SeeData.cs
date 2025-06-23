using Libreria.LogicaDeNegocio.Entities;
using Libreria.LogicaDeNegocio.Utilitarias;
using Libreria.LogicaDeNegocio.Vo;
using Libreria.LogicaNegocio.Entities;
using Libreria.LogicaNegocio.Vo;
using static Libreria.LogicaDeNegocio.Entities.Shipment;
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
        // Administradores
        new Admin(0, new Name("Administrador"), new LastName("Principal"), new Email("administrador@gmail.com"), Password.FromHash(PasswordUtils.HashPassword("Gerente2025."))),
        new Admin(0, new Name("Carlos"), new LastName("Ramírez"), new Email("carlos.ramirez@gmail.com"), Password.FromHash(PasswordUtils.HashPassword("Admin+123"))),
        new Admin(0, new Name("Lucía"), new LastName("Fernández"), new Email("lucia.fernandez@gmail.com"), Password.FromHash(PasswordUtils.HashPassword("Lucia#2023"))),

        // Trabajadores
        new Worker(0, new Name("Javier"), new LastName("Santos"), new Email("javier.santos@gmail.com"), Password.FromHash(PasswordUtils.HashPassword("Worker+456"))),
        new Worker(0, new Name("Elena"), new LastName("Ruiz"), new Email("elena.ruiz@gmail.com"), Password.FromHash(PasswordUtils.HashPassword("Elena#789"))),
        new Worker(0, new Name("Pablo"), new LastName("Gómez"), new Email("pablo.gomez@gmail.com"), Password.FromHash(PasswordUtils.HashPassword("Pablo+101"))),
        new Worker(0, new Name("Sofía"), new LastName("García"), new Email("sofia.garcia@gmail.com"), Password.FromHash(PasswordUtils.HashPassword("Sofia#102"))),
        new Worker(0, new Name("Ana"), new LastName("Martínez"), new Email("ana.martinez@gmail.com"), Password.FromHash(PasswordUtils.HashPassword("Ana+456"))),
        new Worker(0, new Name("Luis"), new LastName("López"), new Email("luis.lopez@gmail.com"), Password.FromHash(PasswordUtils.HashPassword("Luis#789"))),
        new Worker(0, new Name("María"), new LastName("Gómez"), new Email("maria.gomez@gmail.com"), Password.FromHash(PasswordUtils.HashPassword("Maria+2023"))),
        new Worker(0, new Name("Matías"), new LastName("Silveira"), new Email("matias.silveira@gmail.com"), Password.FromHash(PasswordUtils.HashPassword("Matias#2024"))),

        // Clientes
        new Client(0, new Name("Diego"), new LastName("Castro"), new Email("diego.castro@gmail.com"), Password.FromHash(PasswordUtils.HashPassword("Diego#2025"))),
        new Client(0, new Name("Camila"), new LastName("Pérez"), new Email("camila.perez@gmail.com"), Password.FromHash(PasswordUtils.HashPassword("Camila+123"))),
        new Client(0, new Name("Valentina"), new LastName("Rodríguez"), new Email("valentina.rodriguez@gmail.com"), Password.FromHash(PasswordUtils.HashPassword("Valen#456"))),
        new Client(0, new Name("Fernando"), new LastName("Suárez"), new Email("fernando.suarez@gmail.com"), Password.FromHash(PasswordUtils.HashPassword("Fer+789"))),
        new Client(0, new Name("Bruno"), new LastName("Alonso"), new Email("bruno.alonso@gmail.com"), Password.FromHash(PasswordUtils.HashPassword("Bruno#2024")))
    };

            _context.Users.AddRange(users);
            _context.SaveChanges();
        }


        private void Shipments()
        {
            var shipments = new List<Shipment> { 
    
        // DIEGO CASTRO
        new Common(0, 4.4m, 3, new DateTime(2024, 6, 10), new DateTime(2024, 6, 13), Status.FINALIZED, "diego.castro@gmail.com", 1),
        new Common(0, 5.0m, 3, new DateTime(2023, 11, 20), null, Status.IN_PROGRESS, "diego.castro@gmail.com", 2),
        new Urgent(0, 2.9m, 2, new DateTime(2024, 6, 18), null, Status.IN_PROGRESS, "diego.castro@gmail.com", "Camino de los Horneros 123"),
        new Urgent(0, 3.1m, 2, new DateTime(2023, 12, 10), new DateTime(2023, 12, 10), Status.FINALIZED, "diego.castro@gmail.com", "Sarandí 321"),

        // CAMILA PÉREZ
        new Common(0, 6.6m, 2, new DateTime(2024, 6, 11), null, Status.IN_PROGRESS, "camila.perez@gmail.com", 2),
        new Common(0, 5.5m, 3, new DateTime(2024, 6, 8), new DateTime(2024, 6, 11), Status.FINALIZED, "camila.perez@gmail.com", 4),
        new Urgent(0, 6.8m, 1, new DateTime(2024, 6, 9), null, Status.IN_PROGRESS, "camila.perez@gmail.com", "Av. 18 de Julio 1234"),
        new Urgent(0, 3.9m, 1, new DateTime(2023, 10, 5), new DateTime(2023, 10, 6), Status.FINALIZED, "camila.perez@gmail.com", "Defensa 778"),

        // VALENTINA RODRÍGUEZ
        new Common(0, 3.1m, 4, new DateTime(2024, 6, 10), new DateTime(2024, 6, 12), Status.FINALIZED, "valentina.rodriguez@gmail.com", 5),
        new Common(0, 5.3m, 4, new DateTime(2024, 2, 5), null, Status.IN_PROGRESS, "valentina.rodriguez@gmail.com", 1),
        new Urgent(0, 5.9m, 4, new DateTime(2024, 6, 7), new DateTime(2024, 6, 10), Status.FINALIZED, "valentina.rodriguez@gmail.com", "Plaza Italia 101"),
        new Urgent(0, 4.2m, 4, new DateTime(2023, 9, 1), null, Status.IN_PROGRESS, "valentina.rodriguez@gmail.com", "18 de Julio 2000"),

        // FERNANDO SUÁREZ
        new Common(0, 3.7m, 5, new DateTime(2024, 6, 13), null, Status.IN_PROGRESS, "fernando.suarez@gmail.com", 3),
        new Common(0, 6.1m, 5, new DateTime(2024, 5, 2), new DateTime(2024, 5, 6), Status.FINALIZED, "fernando.suarez@gmail.com", 2),
        new Urgent(0, 4.4m, 2, new DateTime(2024, 6, 6), new DateTime(2024, 6, 9), Status.FINALIZED, "fernando.suarez@gmail.com", "Cno. Maldonado 560"),
        new Urgent(0, 3.6m, 2, new DateTime(2023, 8, 25), null, Status.IN_PROGRESS, "fernando.suarez@gmail.com", "Constituyente 100"),

        // BRUNO ALONSO
        new Common(0, 7.2m, 1, new DateTime(2024, 5, 9), new DateTime(2024, 5, 11), Status.FINALIZED, "bruno.alonso@gmail.com", 1),
        new Common(0, 6.5m, 1, new DateTime(2024, 4, 1), null, Status.IN_PROGRESS, "bruno.alonso@gmail.com", 4),
        new Urgent(0, 7.0m, 1, new DateTime(2024, 6, 5), new DateTime(2024, 6, 7), Status.FINALIZED, "bruno.alonso@gmail.com", "Ruta 8 km 32"),
        new Urgent(0, 6.2m, 5, new DateTime(2024, 6, 13), null, Status.IN_PROGRESS, "bruno.alonso@gmail.com", "Paso Molino 789")

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
        // Diego Castro (TrackNbr 1-4)
        new Tracking(0, 1, "En preparación", new DateTime(2023, 4, 12, 9, 0, 0), 1),
        new Tracking(0, 1, "En tránsito hacia destino", new DateTime(2023, 4, 13, 15, 0, 0), 1),
        new Tracking(0, 1, "Entregado al destinatario", new DateTime(2024, 6, 22, 10, 50, 0), 1),

        new Tracking(0, 2, "Ingresado a agencia", new DateTime(2023, 8, 5, 10, 30, 0), 2),
        new Tracking(0, 2, "En camino al destino", new DateTime(2023, 8, 6, 13, 45, 0), 2),

        new Tracking(0, 3, "En preparación", new DateTime(2024, 2, 18, 8, 15, 0), 3),
        new Tracking(0, 3, "Entregado", new DateTime(2025, 3, 4, 10, 0, 0), 3),

        new Tracking(0, 4, "Salida del centro logístico", new DateTime(2024, 3, 10, 14, 30, 0), 4),
        new Tracking(0, 4, "En tránsito", new DateTime(2025, 1, 11, 15, 0, 0), 4),
        new Tracking(0, 4, "Listo para enviar", new DateTime(2024, 3, 10, 11, 0, 0), 4),

        // Camila Pérez (TrackNbr 5-8)
        new Tracking(0, 5, "Entregado", new DateTime(2025, 5, 1, 17, 45, 0), 5),
        new Tracking(0, 5, "Listo para despacho", new DateTime(2024, 8, 18, 10, 45, 0), 5),

        new Tracking(0, 6, "Entregado", new DateTime(2024, 9, 2, 16, 0, 0), 6),

        new Tracking(0, 7, "En tránsito hacia destino", new DateTime(2024, 9, 1, 13, 15, 0), 7),

        new Tracking(0, 8, "Entregado al destinatario", new DateTime(2025, 12, 5, 19, 0, 0), 8),
        new Tracking(0, 8, "En preparación", new DateTime(2025, 4, 22, 8, 15, 0), 8),

        // Valentina Rodríguez (TrackNbr 9-12)
        new Tracking(0, 9, "Ingresado en agencia", new DateTime(2024, 10, 7, 12, 15, 0), 9),
        new Tracking(0, 9, "En camino", new DateTime(2024, 10, 8, 18, 30, 0), 9),

        new Tracking(0, 10, "En preparación", new DateTime(2024, 11, 2, 9, 0, 0), 10),
        new Tracking(0, 10, "En tránsito", new DateTime(2024, 11, 3, 16, 0, 0), 10),
        new Tracking(0, 10, "Esperando retiro", new DateTime(2025, 5, 1, 10, 0, 0), 10),

        // Fernando Suárez (TrackNbr 13-16)
        new Tracking(0, 13, "En preparación", new DateTime(2024, 12, 1, 9, 0, 0), 11),
        new Tracking(0, 13, "En tránsito", new DateTime(2024, 12, 3, 14, 30, 0), 11),
        new Tracking(0, 13, "Listo para entrega", new DateTime(2024, 12, 4, 10, 0, 0), 11),

        new Tracking(0, 14, "Ingresado en agencia", new DateTime(2025, 1, 5, 11, 15, 0), 9),
        new Tracking(0, 14, "En camino", new DateTime(2025, 1, 6, 16, 45, 0), 9),

        new Tracking(0, 15, "En preparación", new DateTime(2025, 2, 10, 8, 0, 0), 8),
        new Tracking(0, 15, "Entregado", new DateTime(2025, 2, 12, 13, 30, 0), 8),

        new Tracking(0, 16, "Salida del centro logístico", new DateTime(2025, 3, 15, 9, 45, 0), 7),
        new Tracking(0, 16, "En tránsito", new DateTime(2025, 3, 16, 17, 0, 0), 7),

        // Bruno Alonso (TrackNbr 17-20)
        new Tracking(0, 17, "En preparación", new DateTime(2025, 4, 1, 9, 30, 0), 7),
        new Tracking(0, 17, "En tránsito", new DateTime(2025, 4, 2, 12, 0, 0), 7),
        new Tracking(0, 17, "Entregado", new DateTime(2025, 4, 4, 15, 0, 0), 7),

        new Tracking(0, 18, "Ingresado en agencia", new DateTime(2025, 5, 10, 10, 15, 0), 8),
        new Tracking(0, 18, "En camino", new DateTime(2025, 5, 11, 14, 45, 0), 8),

        new Tracking(0, 19, "En preparación", new DateTime(2025, 6, 20, 9, 0, 0), 9),
        new Tracking(0, 19, "En tránsito", new DateTime(2025, 6, 21, 16, 30, 0), 9),

        new Tracking(0, 20, "Salida del centro logístico", new DateTime(2025, 7, 25, 11, 0, 0), 2),
        new Tracking(0, 20, "Listo para envío", new DateTime(2025, 7, 26, 13, 0, 0), 2),
    };

            _context.Trackings.AddRange(trackings);
            _context.SaveChanges();
        }
    }
    }
