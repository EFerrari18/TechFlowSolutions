using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechFlowSolutions.Models
{
    [Table("FaqItem")]
    public class FaqItem
    {
        [Key]
        public int IdFaq { get; set; }

        [Required]
        public string Pergunta { get; set; }

        [Required]
        public string Resposta { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
