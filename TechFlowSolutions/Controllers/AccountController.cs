using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechFlowSolutions.Data;
using TechFlowSolutions.Models;

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
            // Se já estiver logado, vai para o Dashboard
            if (HttpContext.Session.GetInt32("UserId") != null)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                ViewBag.Erro = "Preencha todos os campos.";
                return View();
            }

            // LOGIN SIMPLES (senha armazenada em SenhaHash)
            var user = _context.Usuario
                .AsNoTracking()
                .FirstOrDefault(u => u.Email == email && u.SenhaHash == senha);

            if (user == null)
            {
                ViewBag.Erro = "Email ou senha incorretos.";
                return View();
            }

            // Somente administradores acessam o sistema web
            if (user.Perfil != "Administrador")
            {
                ViewBag.Erro = "Acesso restrito. Apenas Administradores podem acessar.";
                return View();
            }

            // Criar Sessão
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
