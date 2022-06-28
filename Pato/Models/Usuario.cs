namespace Pato.Models
{
    public class Usuario : Pessoa
    {
        public int pessoaId { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}