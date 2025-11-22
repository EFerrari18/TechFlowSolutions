using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechFlowSolutions.Models
{
    [Table("Chamado")]
    public class Chamado
    {
        [Key]
        public int IdChamado { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public string Status { get; set; }      // Aberto, Em Atendimento, Resolvido, Fechado

        public string Prioridade { get; set; }  // Baixa, Média, Alta (se quiser)

        public DateTime DataAbertura { get; set; }

        public DateTime? DataFechamento { get; set; }

        public int UsuarioId { get; set; }      // quem abriu

        public int? TecnicoId { get; set; }     // quem assumiu

        public int CategoriaId { get; set; }
    }
}
