using Libreria.CasoUsoCompartida.DTOS.Users;
using Libreria.CasoUsoCompartida.UCInterfaces;
using Libreria.LogicaNegocio.Exceptions;
using Libreria.LogicaNegocio.Exceptions.User;
using Microsoft.AspNetCore.Mvc;
using Libreria.WebApp.Models;
using Libreria.WebApp.Filtros;
using Libreria.LogicaNegocio.Vo;
using Libreria.LogicaDeNegocio.Entities;
using Libreria.Infraestructura.AccesoDatos.EF;

namespace Libreria.WebApp.Controllers
{
    public class UserController : Controller
    {

        private IGetAll<DtoListedUser> _getAll;
        private IAdd<UserDto> _add;
        private IRemove _remove;
        private IGetById<DtoListedUser> _getById;
        private IModify<UserDto> _modify;
        private readonly LibreriaContext _context;

        public UserController(
            IGetAll<DtoListedUser> getAll, 
            IAdd<UserDto> add, 
            IRemove remove, 
            IGetById<DtoListedUser> getById,
            IModify<UserDto> modify,
            LibreriaContext context)

        {
            _getAll = getAll;
            _add = add;
            _remove = remove;
            _modify = modify;
            _getById = getById;
            _context = context;
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
                var passwordVo = new Password(user.Password);
                var nameVo = new Name(user.Name);
                var lastNameVo = new LastName(user.LastName);
                var emailVo = new Email(user.Email);


                _add.Execute ( new UserDto(
                                              user.Name,
                                              user.LastName,
                                              user.Email,
                                              user.Password,
                                              user.Rol));

                var audit = new AuditLog
                {
                    Action = "Create",
                    Date = DateTime.Now,
                    UserId = HttpContext.Session.GetInt32("id").ToString(),

                };
                _context.AuditLogs.Add(audit);
                _context.SaveChanges();

                return RedirectToAction("Index", new {message = "Alta Exitosa"});
            }
            catch (NameException ex)
            {
                ViewBag.Message = ex.Message;
            }
            catch (EmailException ex)
            {
                ViewBag.Message = ex.Message;
            }
            catch (PasswordException ex)
            {
                ViewBag.Message = ex.Message;
            }
            catch (LastNameException ex)
            {
                ViewBag.Message = ex.Message;
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
            var audit = new AuditLog
            {
                Action = "Remove",
                Date = DateTime.Now,
                UserId = HttpContext.Session.GetInt32("id").ToString(),

            };
            _context.AuditLogs.Add(audit);
            _context.SaveChanges();

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
            var userDto = new UserDto(user.Name, user.LastName, user.Email, user.Password, user.Rol);
            try
            {
                _modify.Execute(userDto, user.Id);

                var audit = new AuditLog
                {
                    Action = "Modify",
                    Date = DateTime.Now,
                    UserId = HttpContext.Session.GetInt32("id").ToString(),

                };
                _context.AuditLogs.Add(audit);
                _context.SaveChanges();

            }
            catch (NameException ex)
            {
                ViewBag.Message = ex.Message;
                return View(user);

            }
            catch (EmailException ex)
            {
                ViewBag.Message = ex.Message;
                return View(user);

            }
            catch (PasswordException ex)
            {
                ViewBag.Message = ex.Message;
                return View(user);

            }
            catch (LastNameException ex)
            {
                ViewBag.Message = ex.Message;
                return View(user);

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
