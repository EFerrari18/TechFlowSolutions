using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechFlowSolutions.Data;
using TechFlowSolutions.Models;

namespace TechFlowSolutions.Controllers
{
    // ============================================
    // 🟧 API - REST
    // ============================================
    [ApiController]
    [Route("api/chamados")]
    public class ChamadoApiController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public ChamadoApiController(ApplicationDbContext db) { _db = db; }

        [HttpGet]
        public IActionResult GetAll()
        {
            var lista = _db.Chamado
                .Include(c => c.Usuario)
                .Include(c => c.Tecnico)
                .Include(c => c.Categoria)
                .OrderByDescending(c => c.DataAbertura)
                .ToList();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var chamado = _db.Chamado.Find(id);
            return chamado == null ? NotFound() : Ok(chamado);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Chamado model)
        {
            model.DataAbertura = DateTime.Now;
            model.Status = "Aberto";
            _db.Chamado.Add(model);
            _db.SaveChanges();
            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] Chamado model)
        {
            var chamado = _db.Chamado.Find(id);
            if (chamado == null) return NotFound();

            chamado.Titulo = model.Titulo;
            chamado.Descricao = model.Descricao;
            chamado.Status = model.Status;
            chamado.Prioridade = model.Prioridade;
            chamado.CategoriaId = model.CategoriaId;
            chamado.TecnicoId = model.TecnicoId;
            chamado.DataFechamento = model.DataFechamento;
            _db.SaveChanges();

            return Ok(chamado);
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            var chamado = _db.Chamado.Find(id);
            if (chamado == null) return NotFound();

            _db.Chamado.Remove(chamado);
            _db.SaveChanges();
            return Ok(new { message = "Chamado removido" });
        }
    }


    // ============================================
    // 🟦 MVC - Telas
    // ============================================
    public class ChamadosController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ChamadosController(ApplicationDbContext db) { _db = db; }

        // LISTAR
        public IActionResult Index()
        {
            var lista = _db.Chamado
                .Include(c => c.Categoria)
                .OrderByDescending(c => c.DataAbertura)
                .ToList();
            return View(lista);
        }

        // TELA NOVO
        public IActionResult Novo()
        {
            ViewBag.Categorias = _db.Categoria.ToList();
            return View();
        }

        // SALVAR NOVO
        [HttpPost]
        public IActionResult Salvar(Chamado chamado)
        {
            chamado.DataAbertura = DateTime.Now;
            chamado.Status = "Aberto";
            chamado.UsuarioId = HttpContext.Session.GetInt32("UserId") ?? 1;

            _db.Chamado.Add(chamado);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // EDITAR (GET)
        public IActionResult Editar(int id)
        {
            var chamado = _db.Chamado.Find(id);
            if (chamado == null)
                return NotFound();

            ViewBag.Categorias = _db.Categoria.ToList();
            return View(chamado);
        }

        // EDITAR (POST)
        [HttpPost]
        public IActionResult Editar(Chamado model)
        {
            var chamado = _db.Chamado.Find(model.IdChamado);
            if (chamado == null) return NotFound();

            chamado.Titulo = model.Titulo;
            chamado.Descricao = model.Descricao;
            chamado.Status = model.Status;
            chamado.Prioridade = model.Prioridade;
            chamado.CategoriaId = model.CategoriaId;
            chamado.TecnicoId = model.TecnicoId;

            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // EXCLUIR
        public IActionResult Excluir(int id)
        {
            var chamado = _db.Chamado.Find(id);
            if (chamado == null) return NotFound();

            _db.Chamado.Remove(chamado);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
