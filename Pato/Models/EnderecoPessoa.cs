namespace Pato.Models
{
    public class EnderecoPessoa : TelefonePessoa
    {
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public string Uf { get; set; }
    }
}