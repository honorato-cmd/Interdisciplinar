namespace Pato.Models
{
    public class EnderecoFornecedor : TelefoneFornecedor
    {
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public string Uf { get; set; }
    }
}