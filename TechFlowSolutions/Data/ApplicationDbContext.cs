using Microsoft.EntityFrameworkCore;
using TechFlowSolutions.Models;

namespace TechFlowSolutions.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auditoria>().HasKey(a => a.IdAuditoria);
            modelBuilder.Entity<Usuario>().HasKey(u => u.IdUsuario);
            modelBuilder.Entity<Tecnico>().HasKey(t => t.IdTecnico);
            modelBuilder.Entity<Setor>().HasKey(s => s.IdSetor);
            modelBuilder.Entity<Categoria>().HasKey(c => c.IdCategoria);
            modelBuilder.Entity<Chamado>().HasKey(c => c.IdChamado);
            modelBuilder.Entity<HistoricoChamado>().HasKey(h => h.IdHistorico);
            modelBuilder.Entity<FaqItem>().HasKey(f => f.IdFaq);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Tecnico> Tecnicos{ get; set; }
        public DbSet<Setor> Setor{ get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Chamado> Chamado { get; set; }
        public DbSet<HistoricoChamado> Historico { get; set; }
        public DbSet<FaqItem> FaqItem { get; set; }
        public DbSet<Auditoria> Auditoria { get; set; }
    }
}
