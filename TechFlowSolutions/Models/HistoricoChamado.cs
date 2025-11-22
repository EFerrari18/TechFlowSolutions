namespace TechFlowSolutions.Models
{
    public class HistoricoChamado
    {
        public int IdHistorico { get; set; }
        public int ChamadoId { get; set; }
        public int TecnicoId { get; set; }
        public DateTime DataRegistro { get; set; }
        public string Descricao { get; set; }

        public Chamado? Chamado { get; set; }
        public Usuario? Tecnico { get; set; }
    }
}
