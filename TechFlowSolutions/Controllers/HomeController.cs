using Microsoft.AspNetCore.Mvc;
using TechFlowSolutions.Data;
using Microsoft.EntityFrameworkCore;

namespace TechFlowSolutions.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            // Dados do gráfico : Quantidade por Status
            var dadosGrafico = _db.Chamado
                .GroupBy(c => c.Status)
                .Select(g => new
                {
                    status = g.Key,
                    quantidade = g.Count()
                })
                .ToList();

            ViewBag.DadosGrafico = dadosGrafico;

            return View();
        }
    }
}
