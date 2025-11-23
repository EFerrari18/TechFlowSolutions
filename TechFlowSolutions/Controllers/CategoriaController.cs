using Microsoft.AspNetCore.Mvc;
using TechFlowSolutions.Data;
using TechFlowSolutions.Models;

namespace TechFlowSolutions.Controllers
{
    [Route("api/categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public CategoriaController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Listar() => Ok(_db.Categoria.ToList());

        [HttpPost]
        public IActionResult Criar([FromBody] Categoria model)
        {
            _db.Categoria.Add(model);
            _db.SaveChanges();

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            var categoria = _db.Categoria.Find(id);
            if (categoria == null) return NotFound();

            _db.Categoria.Remove(categoria);
            _db.SaveChanges();

            return Ok(new { message = "Categoria removida" });
        }
    }
}
