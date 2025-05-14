using Libreria.CasoUsoCompartida.DTOS.Users;
using Libreria.CasoUsoCompartida.UCInterfaces;
using Libreria.LogicaNegocio.Exceptions.User;
using Microsoft.AspNetCore.Mvc;
using Libreria.WebApp.Models;


namespace Libreria.WebApp.Controllers
{
    public class LoginController : Controller
    {
        private ILogin _login;
        


        public LoginController(ILogin login)
        {
            _login = login;
        }

        [HttpGet]
        public IActionResult InicioSesion()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InicioSesion(VMLogin loginData)
        {
            try
            {
                var loginDto = new LoginDto(loginData.Email, loginData.Password);

                var user = _login.Execute(loginDto);

                if (user == null)
                {
                    ViewBag.Message = "Credenciales incorrectas";
                    return View();
                }

                HttpContext.Session.SetString("userEmail", user.Email);

                HttpContext.Session.SetString("rol", user.Rol);

                return RedirectToAction("Index", "User");
            }
            catch (EmailException)
            {
                ViewBag.Message = "Email no válido";
            }
            catch (PasswordException)
            {
                ViewBag.Message = "Contraseña no válida";
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            return View();
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}