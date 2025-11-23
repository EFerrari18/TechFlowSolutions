namespace TechFlowSolutions.Models
{
    public class DashboardViewModel
    {
        public int TotalAbertos { get; set; }
        public int TotalEmAtendimento { get; set; }
        public int TotalResolvidos { get; set; }
        public int TotalFechados { get; set; }

        // Lista com últimos chamados (Dashboard Recentes)
        public List<Chamado> ChamadosRecentes { get; set; } = new List<Chamado>();
    }
}
