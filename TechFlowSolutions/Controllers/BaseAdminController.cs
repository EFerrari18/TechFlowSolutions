using Microsoft.AspNetCore.Mvc;

namespace TechFlowSolutions.Controllers
{
    public class BaseAdminController : Controller
    {
        protected bool IsAdminLogged()
        {
            var perfil = HttpContext.Session.GetString("Perfil");
            return !string.IsNullOrEmpty(perfil) && perfil == "Administrador";
        }

        protected IActionResult RedirectIfNotAdmin()
        {
            if (!IsAdminLogged())
                return RedirectToAction("Login", "Account");

            return null;
        }
    }
}
