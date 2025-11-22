namespace TechFlowSolutions.Models
{
    public class Chamado
    {
        public int IdChamado { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public string? Prioridade { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime? DataFechamento { get; set; }

        public int UsuarioId { get; set; }
        public int? TecnicoId { get; set; }
        public int Id { get; set; }

        public Usuario Usuario { get; set; }
        public Usuario? Tecnico { get; set; }
        public Categoria Categoria { get; set; }

        public List<HistoricoChamado>? Historico { get; set; }
    }
}
