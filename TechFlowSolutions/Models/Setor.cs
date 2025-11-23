namespace TechFlowSolutions.Models
{
    public class Setor
    {
        public int IdSetor { get; set; }
        public string Nome { get; set; } = null!;

        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
