using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechFlowSolutions.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required, MaxLength(120)]
        public string Nome { get; set; }

        [Required, MaxLength(120)]
        public string Email { get; set; }

        [Required]
        public string SenhaHash { get; set; }   // aqui vamos guardar a senha simples, só para demo

        [Required, MaxLength(20)]
        public string Perfil { get; set; }      // Usuario, Tecnico, Administrador

        public int? SetorId { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
