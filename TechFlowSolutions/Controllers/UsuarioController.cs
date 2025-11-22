using Microsoft.AspNetCore.Mvc;
using System;
using TechFlowSolutions.Data;
using TechFlowSolutions.Models;

namespace TechFlowSolutions.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // LISTAR
        public IActionResult Index()
        {
            var lista = _context.Usuario.ToList();
            return View(lista);
        }

        // GET: CRIAR
        public IActionResult Criar()
        {
            return View();
        }

        // POST: CRIAR
        [HttpPost]
        public IActionResult Criar(Usuario usuario)
        {
            if (!ModelState.IsValid)
                return View(usuario);

            _context.Usuario.Add(usuario);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: EDITAR
        public IActionResult Editar(int id)
        {
            var usuario = _context.Usuario.Find(id);

            if (usuario == null)
                return NotFound();

            return View(usuario);
        }

        // POST: EDITAR
        [HttpPost]
        public IActionResult Editar(Usuario usuario)
        {
            if (!ModelState.IsValid)
                return View(usuario);

            _context.Usuario.Update(usuario);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // CONFIRMAR EXCLUSÃO
        public IActionResult Excluir(int id)
        {
            var usuario = _context.Usuario.Find(id);

            if (usuario == null)
                return NotFound();

            return View(usuario);
        }

        // POST EXCLUSÃO
        [HttpPost, ActionName("Excluir")]
        public IActionResult ExcluirConfirmado(int id)
        {
            var usuario = _context.Usuario.Find(id);

            if (usuario == null)
                return NotFound();

            _context.Usuario.Remove(usuario);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
