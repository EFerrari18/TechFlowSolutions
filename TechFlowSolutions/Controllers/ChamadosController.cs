using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TechFlowSolutions.Data;
using TechFlowSolutions.Models;

namespace TechFlowSolutions.Controllers
{
    public class ChamadosController : BaseAdminController
    {
        private readonly ApplicationDbContext _context;

        public ChamadosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var redirect = RedirectIfNotAdmin();
            if (redirect != null) return redirect;

            var lista = _context.Chamado.AsNoTracking()
                .OrderByDescending(c => c.DataAbertura)
                .ToList();

            return View(lista);
        }

        public IActionResult Detalhes(int id)
        {
            var redirect = RedirectIfNotAdmin();
            if (redirect != null) return redirect;

            var chamado = _context.Chamado.Find(id);
            if (chamado == null) return NotFound();

            return View(chamado);
        }

        public IActionResult EditarStatus(int id)
        {
            var redirect = RedirectIfNotAdmin();
            if (redirect != null) return redirect;

            var chamado = _context.Chamado.Find(id);
            if (chamado == null) return NotFound();

            return View(chamado);
        }

        [HttpPost]
        public IActionResult EditarStatus(int id, string status, string prioridade)
        {
            var redirect = RedirectIfNotAdmin();
            if (redirect != null) return redirect;

            var chamado = _context.Chamado.Find(id);
            if (chamado == null) return NotFound();

            chamado.Status = status;
            chamado.Prioridade = prioridade;

            if (status == "Resolvido" || status == "Fechado")
                chamado.DataFechamento = DateTime.Now;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // Tela para abrir novo chamado (admin também pode abrir)
        public IActionResult Novo()
        {
            var redirect = RedirectIfNotAdmin();
            if (redirect != null) return redirect;

            return View();
        }

        [HttpPost]
        public IActionResult Novo(Chamado model)
        {
            var redirect = RedirectIfNotAdmin();
            if (redirect != null) return redirect;

            if (!ModelState.IsValid)
                return View(model);

            model.DataAbertura = DateTime.Now;
            model.Status = "Aberto";

            // por enquanto, associamos o chamado ao próprio admin logado
            var userId = HttpContext.Session.GetInt32("UserId") ?? 0;
            model.UsuarioId = userId;

            _context.Chamado.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
