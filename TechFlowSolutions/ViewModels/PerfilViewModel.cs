using System.ComponentModel.DataAnnotations;

namespace TechFlowWeb.ViewModels
{
    public class PerfilViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Telefone { get; set; }
        public string Setor { get; set; }

        public string NovaSenha { get; set; }
        public string ConfirmarSenha { get; set; }
    }
}
