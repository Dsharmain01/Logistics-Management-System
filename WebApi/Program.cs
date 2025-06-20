
using Libreria.CasoUsoCompartida.DTOS.Shipment;
using Libreria.CasoUsoCompartida.DTOS.Tracking;
using Libreria.CasoUsoCompartida.DTOS.Users;
using Libreria.CasoUsoCompartida.UCInterfaces;
using Libreria.Infraestructura.AccesoDatos.EF;
using Libreria.LogicaAplicacion.CasoUso.Usuarios;
using Libreria.LogicaDeAplicacion.CasoUso.Shipment;
using Libreria.LogicaDeAplicacion.CasoUso.Tracking;
using Libreria.LogicaDeAplicacion.CasoUso.User;
using Libreria.LogicaDeNegocio.InterfacesRepositorio;
using Libreria.LogicaNegocio.InterfacesRepositorio;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using WebApi.Services;

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
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {

                    Version = "v1",
                    Title = "ToDo API",
                    Description = "An ASP.NET Core Web API for managing ToDo items",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Shayne Boyer",
                        Email = string.Empty,
                        Url = new Uri("https://twitter.com/spboyer"),
                    },

                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Ingrese el token JWT en este formato: Bearer {token}"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                    {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                    }

                            },
                            new string[] { }

                        }
                    });
            });

            //Inyectar casos de uso del usuario


            builder.Services.AddScoped<IAdd<UserDto>, AddUser>();
            builder.Services.AddScoped<IGetAll<DtoListedUser>, GetAllUser>();
            builder.Services.AddScoped<IGetById<DtoListedUser>, GetById>();
            builder.Services.AddScoped<IModify<UserDto>, ModifyUsuario>();
            builder.Services.AddScoped<IRemove, RemoveUser>();

            //Inyectar casos de uso del envio
            builder.Services.AddScoped<IGetById<ShipmentWithTrackingsDto>, GetByIdShipment>();
            builder.Services.AddScoped<ISearchShipmentByDate<DtoListedShipment>, SearchShipmentByDate>();
            builder.Services.AddScoped<ISearchShipmentByComment<ShipmentWithTrackingsDto>,SearchShipmentByComment>();

            //Inyectar casso de uso del tracking
            builder.Services.AddScoped<IGetByTrackNbr, GetByTrackNbr>();
            builder.Services.AddScoped<IGetShipmentsByCustomer<ShipmentWithTrackingsDto>, GetShipmentsByCustomer>();

            //inyectar el repositorio 

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IShipmentRepository, ShipmentRepository>();
            builder.Services.AddScoped<ITrackingRepository, TrackingRepository>();
            builder.Services.AddScoped<ILogin, LoginUser>();


            builder.Services.AddScoped<SeedData>();


            //inyectar el contexto

            builder.Services.AddDbContext<LibreriaContext>(
             options => options.UseSqlServer(builder.Configuration.GetConnectionString("LibreriaDb"))
            );


            // agregar Jwt
            var jwtConfig = builder.Configuration.GetSection("Jwt");
            var key = Encoding.ASCII.GetBytes(jwtConfig["Key"]);
            builder.Services.AddScoped<IJwtGenerator, JwtGenerator>();

            builder.Services.AddAuthentication(
                options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false; // En producción: true
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero // sin tolerancia extra de expiración
                };
            });
            builder.Services.AddAuthorization();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var seeder = services.GetRequiredService<SeedData>();
                seeder.Run();
            }

            app.Run();
        }
    }
}
