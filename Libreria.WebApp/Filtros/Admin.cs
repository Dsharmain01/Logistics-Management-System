using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Libreria.WebApp.Filtros
{
    public class Admin : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Session.GetString("rol") == null)
            {
                context.Result = new RedirectResult("/login/InicioSesion");
            }
            if (context.HttpContext.Session.GetString("rol") != "Admin")
            {
                context.Result = new RedirectResult("/login/InicioSesion");
            }
        }

    }
    }
