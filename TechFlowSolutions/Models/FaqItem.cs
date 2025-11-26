namespace TechFlowSolutions.Models
{
    public class FaqItem
    {
        public int IdFaq { get; set; }

        // Campo novo ✔
        public string Categoria { get; set; } = null!;

        public string Pergunta { get; set; } = null!;
        public string Resposta { get; set; } = null!;
        public DateTime DataCadastro { get; set; }
    }
}
