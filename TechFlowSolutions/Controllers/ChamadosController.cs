using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechFlowSolutions.Data;
using TechFlowSolutions.Models;

namespace TechFlowSolutions.Controllers
{
    [ApiController]
    [Route("api/chamado")]
    public class ChamadoController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public ChamadoController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var lista = _db.Chamados
                .Include(c => c.Usuario)
                .Include(c => c.Tecnico)
                .Include(c => c.Categoria)
                .ToList();

            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult Buscar(int id)
        {
            var chamado = _db.Chamados
                .Include(c => c.Usuario)
                .Include(c => c.Tecnico)
                .Include(c => c.Categoria)
                .FirstOrDefault(c => c.IdChamado == id);

            if (chamado == null) return NotFound();

            return Ok(chamado);
        }

        [HttpGet("usuario/{idUsuario}")]
        public IActionResult ListarPorUsuario(int idUsuario)
        {
            var lista = _db.Chamados
                .Where(c => c.UsuarioId == idUsuario)
                .Include(c => c.Categoria)
                .OrderByDescending(c => c.DataAbertura)
                .ToList();

            return Ok(lista);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Chamado model)
        {
            model.DataAbertura = DateTime.Now;
            model.Status = "Aberto";

            _db.Chamados.Add(model);
            _db.SaveChanges();

            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] Chamado model)
        {
            var chamado = _db.Chamados.Find(id);
            if (chamado == null) return NotFound();

            chamado.Status = model.Status;
            chamado.Prioridade = model.Prioridade;
            chamado.TecnicoId = model.TecnicoId;
            chamado.DataFechamento = model.DataFechamento;

            _db.SaveChanges();
            return Ok(chamado);
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            var chamado = _db.Chamados.Find(id);
            if (chamado == null) return NotFound();

            _db.Chamados.Remove(chamado);
            _db.SaveChanges();

            return Ok(new { message = "Chamado removido" });
        }
    }
}
