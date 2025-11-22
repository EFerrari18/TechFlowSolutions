using System.Collections.Generic;

namespace TechFlowSolutions.Models
{
    public class DashboardViewModel
    {
        public int TotalAbertos { get; set; }
        public int TotalEmAtendimento { get; set; }
        public int TotalResolvidos { get; set; }
        public int TotalFechados { get; set; }

        public IEnumerable<Chamado> ChamadosRecentes { get; set; }
    }
}
