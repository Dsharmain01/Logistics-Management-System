using Libreria.CasoUsoCompartida.DTOS.Users;
using Libreria.CasoUsoCompartida.UCInterfaces;
using Libreria.Infraestructura.AccesoDatos.Excepciones;
using Libreria.LogicaDeNegocio.Entities;
using Libreria.LogicaNegocio.Exceptions;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly ILogin _login;
        private readonly IJwtGenerator _jwtGenerator;

        public LoginController(ILogin login, IJwtGenerator jwtGenerator)
        {
            _login = login;
            _jwtGenerator = jwtGenerator;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            try
            {
                if (loginDto == null)
                {
                    throw new BadRequestException("Debe enviar los datos de login.");
                }

                if (string.IsNullOrWhiteSpace(loginDto.Email) || string.IsNullOrWhiteSpace(loginDto.Password))
                {
                    throw new BadRequestException( "Email y contraseña son obligatorios." );
                }

                var user = _login.Execute(loginDto);

                if (user == null)
                {
                   throw new TokenInvalidoException("Credenciales incorrectas.");
                }

                var token = _jwtGenerator.GenerateToken(user);

                return StatusCode(200, new {user, token });
            }
            catch (TokenInvalidoException e)
            {
                return StatusCode(e.StatusCode(), e.Error());
            }
            catch (BadRequestException e)
            {
                return StatusCode(e.StatusCode(), e.Error());
            }
            catch (LogicaNegocioException e)
            {
                return StatusCode(400, e.Error());
            }
            catch (Exception)
            {
                Error error = new Error(500, "Hubo un problema. Prueba nuevamente");
                return StatusCode(500, error);
            }
        }
    }
}
