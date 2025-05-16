
using Libreria.CasoUsoCompartida.DTOS.Shipment;
using Libreria.CasoUsoCompartida.DTOS.Tracking;
using Libreria.CasoUsoCompartida.DTOS.Users;
using Libreria.CasoUsoCompartida.UCInterfaces;
using Libreria.Infraestructura.AccesoDatos.EF;
using Libreria.LogicaAplicacion.CasoUso.Shipments;
using Libreria.LogicaAplicacion.CasoUso.Usuarios;
using Libreria.LogicaDeAplicacion.CasoUso.Shipment;
using Libreria.LogicaDeAplicacion.CasoUso.Tracking;
using Libreria.LogicaDeAplicacion.CasoUso.User;
using Libreria.LogicaDeNegocio.InterfacesRepositorio;
using Libreria.LogicaNegocio.InterfacesRepositorio;

namespace Libreria.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession();

            //Inyectar casos de uso del usuario


            builder.Services.AddScoped<IAdd<UserDto>, AddUser>();
            builder.Services.AddScoped<IGetAll<DtoListedUser>, GetAllUser>();
            builder.Services.AddScoped<IGetById<DtoListedUser>, GetById>();
            builder.Services.AddScoped<IModify<UserDto>, ModifyUsuario>();
            builder.Services.AddScoped<IRemove, RemoveUser>();

            //Inyectar casos de uso del envio
            
            builder.Services.AddScoped<IGetAll<DtoListedShipment>, GetAllShipment>();
            builder.Services.AddScoped<IAdd<ShipmentDto>, AddShipment>();
            //builder.Services.AddScoped<IRemove, RemoveShipment>();
            builder.Services.AddScoped<IGetById<DtoListedShipment>, GetByIdShipment>();
            builder.Services.AddScoped<IModify<ShipmentDto>, ModifyShipment>();

            //Inyectar casos de uso del tracking

            builder.Services.AddScoped<IAdd<TrackingDto>, AddTracking>();

            //inyectar el repositorio 

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ILogin, LoginUser>();
            builder.Services.AddScoped<IShipmentRepository, ShipmentRepository>();
            builder.Services.AddScoped<ITrackingRepository, TrackingRepository>();

            //inyectar el contexto
            builder.Services.AddScoped<SeedData>();

            builder.Services.AddDbContext<LibreriaContext>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            if (app.Environment.IsDevelopment())
            {
                using (var scope = app.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var seeder = services.GetRequiredService<SeedData>();
                    seeder.Run();
                }
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=InicioSesion}/{id?}");

            app.Run();
        }
    }
}
