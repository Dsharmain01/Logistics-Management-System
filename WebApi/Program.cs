
using Libreria.CasoUsoCompartida.DTOS.Shipment;
using Libreria.CasoUsoCompartida.DTOS.Users;
using Libreria.CasoUsoCompartida.UCInterfaces;
using Libreria.Infraestructura.AccesoDatos.EF;
using Libreria.LogicaAplicacion.CasoUso.Shipments;
using Libreria.LogicaAplicacion.CasoUso.Usuarios;
using Libreria.LogicaDeAplicacion.CasoUso.User;
using Libreria.LogicaDeNegocio.InterfacesRepositorio;
using Libreria.LogicaNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Inyectar casos de uso del usuario


            builder.Services.AddScoped<IAdd<UserDto>, AddUser>();
            builder.Services.AddScoped<IGetAll<DtoListedUser>, GetAllUser>();
            builder.Services.AddScoped<IGetById<DtoListedUser>, GetById>();
            builder.Services.AddScoped<IModify<UserDto>, ModifyUsuario>();
            builder.Services.AddScoped<IRemove, RemoveUser>();

            //Inyectar casos de uso del envio

            builder.Services.AddScoped<IGetAll<DtoListedShipment>, GetAllShipment>();
            //builder.Services.AddScoped<IAdd<ShipmentDto>, AddShipment>();
            //builder.Services.AddScoped<IRemove, RemoveShipment>();
            //builder.Services.AddScoped<IGetById<DtoListedShipment>, GetShipmentById>();
            //builder.Services.AddScoped<IModify<ShipmentDto>, ModifyShipment>();

            //inyectar el repositorio 

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ILogin, LoginUser>();
            builder.Services.AddScoped<IShipmentRepository, ShipmentRepository>();

            builder.Services.AddScoped<SeedData>();


            //inyectar el contexto

            builder.Services.AddDbContext<LibreriaContext>(
             options => options.UseSqlServer(builder.Configuration.GetConnectionString("LibreriaDb"))
            );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
