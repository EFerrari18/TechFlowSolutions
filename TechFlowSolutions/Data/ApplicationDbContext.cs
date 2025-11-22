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

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Chamado> Chamado { get; set; }
        public DbSet<FaqItem> FaqItem { get; set; }
    }
}
