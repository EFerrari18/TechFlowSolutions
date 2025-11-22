using Microsoft.AspNetCore.Mvc;
using TechFlowSolutions.Data;
using TechFlowSolutions.Models;
using System.Linq;

namespace TechFlowSolutions.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            // se já estiver logado, vai pro dashboard
            if (HttpContext.Session.GetInt32("UserId") != null)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            // aqui estou usando SenhaHash como senha simples
            var user = _context.Usuario
                .FirstOrDefault(u => u.Email == email && u.SenhaHash == senha);

            if (user == null || user.Perfil != "Administrador")
            {
                ViewBag.Erro = "Credenciais inválidas ou usuário não é Administrador.";
                return View();
            }

            HttpContext.Session.SetInt32("UserId", user.IdUsuario);
            HttpContext.Session.SetString("Nome", user.Nome);
            HttpContext.Session.SetString("Perfil", user.Perfil);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
