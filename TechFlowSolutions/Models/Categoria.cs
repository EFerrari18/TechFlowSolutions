namespace TechFlowSolutions.Models
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string Nome { get; set; } = null!;

        public ICollection<Chamado> Chamados { get; set; } = new List<Chamado>();
    }
}
