namespace TechFlowSolutions.Models
{
    public class FaqItem
    {
        public int IdFaq { get; set; }
        public string Pergunta { get; set; } = null!;
        public string Resposta { get; set; } = null!;
        public DateTime DataCadastro { get; set; }
    }
}
