using Microsoft.EntityFrameworkCore;
using TechFlowSolutions.Models;

namespace TechFlowSolutions.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Setor> Setores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Chamado> Chamados { get; set; }
        public DbSet<HistoricoChamado> Historicos { get; set; }
        public DbSet<FaqItem> FaqItens { get; set; }
        public DbSet<Auditoria> Auditorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //
            // USUARIO -> SETOR
            //
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Setor)
                .WithMany()
                .HasForeignKey(u => u.SetorId)
                .OnDelete(DeleteBehavior.Restrict);

            //
            // CHAMADO -> USUARIO (CRIADOR)
            //
            modelBuilder.Entity<Chamado>()
                .HasOne(c => c.Usuario)
                .WithMany()
                .HasForeignKey(c => c.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            //
            // CHAMADO -> TECNICO
            //
            modelBuilder.Entity<Chamado>()
                .HasOne(c => c.Tecnico)
                .WithMany()
                .HasForeignKey(c => c.TecnicoId)
                .OnDelete(DeleteBehavior.Restrict);

            //
            // CHAMADO -> CATEGORIA
            //
            modelBuilder.Entity<Chamado>()
                .HasOne(c => c.Categoria)
                .WithMany(ca => ca.Chamados)
                .HasForeignKey(c => c.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);

            //
            // HISTORICO -> CHAMADO
            //
            modelBuilder.Entity<HistoricoChamado>()
                .HasOne(h => h.Chamado)
                .WithMany(c => c.Historico)
                .HasForeignKey(h => h.ChamadoId)
                .OnDelete(DeleteBehavior.Cascade);

            //
            // HISTORICO -> TECNICO
            //
            modelBuilder.Entity<HistoricoChamado>()
                .HasOne(h => h.Tecnico)
                .WithMany()
                .HasForeignKey(h => h.TecnicoId)
                .OnDelete(DeleteBehavior.Restrict);

            //
            // AUDITORIA -> USUARIO
            //
            modelBuilder.Entity<Auditoria>()
                .HasKey(a => a.IdAuditoria);

            modelBuilder.Entity<Auditoria>()
                .HasOne(a => a.Usuario)
                .WithMany()
                .HasForeignKey(a => a.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
