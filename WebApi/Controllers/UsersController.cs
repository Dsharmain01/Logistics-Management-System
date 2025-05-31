using Libreria.CasoUsoCompartida.DTOS.Users;
using Libreria.CasoUsoCompartida.UCInterfaces;
using Microsoft.AspNetCore.Mvc;
using Libreria.Infraestructura.AccesoDatos.Excepciones;
using Libreria.LogicaDeNegocio.Entities;

namespace WebApi.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
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


        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var model = _getAll.Execute();
                if (model.Count() == 0)
                {
                    return StatusCode(204);
                }
                return Ok(model);
            }
            catch (Exception)
            {
                return StatusCode(500, "Intente nuevamente");
            }
        }

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

        [HttpPost]
        public IActionResult Create(UserDto user)
        {
            try
            {
                _add.Execute(user);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Intente nuevamente");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _remove.Execute(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Intente nuevamente");
            }
        }



        [HttpPut("{Id}")]
        public IActionResult Modify(int Id, [FromBody] UserDto user)
        {
            try
            {

                if (Id == 0)
                {

                    throw new BadRequestException("El valor del id es incorrecto");

                }

                if (user.Rol != "Admin" && user.Rol != "Client" && user.Rol != "Worker")
                {
                    throw new BadRequestException("El rol debe ser 'Admin', 'Client' o 'Worker'");
                }
                _modify.Execute(user, Id);
                return Ok();
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

    }
}




