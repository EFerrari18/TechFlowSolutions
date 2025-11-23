namespace TechFlowSolutions.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string SenhaHash { get; set; } = null!;
        public string Perfil { get; set; } = null!; // Usuario, Tecnico, Administrador
        public int? SetorId { get; set; }
        public DateTime DataCadastro { get; set; }

        // Navegação
        public Setor? Setor { get; set; }
        public ICollection<Chamado> ChamadosAbertos { get; set; } = new List<Chamado>();
        public ICollection<Auditoria> Auditoria { get; set; } = new List<Auditoria>();
    }
}
