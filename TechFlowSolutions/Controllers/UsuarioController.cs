using Microsoft.AspNetCore.Mvc;
using TechFlowSolutions.Data;
using TechFlowSolutions.Models;

namespace TechFlowSolutions.Controllers
{
    // =====================================================================
    // 🟩 API DE USUÁRIOS
    // =====================================================================
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioApiController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public UsuarioApiController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET api/usuario
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_db.Usuario.ToList());
        }

        // GET api/usuario/5
        [HttpGet("{id}")]
        public IActionResult Buscar(int id)
        {
            var usuario = _db.Usuario.Find(id);
            if (usuario == null) return NotFound();

            return Ok(usuario);
        }

        // POST api/usuario
        [HttpPost]
        public IActionResult Criar([FromBody] Usuario user)
        {
            user.DataCadastro = DateTime.Now;
            _db.Usuario.Add(user);
            _db.SaveChanges();

            return Ok(user);
        }

        // PUT api/usuario/5
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] Usuario u)
        {
            var usuario = _db.Usuario.Find(id);
            if (usuario == null) return NotFound();

            usuario.Nome = u.Nome;
            usuario.Email = u.Email;
            usuario.SenhaHash = u.SenhaHash;
            usuario.Perfil = u.Perfil;
            usuario.Setor = u.Setor;

            _db.SaveChanges();

            return Ok(usuario);
        }

        // DELETE api/usuario/5
        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            var usuario = _db.Usuario.Find(id);
            if (usuario == null) return NotFound();

            _db.Usuario.Remove(usuario);
            _db.SaveChanges();

            return Ok(new { message = "Usuário removido com sucesso" });
        }
    }

    // ================================================
    // 🟦 MVC - TELAS DE USUÁRIOS
    // ================================================
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UsuariosController(ApplicationDbContext db)
        {
            _db = db;
        }

        // LISTAR
        public IActionResult Index()
        {
            var lista = _db.Usuario.ToList();
            return View(lista);
        }

        // TELA: CRIAR USUÁRIO
        public IActionResult Criar()
        {
            return View();
        }

        // SALVAR NOVO USUÁRIO
        [HttpPost]
        public IActionResult Criar(Usuario model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.DataCadastro = DateTime.Now;

            _db.Usuario.Add(model);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // TELA: EDITAR
        public IActionResult Editar(int id)
        {
            var user = _db.Usuario.Find(id);
            if (user == null)
                return NotFound();

            return View(user);
        }

        // SALVAR EDIÇÃO
        [HttpPost]
        public IActionResult Editar(Usuario model)
        {
            var user = _db.Usuario.Find(model.IdUsuario);
            if (user == null)
                return NotFound();

            user.Nome = model.Nome;
            user.Email = model.Email;
            user.Perfil = model.Perfil;
            user.SenhaHash = model.SenhaHash;

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // EXCLUIR
        public IActionResult Excluir(int id)
        {
            var user = _db.Usuario.Find(id);
            if (user == null)
                return NotFound();

            _db.Usuario.Remove(user);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }

}
