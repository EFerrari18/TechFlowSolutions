namespace TechFlowSolutions.Models
{
    public class Chamado
    {
        public int IdChamado { get; set; }
        public string Titulo { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public string Status { get; set; } = null!;          // Aberto, Em Atendimento, Resolvido, Fechado
        public string? Prioridade { get; set; }              // Baixa, Média, Alta
        public DateTime DataAbertura { get; set; }
        public DateTime? DataFechamento { get; set; }

        public int UsuarioId { get; set; }       // quem abriu
        public int? TecnicoId { get; set; }      // quem assumiu
        public int CategoriaId { get; set; }

        public Usuario Usuario { get; set; } = null!;
        public Tecnico? Tecnico { get; set; }
        public Categoria Categoria { get; set; } = null!;

        public ICollection<HistoricoChamado> Historico { get; set; } = new List<HistoricoChamado>();
    }
}
