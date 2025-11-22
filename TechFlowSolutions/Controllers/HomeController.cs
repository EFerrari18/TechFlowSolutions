using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TechFlowSolutions.Data;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        // Agrupa os chamados por status
        var dadosGrafico = _context.Chamado
            .GroupBy(x => x.Status)
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
