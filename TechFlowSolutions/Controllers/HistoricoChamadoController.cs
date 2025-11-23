using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechFlowSolutions.Data;
using TechFlowSolutions.Models;

namespace TechFlowSolutions.Controllers
{
    [ApiController]
    [Route("api/historico")]
    public class HistoricoChamadoController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public HistoricoChamadoController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet("{chamadoId}")]
        public IActionResult ListarPorChamado(int chamadoId)
        {
            var historico = _db.Historico
                .Include(h => h.Tecnico)
                .Include(h => h.Chamado)
                .Where(h => h.ChamadoId == chamadoId)
                .ToList();

            return Ok(historico);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] HistoricoChamado model)
        {
            model.DataRegistro = DateTime.Now;

            _db.Historico.Add(model);
            _db.SaveChanges();

            return Ok(model);
        }
    }
}
