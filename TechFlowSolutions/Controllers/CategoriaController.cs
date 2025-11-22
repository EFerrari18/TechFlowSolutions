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
        public IActionResult Listar() => Ok(_db.Categorias.ToList());

        [HttpPost]
        public IActionResult Criar([FromBody] Categoria model)
        {
            _db.Categorias.Add(model);
            _db.SaveChanges();

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            var categoria = _db.Categorias.Find(id);
            if (categoria == null) return NotFound();

            _db.Categorias.Remove(categoria);
            _db.SaveChanges();

            return Ok(new { message = "Categoria removida" });
        }
    }
}
