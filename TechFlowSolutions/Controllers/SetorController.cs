using Microsoft.AspNetCore.Mvc;
using TechFlowSolutions.Data;
using TechFlowSolutions.Models;

namespace TechFlowSolutions.Controllers
{
    [ApiController]
    [Route("api/setor")]
    public class SetorController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public SetorController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Listar() => Ok(_db.Setor.ToList());

        [HttpPost]
        public IActionResult Criar([FromBody] Setor model)
        {
            _db.Setor.Add(model);
            _db.SaveChanges();
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            var setor = _db.Setor.Find(id);
            if (setor == null) return NotFound();

            _db.Setor.Remove(setor);
            _db.SaveChanges();
            return Ok(new { message = "Setor removido" });
        }
    }
}
