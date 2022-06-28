 namespace Pato.Models
{
    public class Pessoa : EnderecoPessoa
    {
        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
    }
}