using Libreria.Infraestructura.AccesoDatos.EF.Config;
using Libreria.LogicaDeNegocio.Entities;
using Libreria.LogicaNegocio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Infraestructura.AccesoDatos.EF
{
    public class LibreriaContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Common> Commons { get; set; }
        public DbSet<Urgent> Urgents { get; set; }
        public DbSet<Tracking> Trackings { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer(@"
        //        Data Source=(localdb)\MSSQLLocalDB;
        //        Initial Catalog=Libreria;
        //        Integrated Security=True");
        //}

        public LibreriaContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new ShipmentConfig());
            modelBuilder.ApplyConfiguration(new AgencyConfig());
            modelBuilder.ApplyConfiguration(new TrackingConfig());

        }
    }
}
