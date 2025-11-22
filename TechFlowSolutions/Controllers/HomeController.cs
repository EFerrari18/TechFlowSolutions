using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechFlowSolutions.Data;
using TechFlowSolutions.Models;

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
            var model = new DashboardViewModel
            {
                TotalAbertos = _db.Chamados.Count(c => c.Status == "Aberto"),
                TotalEmAtendimento = _db.Chamados.Count(c => c.Status == "Em Atendimento"),
                TotalResolvidos = _db.Chamados.Count(c => c.Status == "Resolvido"),
                TotalFechados = _db.Chamados.Count(c => c.Status == "Fechado"),

                ChamadosRecentes = _db.Chamados
                    .OrderByDescending(c => c.DataAbertura)
                    .Take(10)
                    .ToList()
            };

            return View(model);
        }

        // ==== API PARA O GRÁFICO ====

        [HttpGet]
        public IActionResult GetChamadosPorMes()
        {
            var dados = _db.Chamados
                .GroupBy(c => new { c.DataAbertura.Month, c.DataAbertura.Year })
                .Select(g => new
                {
                    mes = g.Key.Month,
                    ano = g.Key.Year,
                    quantidade = g.Count()
                })
                .OrderBy(x => x.ano)
                .ThenBy(x => x.mes)
                .ToList();

            return Json(dados);
        }
    }
}
