using Microsoft.AspNetCore.Mvc;
using TechFlowSolutions.Data;
using TechFlowSolutions.Models;

namespace TechFlowSolutions.Controllers
{
    [ApiController]
    [Route("api/faq")]
    public class FaqController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public FaqController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Listar() => Ok(_db.FaqItens.OrderBy(f => f.Pergunta).ToList());

        [HttpPost]
        public IActionResult Criar([FromBody] FaqItem model)
        {
            model.DataCadastro = DateTime.Now;

            _db.FaqItens.Add(model);
            _db.SaveChanges();

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            var item = _db.FaqItens.Find(id);
            if (item == null) return NotFound();

            _db.FaqItens.Remove(item);
            _db.SaveChanges();
            return Ok(new { message = "Item removido" });
        }
    }
}
