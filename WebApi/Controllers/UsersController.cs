using Libreria.CasoUsoCompartida.DTOS.Users;
using Libreria.CasoUsoCompartida.UCInterfaces;
using Microsoft.AspNetCore.Mvc;
using Libreria.Infraestructura.AccesoDatos.Excepciones;

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
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_getById.Execute(id));
            }
            catch (NotFoundException e)
            {
                return StatusCode(e.StatusCode(), e.Error());
            }
            catch (Exception)
            {
                return StatusCode(500, "Intente nuevamente");
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
    }
}



 
