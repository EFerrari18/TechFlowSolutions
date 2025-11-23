using Microsoft.AspNetCore.Mvc;
using TechFlowSolutions.Data;
using TechFlowSolutions.Models;
using Microsoft.EntityFrameworkCore;

namespace TechFlowSolutions.Controllers
{
    // ================================================
    // 🟩 API DO FAQ
    // ================================================
    [ApiController]
    [Route("api/faq")]
    public class FaqApiController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public FaqApiController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var lista = _db.FaqItem.OrderBy(f => f.Pergunta).ToList();
            return Ok(lista);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] FaqItem model)
        {
            model.DataCadastro = DateTime.Now;

            _db.FaqItem.Add(model);
            _db.SaveChanges();
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            var item = _db.FaqItem.Find(id);
            if (item == null)
                return NotFound();

            _db.FaqItem.Remove(item);
            _db.SaveChanges();

            return Ok(new { message = "Item removido" });
        }
    }

    // ================================================
    // 🟦 CONTROLLER MVC - RENDERIZA AS TELAS
    // ================================================
    public class FaqController : Controller
    {
        private readonly ApplicationDbContext _db;

        public FaqController(ApplicationDbContext db)
        {
            _db = db;
        }

        // /Faq/Index
        public IActionResult Index()
        {
            var lista = _db.FaqItem.OrderBy(f => f.Pergunta).ToList();
            return View(lista);
        }

        // /Faq/Novo
        public IActionResult Novo()
        {
            return View();
        }

        // POST /Faq/Salvar
        [HttpPost]
        public IActionResult Salvar(FaqItem model)
        {
            model.DataCadastro = DateTime.Now;

            _db.FaqItem.Add(model);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // /Faq/Editar/5
        public IActionResult Editar(int id)
        {
            var item = _db.FaqItem.Find(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST /Faq/Editar
        [HttpPost]
        public IActionResult Editar(FaqItem model)
        {
            var item = _db.FaqItem.Find(model.IdFaq);
            if (item == null)
                return NotFound();

            item.Pergunta = model.Pergunta;
            item.Resposta = model.Resposta;

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // /Faq/Excluir/5
        public IActionResult Excluir(int id)
        {
            var item = _db.FaqItem.Find(id);
            if (item == null)
                return NotFound();

            _db.FaqItem.Remove(item);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
