using Microsoft.AspNetCore.Mvc;
using TechFlowSolutions.Data;
using TechFlowSolutions.Models;

namespace TechFlowSolutions.Controllers
{
    [ApiController]
    [Route("api/auditoria")]
    public class AuditoriaController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public AuditoriaController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Listar() => Ok(_db.Auditoria.ToList());

        [HttpPost]
        public IActionResult Registrar([FromBody] Auditoria model)
        {
            model.DataAcao = DateTime.Now;

            _db.Auditoria.Add(model);
            _db.SaveChanges();

            return Ok(model);
        }
    }
}
