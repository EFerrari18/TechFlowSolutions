namespace TechFlowSolutions.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string SenhaHash { get; set; }
        public string Perfil { get; set; } // Usuario, Tecnico, Administrador
        public int? SetorId { get; set; }
        public DateTime DataCadastro { get; set; }

        public Setor? Setor { get; set; }
    }
}
