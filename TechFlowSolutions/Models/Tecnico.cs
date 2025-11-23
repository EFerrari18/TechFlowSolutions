namespace TechFlowSolutions.Models
{
    public class Tecnico
    {
        public int IdTecnico { get; set; }
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Especialidade { get; set; }
        public bool Ativo { get; set; } = true;
        public DateTime DataCadastro { get; set; }

        public ICollection<Chamado> ChamadosAtendidos { get; set; } = new List<Chamado>();
        public ICollection<HistoricoChamado> HistoricoChamados { get; set; } = new List<HistoricoChamado>();
    }
}
