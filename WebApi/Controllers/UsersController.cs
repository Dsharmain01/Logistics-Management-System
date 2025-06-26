using Libreria.CasoUsoCompartida.DTOS.Users;
using Libreria.CasoUsoCompartida.UCInterfaces;
using Microsoft.AspNetCore.Mvc;
using Libreria.Infraestructura.AccesoDatos.Excepciones;
using Libreria.LogicaDeNegocio.Entities;
using Libreria.LogicaNegocio.Exceptions;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace WebApi.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    [Token]
    public class UsersController : ControllerBase
    {

        private IGetAll<DtoListedUser> _getAll;
        private IAdd<UserDto> _add;
        private IRemove _remove;
        private IGetById<DtoListedUser> _getById;
        private IModify<UserDto> _modify;

        public UsersController(
            IGetAll<DtoListedUser> getAll,
            IAdd<UserDto> add,
            IRemove remove,
            IGetById<DtoListedUser> getById,
            IModify<UserDto> modify)

        {
            _getAll = getAll;
            _add = add;
            _remove = remove;
            _modify = modify;
            _getById = getById;
        }


        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    try
        //    {
        //        var model = _getAll.Execute();
        //        if (model.Count() == 0)
        //        {
        //            throw new NoContentException("No hay usuarios registrados en la base de datos");
        //        }
        //        return Ok(model);
        //    }
        //    catch (NoContentException e)
        //    {
        //        return StatusCode(e.StatusCode(), e.Error());
        //    }
        //    catch (Exception)
        //    {
        //        Error error = new Error(500, "Hubo un problema. Prueba nuevamente");
        //        return StatusCode(500, error);
        //    }
        //}

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                int idUsuario;
                int.TryParse(id, out idUsuario);

                if (idUsuario == 0)
                {
                    throw new BadRequestException("El valor del id es incorrecto");
                }
                return Ok(_getById.Execute(idUsuario));
            }
            catch (NotFoundException e)
            {
                return StatusCode(e.StatusCode(), e.Error());
            }
            catch (BadRequestException e)
            {
                return StatusCode(e.StatusCode(), e.Error());
            }
            catch (Exception)
            {
                Error error = new Error(500, "Hubo un problema. Prueba nuevamente");
                return StatusCode(500, error);
            }

        }

        //[HttpPost]
        //public IActionResult Create([FromBody] UserDto? user)
        //{
        //    try
        //    {
        //        if (user.Rol != "Admin" && user.Rol != "Client" && user.Rol != "Worker")
        //        {
        //            throw new BadRequestException("El rol debe ser 'Admin', 'Client' o 'Worker'");
        //        }
        //        if (user == null)
        //        {
        //            throw new BadRequestException("El objeto usuario vino vacio");
        //        }
        //        int idUsuario = _add.Execute(user);
        //        return CreatedAtAction("GetByID", new { id = idUsuario }, _getById.Execute(idUsuario));
        //    }
        //    catch (BadRequestException e)
        //    {
        //        return StatusCode(e.StatusCode(), e.Error());
        //    }
        //    catch (LogicaNegocioException e)
        //    {
        //        return StatusCode(400, e.Error());
        //    }
        //    catch (Exception)
        //    {
        //        Error error = new Error(500, "Hubo un problema. Prueba nuevamente");
        //        return StatusCode(500, error);
        //    }
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(string id)
        //{
        //    try
        //    {
        //        int idUsuario;
        //        int.TryParse(id, out idUsuario);

        //        if (idUsuario == 0)
        //        {

        //            throw new BadRequestException("El valor del id es incorrecto");

        //        }
        //        _remove.Execute(idUsuario);
        //        return Ok();
        //    }
        //    catch (NotFoundException e)
        //    {
        //        return StatusCode(e.StatusCode(), e.Error());
        //    }
        //    catch (BadRequestException e)
        //    {
        //        return StatusCode(e.StatusCode(), e.Error());
        //    }
        //    catch (Exception)
        //    {
        //        Error error = new Error(500, "Hubo un problema. Prueba nuevamente");
        //        return StatusCode(500, error);
        //    }
        //}



        [HttpPut("/password")]
        public IActionResult ChangePassword([FromBody] UserPasswordDto dto)
        {
            try
            {
                var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var idUser = int.TryParse(id, out int idParsed) ? idParsed : 0;

                if (idUser == 0)
                    throw new TokenInvalidoException("El token es incorrecto");

                if (string.IsNullOrWhiteSpace(dto.currentPassword) || string.IsNullOrWhiteSpace(dto.newPassword))
                    throw new BadRequestException("Debe ingresar la contraseña actual y la nueva.");

                var existingUser = _getById.Execute(idUser);

                var hasher = new PasswordHasher<object>();
                var result = hasher.VerifyHashedPassword(null, existingUser.Password, dto.currentPassword);

                if (result != PasswordVerificationResult.Success)
                    throw new BadRequestException("La contraseña actual es incorrecta.");

                UserDto updatedUser = new UserDto(
                    existingUser.Name,
                    existingUser.LastName,
                    existingUser.Email,
                    dto.newPassword,
                    existingUser.Rol
                );

                _modify.Execute(updatedUser, idUser);
                return Ok("Se modificó correctamente la contraseña");
            }
            catch (NotFoundException e)
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



