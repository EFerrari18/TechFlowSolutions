using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TechFlowSolutions.Data;

namespace TechFlowSolutions.Controllers
{
    public class FaqController : BaseAdminController
    {
        private readonly ApplicationDbContext _context;

        public FaqController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string termo)
        {
            var redirect = RedirectIfNotAdmin();
            if (redirect != null) return redirect;

            var query = _context.FaqItem.AsQueryable();

            if (!string.IsNullOrWhiteSpace(termo))
            {
                termo = termo.ToLower();
                query = query.Where(f =>
                    f.Pergunta.ToLower().Contains(termo) ||
                    f.Resposta.ToLower().Contains(termo));
            }

            var lista = query
                .OrderBy(f => f.Pergunta)
                .ToList();

            ViewBag.Termo = termo;

            return View(lista);
        }
    }
}
