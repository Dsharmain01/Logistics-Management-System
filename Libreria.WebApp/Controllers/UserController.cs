using Libreria.CasoUsoCompartida.DTOS.Users;
using Libreria.CasoUsoCompartida.UCInterfaces;
using Libreria.LogicaNegocio.Exceptions;
using Libreria.LogicaNegocio.Exceptions.User;
using Microsoft.AspNetCore.Mvc;
using Libreria.WebApp.Models;
using Libreria.WebApp.Filtros;

namespace Libreria.WebApp.Controllers
{
    public class UserController : Controller
    {

        private IGetAll<DtoListedUser> _getAll;
        private IAdd<UserDto> _add;
        private IRemove _remove;
        private IGetById<DtoListedUser> _getById;
        private IModify<UserDto> _modify;

        public UserController(
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

        [AdminFilter]
        public IActionResult Index()
        {
            var model = _getAll.Execute();
            ViewBag.rol = HttpContext.Session.GetString("rol");
            return View(model);
        }


        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            DtoListedUser unU = _getById.Execute(id);
            if (unU == null)
            {
                return RedirectToAction("index");
            }
            return View(unU);
        }


        [HttpPost]
        public IActionResult Create(VMUser user)
        {
            try
            {
                _add.Execute ( new UserDto(user.Id,
                                              user.Name,
                                              user.LastName,
                                              user.Email,
                                              user.Password));
                return RedirectToAction("Index", new {message = "Alta Exitosa"});
            }
            catch (NameException)
            {
                ViewBag.Message = "El nombre no es valido";
            }
            catch (EmailException)
            {
                ViewBag.Message = "El email no es valido";
            }
            catch (PasswordException)
            {
                ViewBag.Message = "La contraseña no es valida";
            }
            catch (LastNameException)
            {
                ViewBag.Message = "El apellido no es valido";
            }
            catch (RepeatedUserException)
            {
                ViewBag.Message = "El usuario ya existe";
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View();
        }

        public IActionResult Remove(int id)
        {
            _remove.Execute(id);
            return RedirectToAction("index");
        }


        [HttpGet]
        public IActionResult Modify(int id)
        {
            var user = _getById.Execute(id);


            var vmUser = new VMUser
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Password=user.Password
            };

            return View(vmUser);
        }

        [HttpPost]
        public IActionResult Modify(VMUser user)
        {
            var userDto = new UserDto(user.Id, user.Name, user.LastName, user.Email, user.Password);
            try
            {
                _modify.Execute(userDto, user.Id);

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(user);
            }
                return RedirectToAction("Index");

        }
    }
}
