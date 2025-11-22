using Microsoft.AspNetCore.Mvc;
using TechFlowSolutions.Data;
using TechFlowSolutions.Models;

namespace TechFlowSolutions.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public UsuarioController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_db.Usuarios.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Buscar(int id)
        {
            var usuario = _db.Usuarios.Find(id);
            if (usuario == null) return NotFound();

            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Usuario user)
        {
            user.DataCadastro = DateTime.Now;
            _db.Usuarios.Add(user);
            _db.SaveChanges();

            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] Usuario u)
        {
            var usuario = _db.Usuarios.Find(id);
            if (usuario == null) return NotFound();

            usuario.Nome = u.Nome;
            usuario.Email = u.Email;
            usuario.SenhaHash = u.SenhaHash;
            usuario.Perfil = u.Perfil;
            usuario.SetorId = u.SetorId;

            _db.SaveChanges();

            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            var usuario = _db.Usuarios.Find(id);
            if (usuario == null) return NotFound();

            _db.Usuarios.Remove(usuario);
            _db.SaveChanges();

            return Ok(new { message = "Usuário removido com sucesso" });
        }
    }
}
