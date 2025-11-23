namespace TechFlowSolutions.Models
{
    public class Auditoria
    {
        public int IdAuditoria { get; set; }
        public int UsuarioId { get; set; }
        public string Acao { get; set; } = null!;
        public DateTime DataAcao { get; set; }

        public Usuario Usuario { get; set; } = null!;
    }
}
