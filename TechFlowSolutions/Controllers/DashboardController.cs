using Microsoft.AspNetCore.Mvc;
using TechFlowSolutions.Data;

namespace TechFlowSolutions.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        // === RETORNA OS DADOS DO GRÁFICO EM JSON ===
        [HttpGet]
        public IActionResult GraficoChamados()
        {
            var dados = _context.Chamado
                .GroupBy(c => c.DataAbertura.Date)
                .Select(g => new
                {
                    Data = g.Key.ToString("yyyy-MM-dd"),
                    Total = g.Count()
                })
                .OrderBy(x => x.Data)
                .ToList();

            return Json(dados);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
